using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBA.Refrences;

namespace DBA.QueryEngine
{
    public enum TokenType
    {
        Composite,

        DATATYPE,                 //INT,BYTE ETC
        Immediate_value,          //Immediate Value

        SELECT_cmd,               //SELECT
        DISTINCT_KW,              //DISTINCT
        FROM_KW,                  //FROM
        WHERE_KW,                 //WHERE
        INSERT_cmd,               //INSERT
        INTO_KW,                  //Into
        VALUES_KW,                //VALUES
        UPDATE_cmd,               //UPDATE
        SET_cmd,                  //SET
        DELETE_cmd,               //DELETE
        CREATE_cmd,               //DELETE
        DROP_cmd,                 //DROP
        ALTER_cmd,                //ALTER
        TABLE_KW,                 //TABLE
        DATABASE_KW,              //DATABASE
        KEY_KW,                   //KEY
        ADD_KW,                   //ADD
        RENAME_cmd,               //RENAME

        COLUMN,                   //Structure Column

        LBracket,                 //(
        RBracket,                 //)

        Identifier_Table,        //Table Name
        Identifier_Key,          //Key Name
        Identifier_DB,           //DB NAME
        Identifier_Col,          //Column Name

        Boolean_OR,              //OR
        Boolean_And,             //AND
        Boolean_Not,             //NOT

        Comma,                   // ','
        Closure,                 // '*'
        SemiColon,               // ';'
        SingleQuote,             // '''
        DoubleQuote,             // '"'
                               
        Addition,                // '+'
        Subtraction,             // '-'
        Division,                // '/'
        Multiplication,          // '*'
        Equal,                   // '='
                               
        GreaterThan,             // '>'
        LessThan,                 // '<'

    }

    public class Token
    {
        public TokenType Type;
        public string TokenData;
        public Token(string Data, TokenType T)
        {
            Type = T;
            TokenData = Data;
        }
    }
    public class QueryScanner
    {
        static Dictionary<string, TokenType> OpRefrence = new Dictionary<string, TokenType>()
        {
                {"OR",TokenType.Boolean_OR    },        //OR
                {"AND",TokenType.Boolean_And  },        //AND
                {"NOT",TokenType.Boolean_Not  },        //NOT

                {",",TokenType.Comma          },        // ''
                {"*",TokenType.Closure        },        // '*'
                //{";",TokenType.SemiColon      },        // ';'
                //{"\'",TokenType.SingleQuote   },        // '''
                //{"\"",TokenType.DoubleQuote   },        // '"'

                {"+",TokenType.Addition       },        // '+'
                {"-",TokenType.Subtraction    },        // '-'
                {"/",TokenType.Division       },        // '/'
                {"x",TokenType.Multiplication },        // '*'
                {"=",TokenType.Equal },                 // '='

                {">",TokenType.GreaterThan    },        // '>'
                {"<",TokenType.LessThan       },         // '<'
                {"(",TokenType.LBracket       },        // '<'
                {")",TokenType.RBracket       },         // '<'
        };

        char[] delimiters = {' ','\t','\n','\r',';'};

        public delegate void ParserFunction(List<Token> Path, string Literal);

        static Dictionary<string, ParserFunction> Parsers;
        

        int currentLocation = 0;

        char Current
        {
            get
            {
                if (Subject.Literal.Length > currentLocation)
                    return Subject.Literal[currentLocation];
                else
                    return '\0';
            }
        }

        bool EndOfText
        {
            get
            {
                return currentLocation >= Subject.Literal.Length;
            }
        }

        string getToken()
        {
            string bufferText = "";

            if (EndOfText)
            {
                throw new Exception("End of file was found before proper termination");
            }
            else if (Current==';')
            {
                return ";";
            }

            while (delimiters.Contains(Current)) { currentLocation++; }
            if (OpRefrence.ContainsKey(Current.ToString()))
            {
                bufferText += Current;
                currentLocation++;
                return bufferText;
            }

            bool Literal = (Current == '\"');
            if (Literal) { currentLocation++; }
            bool Escape = false;

            while (!EndOfText &&
                //Text didn't end                                         
                (!delimiters.Contains(Current)||Literal) &&
                //Didn't encounter a delimiter or scanning a literal ""
                (!OpRefrence.ContainsKey(Current.ToString())||Literal) &&
                //Didn't encounter an operator or scanning a literal "", used for cases like x=5
                (!Literal || Current!='\"') || Escape)
                //This condition is only activated when literal is then it returns Current!='\"' else true
            {
                Escape = (Current == '\\') && !Escape; //used to ignore what's after a \ even if it's a \
                bufferText += Current;
                currentLocation++;
            }
            if (Literal) { currentLocation++; }
            return bufferText;
        }

        Query Subject;

        public QueryScanner(Query Q)
        {
            Subject = Q;
            Parsers = new Dictionary<string, ParserFunction>()
            {
                {"SELECT",Select },
                {"FROM",From },
                {"WHERE",Where },
                {"INSERT",Insert },
                {"UPDATE",Update },
                {"DELETE",Delete },
                {"CREATE",Create },
                {"ALTER",Alter },
                {"DROP",Drop }
            };
        }

        private void Drop(List<Token> Path, string Literal)
        {
            throw new NotImplementedException();
        }

        private void Alter(List<Token> Path, string Literal)
        {
            Path.Add(new Token(Literal, TokenType.ALTER_cmd));

            string Token = getToken();

            switch (Token.ToUpper())
            {
                case "DATABASE":
                    Path.Add(new Token(Token, TokenType.DATABASE_KW));
                    Token = getToken();
                    AlterDB(Path, Token);
                    return;
                case "TABLE":
                    Path.Add(new Token(Token, TokenType.TABLE_KW));
                    Token = getToken();
                    AlterTable(Path, Token);
                    break;
                default:
                    //register inconsistency
                    break;
            }

        }

        private void AlterDB(List<Token> Path, string Literal)
        {
            Path.Add(new Token(Literal, TokenType.Identifier_DB));
            //Research Required
        }

        private void AlterTable(List<Token> Path, string Literal)
        {
            Path.Add(new Token(Literal, TokenType.Identifier_Table));
            string Token = getToken();
            switch(Token.ToUpper())
            {
                case "ADD":
                    Path.Add(new Token(Literal, TokenType.ADD_KW));
                    Token = getToken();
                    Path.Add(new Token(Literal, TokenType.Identifier_Key));
                    Token = getToken();
                    Path.Add(new Token(Literal, TokenType.DATATYPE));
                    break;
                case "DROP":
                    Path.Add(new Token(Literal, TokenType.ADD_KW));
                    Token = getToken();
                    Path.Add(new Token(Literal, TokenType.Identifier_Key));
                    break;
                case "ALTER":
                    Path.Add(new Token(Literal, TokenType.ALTER_cmd));
                    Token = getToken();
                    if (Token.ToUpper() != "COLUMN") {/*Register Inconsistency*/ return; }
                    AlterColumn(Path, Token);
                    break;
                case "RENAME":
                    Path.Add(new Token(Literal, TokenType.RENAME_cmd));
                    Token = getToken();
                    if (Token.ToUpper() != "COLUMN") {/*Register Inconsistency*/ return; }
                    RenameColumn(Path, Token);
                    break;
                default:
                    //Register Inconsistency
                    break;

            }

        }

        private void RenameColumn(List<Token> Path, string Literal)
        {
            Path.Add(new Token(Literal, TokenType.COLUMN));

            string Token = getToken();
            Path.Add(new Token(Token, TokenType.Identifier_Key));

            Token = getToken();
            Path.Add(new Token(Token, TokenType.Identifier_Key));
        }

        private void AlterColumn(List<Token> Path, string Literal)
        {
            Path.Add(new Token(Literal, TokenType.COLUMN));

            string Token = getToken();
            Path.Add(new Token(Token, TokenType.Identifier_Key));

            Token = getToken();
            Path.Add(new Token(Token, TokenType.DATATYPE));
        }

        private void Create(List<Token> Path, string Literal)
        {
            Path.Add(new Token(Literal, TokenType.CREATE_cmd));
            string Token = getToken();

            switch(Token.ToUpper())
            {
                case "DATABASE":
                    Path.Add(new Token(Token, TokenType.DATABASE_KW));
                    Token = getToken();
                    Path.Add(new Token(Token, TokenType.DATABASE_KW));
                    return;
                case "TABLE":
                    Path.Add(new Token(Token, TokenType.TABLE_KW));
                    Token = getToken();
                    Path.Add(new Token(Token, TokenType.Identifier_Table));
                    break;
                default:
                    //register inconsistency
                    break;
            }

            Token = getToken();
            if (Token!="(")
            {
                throw new Exception("( Expected but " + Token + " encountered");
            }
            Path.Add(new Token("(", TokenType.LBracket));
            Token = getToken();
            while (Token != ")" && !EndOfText)
            {
                Path.Add(new Token(Token, TokenType.Identifier_Key));
                Token = getToken();
                if (!Datatypes.Datatype_str.Keys.Contains(Token.ToUpper()))
                {
                    throw new Exception("Datatype invalid");
                }
                Path.Add(new Token(Token, TokenType.DATATYPE));
                Token = getToken();
                if (Token == ",")
                    Path.Add(new Token(Token, TokenType.Comma));
                else if (Token == ")")
                    break;


                Token = getToken();
            }
            if (EndOfText) { throw new Exception("End of file encountered prematurly"); }
            Path.Add(new Token(")", TokenType.RBracket));
            Token = getToken();
            if (Token!=";")
            {
                throw new Exception("Ivalid termination");
            }
        }

        private void Delete(List<Token> Path, string Literal)
        {
            Path.Add(new Token(Literal, TokenType.DELETE_cmd));
            string Token = getToken();

            if (Token.ToUpper()=="FROM"){From(Path,Token);}
            else
            {
                //register Inconsistency
                return;
            }

            Token = getToken();
            if (Token.ToUpper() == "WHERE"){Where(Path, Token);}
            else
            {
                //register warning!
                return;
            }

        }

        private void Update(List<Token> Path, string Literal)
        {
            Path.Add(new Token(Literal, TokenType.UPDATE_cmd));

            string Token = getToken();
            Path.Add(new Token(Token, TokenType.Identifier_Table));

            Token = getToken();
            if (Token.ToUpper()!="SET")
            {
                throw new Exception("Keyword unrecognized, SET Expected");
            }
            Path.Add(new Token(Token, TokenType.SET_cmd));

            while(!EndOfText)
            {
                Token = getToken();
                if (Token==",")
                {
                    Path.Add(new Token(Token, TokenType.Comma));
                    continue;
                }
                else if (Token.ToUpper() == "WHERE" || Token==";") { break; }
                
                Path.Add(new Token(Token, TokenType.Identifier_Key));

                Token = getToken();
                if (Token!="=")
                {
                    throw new Exception("Unrecognized operator, \'=\' Expected");
                }
                Path.Add(new Token(Token, TokenType.Equal));

                Token = getToken();
                Path.Add(new Token(Token, TokenType.Immediate_value));
            }

            if (Token.ToUpper()=="WHERE")
            {
                Where(Path,Token);
            }
            else if (Token==";")
            {
                return;
            }
        }

        private void Insert(List<Token> Path, string Literal)
        {
            Path.Add(new Token(Literal, TokenType.INSERT_cmd));
            string Token = getToken();
            if (Token.ToUpper()!="INTO")
            {
                throw new Exception("Expected keyword INTO");
            }
            Path.Add(new Token(Token, TokenType.INTO_KW));

            Token = getToken();
            Path.Add(new Token(Token, TokenType.Identifier_Table));

            Token = getToken();
            if (Token == "(")
            {
                Path.Add(new Token(Token, TokenType.LBracket));
                Token = getToken();
                if (Token != ")")
                    while (true)
                    {
                        if (Token == ",")
                            Path.Add(new Token(Token, TokenType.Comma));
                        else if (Token == ")")
                            break;
                        else
                           Path.Add(new Token(Token, TokenType.Identifier_Key));

                        Token = getToken();
                    }
                Path.Add(new Token(Token, TokenType.RBracket));
                Token = getToken();
            }

            if (Token.ToUpper()!="VALUES")
            {
                //Register Inconsistency
            }
            else
            {
                Values(Path, Token);
            }
        }

        void Values(List<Token> Path, string Literal)
        {
            Path.Add(new Token(Literal, TokenType.VALUES_KW));
            string Token = getToken();
            if (Token != "(")
            {/*Register Inconsistency*/ }
            else
            {
                Path.Add(new Token(Token, TokenType.LBracket));
                Token = getToken();
                while (true)
                {
                    if (Token == ",")
                        Path.Add(new Token(Token, TokenType.Comma));
                    else if (Token == ")")
                        break;
                    else
                        Path.Add(new Token(Token, TokenType.Immediate_value));
                    Token = getToken();
                }
                Path.Add(new Token(Token, TokenType.RBracket));
            }
        }

        public Query Scan()
        {
            Query Q = new Query();
            Q.QueryTokens = new List<Token>();

            while (Current != ';' && !EndOfText)
            {
                while (delimiters.Contains(Current)) { currentLocation++; }
                string Command = getToken().ToUpper();
                if (!Parsers.ContainsKey(Command))
                {
                    /*RegisterInconsistency*/
                    continue;
                }
                Parsers[Command](Q.QueryTokens, Command);
            }
            Q.QueryTokens.Add(new Token(";", TokenType.SemiColon));
            return Q;
        }

        void Select(List<Token> Path,string Literal)
        {
            Path.Add(new Token(Literal, TokenType.SELECT_cmd));
            string Token = getToken();
            if (Token=="*")
            {
                Path.Add(new Token(Token, TokenType.Closure));
                Token = getToken();
            }
            else if (!Parsers.ContainsKey(Token.ToUpper()))
                while (true)
                {
                    Path.Add(new Token(Token, TokenType.Identifier_Key));
                    Token = getToken();

                    if (Token == ",")
                    {
                        Path.Add(new Token(Token, TokenType.Comma));
                        Token = getToken();
                        continue;
                    }
                    else if (Parsers.ContainsKey(Token.ToUpper())) { break; }
                    else { throw new Exception("Unexpected lexim encountered"); }
                }
            Parsers[Token.ToUpper()](Path, Token);
        }

        void From(List<Token> Path, string Literal)
        {
            Path.Add(new Token(Literal, TokenType.FROM_KW));
            string Token = getToken();
            Path.Add(new Token(Token, TokenType.Identifier_Table));
            return;
        }

        bool Numeric(string subject)
        {
            foreach (char c in subject)
            {
                if (c > '9' || c < '0' || c=='.')
                    return false;
            }
            return true;
        }

        void Where(List<Token> Path, string Literal)
        {
            Path.Add(new Token(Literal, TokenType.WHERE_KW));
            string Token = "";
            while (true)
            {
                Token = getToken();
                if (OpRefrence.ContainsKey(Token.ToUpper()))
                {
                    Path.Add(new Token(Token.ToUpper(), OpRefrence[Token.ToUpper()]));
                    Token = getToken();
                }
                else if (Token==";")
                {
                    break;
                }
                else if (Token=="") { throw new Exception("End of file was encountered before semicolon \';\'"); }
                Path.Add(new Token(Token, TokenType.Identifier_Key));

                Token = getToken();
                Path.Add(new Token(Token, OpRefrence[Token]));

                Token = getToken();
                Path.Add(new Token(Token, TokenType.Immediate_value));
            }
        }
    }
}
