﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBA.QueryEngine
{

    public class Node
    {
        public List<Node> Children = new List<Node>();
        public Token HostedToken;
        public Node(Token TEntry)
        {
            HostedToken = TEntry;
        }
    }

    public class QueryTree
    {
        public Node Root;
    }

    public class QueryParser
    {

        public delegate Node ParserFunction();

        static Dictionary<TokenType, ParserFunction> Parsers;

        Query Subject;
        public QueryParser(Query Q)
        {
            Subject = Q;
            Parsers = new Dictionary<TokenType, ParserFunction>()
            {
                {TokenType.SELECT_cmd,Select },
                {TokenType.FROM_KW,From },
                {TokenType.WHERE_KW,Where },
                {TokenType.INSERT_cmd,Insert },
                {TokenType.UPDATE_cmd,Update },
                {TokenType.DELETE_cmd,Delete },
                {TokenType.CREATE_cmd,Create },
                {TokenType.ALTER_cmd,Alter },
                {TokenType.DROP_cmd,Drop }
            };
        }

        int currentToken = 0;

        bool End
        {
            get
            {
                return currentToken < Path.Count;
            }
        }
        public Token Peak
        {
            get
            {
                return Path[currentToken];
            }
        }

        public Token Read
        {
            get
            {
                return Path[currentToken++];
            }
        }

        public List<Token> Path
        {
            get
            {
                return Subject.QueryTokens;
            }
        }

        public Token Match(Token Input, TokenType Designation)
        {
            if (Input.Type!=Designation)
                throw new Exception("Syntax Error Encountered in " + 
                    Input.TokenData + " " + Designation.ToString() + " Expected");

            return Input;
        }

        public Query Reorder()
        {
            Query PostProcess = new Query();

            while (currentToken < Subject.QueryTokens.Count && Peak.Type!=TokenType.SemiColon)
            {
                if (Parsers.ContainsKey(Subject.QueryTokens[currentToken].Type))
                {
                    Parsers[Subject.QueryTokens[currentToken].Type]();
                }
            }
            return PostProcess;
        }

        private Node Drop()
        {
            Node N = new Node(Read);
            N.Children.Add(new Node(Read));

            switch (N.Children.Last().HostedToken.Type)
            {
                case TokenType.DATABASE_KW:
                    N.Children.Add(new Node(Match(Read, TokenType.Identifier_DB)));
                    Match(Read, TokenType.SemiColon);
                    break;
                case TokenType.TABLE_KW:
                    N.Children.Add(new Node(Match(Read, TokenType.Identifier_Table)));
                    Match(Read, TokenType.SemiColon);
                    break;
                case TokenType.KEY_KW:
                    N.Children.Add(new Node(Match(Read, TokenType.Identifier_Key)));
                    Match(Read, TokenType.SemiColon);
                    break;
            }
            return N;
        }

        private Node Alter()
        {
            Node N = new Node(Read);
            N.Children.Add(new Node(Read));

            switch (N.Children.Last().HostedToken.Type)
            {
                case TokenType.DATABASE_KW:
                    break;
                case TokenType.TABLE_KW:
                    N.Children.Add(new Node(Match(Read, TokenType.Identifier_Table)));
                    switch(Peak.Type)
                    {
                        case TokenType.CREATE_cmd:
                            N.Children.Add(Create());
                            break;
                        case TokenType.ALTER_cmd:
                            N.Children.Add(Alter());
                            break;
                        case TokenType.DROP_cmd:
                            N.Children.Add(Drop());
                            break;
                    }
                    break;
                case TokenType.KEY_KW:
                    N.Children.Add(new Node(Match(Read, TokenType.Identifier_Key)));
                    N.Children.Add(new Node(Match(Read, TokenType.DATATYPE)));
                    Match(Read, TokenType.SemiColon);
                    break;
            }
            return N;
        }

        private Node Create()
        {
            Node N = new Node(Read);
            N.Children.Add(new Node(Read));

            switch (N.Children.Last().HostedToken.Type)
            {
                case TokenType.DATABASE_KW:
                    N.Children.Add(new Node(Match(Read, TokenType.Identifier_DB)));
                    Match(Read, TokenType.SemiColon);
                    break;
                case TokenType.TABLE_KW:
                    N.Children.Add(new Node(Match(Read, TokenType.Identifier_Table)));
                    Match(Read, TokenType.LBracket);
                    while (!End && Peak.Type!=TokenType.RBracket)
                    {
                        Node Pair = new Node(new Token("", TokenType.Composite));
                        Pair.Children.Add(new Node(Match(Read,TokenType.Identifier_Key)));
                        Pair.Children.Add(new Node(Match(Read, TokenType.DATATYPE)));
                        Match(Read, TokenType.Comma);
                        N.Children.Add(Pair);
                    }
                    break;
                case TokenType.KEY_KW:
                    N.Children.Add(new Node(Match(Read, TokenType.Identifier_Key)));
                    N.Children.Add(new Node(Match(Read, TokenType.DATATYPE)));
                    Match(Read, TokenType.SemiColon);
                    break;
            }
            return N;
        }

        private Node Delete()
        {
            Node N = new Node(Read);
            for (; currentToken < Path.Count; currentToken++)
            {
                if (Peak.Type == TokenType.Identifier_Key)
                {
                    N.Children.Add(new Node(Read));
                }
                if (currentToken < Subject.QueryTokens.Count && Peak.Type != TokenType.Comma)
                {
                    Match(Peak, TokenType.FROM_KW);
                    break;
                }
            }
            N.Children.Add(From());

            currentToken++;

            if (Peak.Type != TokenType.WHERE_KW)
            {
                N.Children.Add(Where());
            }

            return N;
        }

        private Node Update()
        {
            Node N = new Node(Read);
            N.Children.Add(new Node(Match(Read, TokenType.Identifier_Table)));
            Match(Peak, TokenType.SET_cmd);
            N.Children.Add(SetParse());
            N.Children.Add(Where());
            return N;
        }

        private Node SetParse()
        {
            Node N = new Node(new Token(Peak.TokenData, Peak.Type));
            while (currentToken < Path.Count &&
                Peak.Type != TokenType.WHERE_KW || Peak.Type != TokenType.SemiColon)
            {
                Node tmp = new Node(new Token("", TokenType.Composite));
                currentToken++;

                tmp.Children.Add(new Node(Match(Read, TokenType.Identifier_Key)));
                Match(Peak, TokenType.Equal);
                tmp.Children.Add(new Node(Match(Read, TokenType.Immediate_value)));
                N.Children.Add(tmp);
                Match(Peak, TokenType.Comma);

            }
            return N;
        }

        private Node Insert()
        {
            Node N = new Node(Read);

            Match(Peak, TokenType.INTO_KW);
            N.Children.Add(new Node(Read));

            Match(Peak, TokenType.Identifier_Table);
            N.Children.Last().Children.Add(new Node(Read));


            Match(Peak, TokenType.LBracket);
            N.Children.Add(new Node(new Token("", TokenType.Composite)));
            currentToken++;

            for (;currentToken < Path.Count;)
            {
                Match(Peak, TokenType.Identifier_Key);
                N.Children.Last().Children.Add(new Node(Read));
                
                if (currentToken < Path.Count - 1)
                {
                    if (Path[currentToken].Type == TokenType.RBracket)
                        break;
                    Match(Path[currentToken], TokenType.Comma);
                }
            }

            currentToken++;

            Match(Peak, TokenType.VALUES_KW);
            N.Children.Add(VALUES());

            return N;
        }

        private Node VALUES()
        {
            Node N = new Node(Read);
            Match(Peak, TokenType.LBracket);
            while(currentToken < Path.Count)
            {
                Match(Peak, TokenType.Immediate_value);
                N.Children.Add(new Node(Read));
                if (Peak.Type == TokenType.RBracket) { break; }
                Match(Read, TokenType.Comma);
            }
            return N;
        }

        private Node Where()
        {
            Node N = new Node(Read);
            
            while (currentToken < Path.Count)
            {
                Node Expression = new Node(new Token("", TokenType.Composite));
                Expression.Children.Add(new Node(Read));
                Expression.Children.Add(new Node(Read));
                Expression.Children.Add(new Node(Read));
                N.Children.Add(Expression);

                if (Peak.Type == TokenType.Boolean_OR)
                    WhereRecursive(N);
                else if (Peak.Type == TokenType.Boolean_And)
                    continue;
                else
                    break;

                if (Peak.Type == TokenType.SemiColon)
                    break;
            }
            return N;
        }

        private void WhereRecursive(Node N)
        {
            currentToken++;
            while (currentToken < Path.Count)
            {
                Node Expression = new Node(new Token("", TokenType.Composite));
                Expression.Children.Add(new Node(Read));
                Expression.Children.Add(new Node(Read));
                Expression.Children.Add(new Node(Read));
                N.Children.Add(Expression);

                if (Peak.Type == TokenType.Boolean_OR)
                    WhereRecursive(N);
                else if (Peak.Type == TokenType.Boolean_And)
                    continue;
                else
                    break;

                if (Peak.Type == TokenType.SemiColon)
                    break;
            }
        }

        private Node From()
        {
            Node N = new Node(Read);
            Match(Peak, TokenType.Identifier_Table);
            N.Children.Add(new Node(Read));
            return N;
        }

        private Node Select()
        {
            Node N = new Node(Read);
            for (; currentToken < Path.Count; currentToken++)
            {
                Match(Peak, TokenType.Identifier_Key);

                N.Children.Add(new Node(Read));

                if (currentToken < Path.Count - 1 && 
                    Path[currentToken + 1].Type != TokenType.Comma)
                {
                    Match(Path[currentToken + 1], TokenType.FROM_KW);
                    break;
                }
            }
            N.Children.Add(From());

            if (Peak.Type == TokenType.WHERE_KW)
            {
                N.Children.Add(Where());
            }

            return N;
        }
    }
}
