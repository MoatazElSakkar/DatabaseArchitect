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

        public string literal
        {
            get
            {
                return HostedToken.TokenData;
            }
        }
    }

    public class QueryTree
    {
        public Node Root;
    }

    public class QueryParser
    {

        public delegate Node ParserFunction();

        static Dictionary<TokenType, ParserFunction> Conditional;

        static Dictionary<TokenType, ParserFunction> Parsers;

        Query Subject;
        public QueryParser(Query Q)
        {
            Subject = Q;
            Parsers = new Dictionary<TokenType, ParserFunction>()
            {
                {TokenType.SELECT_cmd,Select },
                {TokenType.FROM_KW,From },
                {TokenType.INSERT_cmd,Insert },
                {TokenType.UPDATE_cmd,Update },
                {TokenType.DELETE_cmd,Delete },
                {TokenType.CREATE_cmd,Create },
                {TokenType.ALTER_cmd,Alter },
                {TokenType.DROP_cmd,Drop }
            };

            Conditional = new Dictionary<TokenType, ParserFunction>()
            {
                {TokenType.WHERE_KW,Where },
                {TokenType.OUTER_KW,JOIN },
                {TokenType.INNER_KW,JOIN },
                {TokenType.LEFT_KW,JOIN },
                {TokenType.RIGHT_KW,JOIN },
            };
        }


        private Node JOIN()
        {
            /*   
            Node ━━━ Join Type
                ┃┗━  JOIN ━ Table Name
                ┗━━  ON   ━ Condition
            */
            Node N = new Node(Read);
            Match(Peak, TokenType.JOIN_KW);
            N.Children.Add(new Node(Read));
            N.Children.Add(new Node(Read));
            if (Peak.Type == TokenType.ON_KW)
                N.Children.Add(RelationshipON());
            return N;
        }

        private Node RelationshipON()
        {
            Node N = new Node(Read);
            Node Expression = new Node(new Token("", TokenType.Composite));
            Expression.Children.Add(new Node(Read));
            Match(Peak, TokenType.Equal);
            Expression.Children.Add(new Node(Read));
            Expression.Children.Add(new Node(Read));
            N.Children.Add(Expression);
            return N;
        }

        int currentToken = 0;

        bool End
        {
            get
            {
                return currentToken >= Path.Count;
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

        public QueryTree Reorder()
        {
            QueryTree PostProcess = new QueryTree();

            while (currentToken < Subject.QueryTokens.Count && Peak.Type!=TokenType.SemiColon)
            {
                if (Parsers.ContainsKey(Subject.QueryTokens[currentToken].Type))
                {
                    PostProcess.Root=Parsers[Subject.QueryTokens[currentToken].Type]();
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
                case TokenType.COLUMN:
                    N.Children.Add(new Node(Match(Read, TokenType.Identifier_Key)));
                    Match(Read, TokenType.SemiColon);
                    break;
            }
            return N;
        }

        private Node Alter()
        {
            /* 
                Alter--TableKeyword---Identifier   [0]
                     \__ADD/ALTER/DROP/RENAME      [1]
            */
            Node N = new Node(Read);

            Match(Peak, TokenType.TABLE_KW);
            N.Children.Add(new Node(Read));

            N.Children.Last().Children.Add(new Node(Match(Read, TokenType.Identifier_Table)));

            switch (Peak.Type)
            {
                case TokenType.ADD_KW:
                    N.Children.Add(Add());
                    break;
                case TokenType.ALTER_cmd:
                    N.Children.Add(Modify());
                    break;
                case TokenType.DROP_cmd:
                    N.Children.Add(Drop());
                    break;
                case TokenType.RENAME_cmd:
                    N.Children.Add(Rename());
                    break;
            }

            return N;
        }

        private Node Rename()
        {
            Node N = new Node(Read);
            if (Peak.Type == TokenType.Identifier_Key)
                N.Children.Add(new Node(Read));
            Match(Peak, TokenType.TO_KW);
            N.Children.Add(new Node(Read));
            N.Children.Add(new Node(Read));
            return N;
        }

        private Node Add()
        {
            Node Pair = new Node(new Token("", TokenType.Composite));
            Pair.Children.Add(new Node(Match(Read, TokenType.Identifier_Key)));
            Pair.Children.Add(new Node(Match(Read, TokenType.DATATYPE)));
            return Pair;
        }

        private Node Modify()
        {
            Match(Read, TokenType.COLUMN);
            Node Pair = new Node(new Token("", TokenType.Composite));
            Pair.Children.Add(new Node(Match(Read, TokenType.Identifier_Key)));
            Pair.Children.Add(new Node(Match(Read, TokenType.DATATYPE)));
            return Pair;
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
                        if (Peak.Type != TokenType.RBracket)
                            Match(Read, TokenType.Comma);
                        N.Children.Add(Pair);
                    }
                    Match(Read, TokenType.RBracket);
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
            Match(Peak, TokenType.FROM_KW);
            N.Children.Add(From());

            if (Peak.Type == TokenType.WHERE_KW)
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
            if (Peak.Type == TokenType.WHERE_KW)
                N.Children.Add(Where());
            return N;
        }

        private Node SetParse()
        {
            Node N = new Node(new Token(Peak.TokenData, Peak.Type));
            while (currentToken < Path.Count)
            {
                Node tmp = new Node(new Token("", TokenType.Composite));
                currentToken++;

                tmp.Children.Add(new Node(Match(Read, TokenType.Identifier_Key)));
                Match(Read, TokenType.Equal);
                tmp.Children.Add(new Node(Match(Read, TokenType.Immediate_value)));
                N.Children.Add(tmp);

                if (Peak.Type != TokenType.WHERE_KW && Peak.Type != TokenType.SemiColon)
                    Match(Peak, TokenType.Comma);
                else
                    break;
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

            while(currentToken < Path.Count)
            {
                Match(Peak, TokenType.Identifier_Key);
                N.Children.Last().Children.Add(new Node(Read));
                
                if (currentToken < Path.Count - 1)
                {
                    if (Path[currentToken].Type == TokenType.RBracket)
                        break;
                    Match(Path[currentToken], TokenType.Comma);
                    currentToken++;
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
            Match(Read, TokenType.LBracket);
            while(currentToken < Path.Count)
            {
                Match(Peak, TokenType.Immediate_value);
                N.Children.Add(new Node(Read));
                if (Peak.Type == TokenType.RBracket)
                {
                    currentToken++;
                    break;
                }
                Match(Read, TokenType.Comma);
            }
            return N;
        }

        private Node Where()
        {
            /*   
            Node ━━━ Where
                ┃┗━  BooleanExpression ━ ORed Boolean Expression
                ┗━━  ANDed Boolean Expression   ━ Ored Boolean Expression
            */

            Node N = new Node(Read);
            
            while (currentToken < Path.Count)
            {
                Node Expression = new Node(new Token("", TokenType.Composite));
                Expression.Children.Add(new Node(Read));
                Expression.Children.Add(new Node(Read));
                Expression.Children.Add(new Node(Read));
                N.Children.Add(Expression);

                if (Peak.Type == TokenType.Boolean_OR)
                    WhereRecursive(N.Children.Last());
                else if (Peak.Type == TokenType.Boolean_And)
                    currentToken++;
                else
                    break;

                if (Peak.Type == TokenType.SemiColon)
                    break;
            }
            return N;
        }

        private void WhereRecursive(Node N)
        {
            N.Children.Add(new Node(new Token("", TokenType.Composite)));
            N = N.Children.Last();
            currentToken++;
            while (currentToken < Path.Count)
            {
                Node Expression = new Node(new Token("", TokenType.Composite));
                Expression.Children.Add(new Node(Read));
                Expression.Children.Add(new Node(Read));
                Expression.Children.Add(new Node(Read));
                N.Children.Add(Expression);

                if (Peak.Type == TokenType.Boolean_OR)
                    WhereRecursive(Expression);
                else if (Peak.Type == TokenType.Boolean_And)
                    currentToken++;
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

            /*   
                                      *
                                    /
            Node ━━━ Keys ━━━━━ Identifier
                                    \  Tablename.Identifier
                ┃┗  JOIN ━ Table Name
                ┗━  ON   ━ Condition
            */

            Node N = new Node(Read);
            Node Keys = new Node(new Token("",TokenType.Composite));
            if (Peak.Type != TokenType.Closure)
                for (; currentToken < Path.Count; currentToken++)
                {
                    if (Peak.Type == TokenType.Identifier_Table)
                    {
                        Keys.Children.Add(new Node(new Token("", TokenType.Composite)));
                        Keys.Children.Last().Children.Add(new Node(Read));
                        Match(Read, TokenType.Dot);
                        Match(Peak, TokenType.Identifier_Key);
                        Keys.Children.Last().HostedToken.TokenData = Peak.TokenData;
                    }
                    else
                    {
                        Match(Peak, TokenType.Identifier_Key);
                        Keys.Children.Add(new Node(Read));
                    }

                    if (currentToken < Path.Count &&
                         Peak.Type != TokenType.Comma)
                    {
                        Match(Peak, TokenType.FROM_KW);
                        break;
                    }
                }
            else
                Keys.Children.Add(new Node(Read));

            N.Children.Add(Keys);
            N.Children.Add(From());

            while (Conditional.ContainsKey(Peak.Type))
            {
                N.Children.Add(Conditional[Peak.Type]());
            }
            return N;
        }
    }
}
