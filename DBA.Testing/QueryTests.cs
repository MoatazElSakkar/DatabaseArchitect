using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBA.QueryEngine;

namespace DBA.Testing
{
    [TestClass]
    public class QueryTests
    {
        [TestMethod]
        public void SELECT1()
        {
            Query Q = new Query("SELECT * FROM Projects WHERE Rating=90 or Name=\"DatabaseArchitect\";");
            QueryScanner QS = new QueryScanner(Q);
            Q=QS.Scan();
            QueryParser QP = new QueryParser(Q);
            QueryTree QT=QP.Reorder();   
        }

        [TestMethod]
        public void SELECTAndTree()
        {
            Query Q = new Query("SELECT PrName,Rating FROM Projects WHERE Rating=90 or Name=\"DatabaseArchitect\" and Rating>80;");
            QueryScanner QS = new QueryScanner(Q);
            Q = QS.Scan();
            QueryParser QP = new QueryParser(Q);
            QueryTree QT = QP.Reorder();
        }

        [TestMethod]
        public void InsertTest1()
        {
            Query Q = new Query("Insert Into Projects(ID,Name,Rating) Values(1,\"Database Architect\",99);");
            QueryScanner QS = new QueryScanner(Q);
            Q = QS.Scan();
            QueryParser QP = new QueryParser(Q);
            QueryTree QT = QP.Reorder();
        }

        [TestMethod]
        public void UpdateTest()
        {
            Query Q = new Query("UPDATE Projects SET ID=1, Name=\"Database Architect\", Rating=100 WHERE ID=1;");
            QueryScanner QS = new QueryScanner(Q);
            Q = QS.Scan();
            QueryParser QP = new QueryParser(Q);
            QueryTree QT = QP.Reorder();
        }

        [TestMethod]
        public void UpdateTest2()
        {
            TokenType[] Tokens = {TokenType.UPDATE_cmd,TokenType.Identifier_Table,TokenType.SET_cmd,
                TokenType.Identifier_Key,TokenType.Equal,TokenType.Immediate_value,
                TokenType.Comma,TokenType.Identifier_Key,TokenType.Equal,
                TokenType.Immediate_value,TokenType.Comma,TokenType.Identifier_Key,
                TokenType.Equal,TokenType.Immediate_value,TokenType.SemiColon};
            Query Q = new Query("UPDATE Projects SET ID=1, Name=\"Database Architect\", Rating=100;");
            QueryScanner QS = new QueryScanner(Q);
            Q = QS.Scan();
            Assert.AreEqual(Q.QueryTokens.Count, Tokens.Count());
            for (int i=0;i<Q.QueryTokens.Count;i++)
            {
                if (Q.QueryTokens[i].Type!=Tokens[i])
                {
                    throw new Exception("Scanner logic failure");
                }
            }
            QueryParser QP = new QueryParser(Q);
            QueryTree QT = QP.Reorder();
        }

        [TestMethod]
        public void DeleteTest()
        {
            TokenType[] Tokens = {TokenType.DELETE_cmd, TokenType.FROM_KW, TokenType.Identifier_Table,
            TokenType.WHERE_KW,TokenType.Identifier_Key,TokenType.LessThan,TokenType.Immediate_value,TokenType.SemiColon};
            Query Q = new Query("Delete FROM Projects WHERE Rating<50;");
            QueryScanner QS = new QueryScanner(Q);
            Q = QS.Scan();
            Assert.AreEqual(Q.QueryTokens.Count, Tokens.Count());
            for (int i = 0; i < Q.QueryTokens.Count; i++)
            {
                if (Q.QueryTokens[i].Type != Tokens[i])
                {
                    throw new Exception("Scanner logic failure, Expected "+Tokens[i].ToString() + "recieved " + Q.QueryTokens[i].Type.ToString());
                }
            }
            QueryParser QP = new QueryParser(Q);
            QueryTree QT = QP.Reorder();
        }


        [TestMethod]
        public void CreateTest()
        {
            TokenType[] Tokens = {TokenType.CREATE_cmd, TokenType.TABLE_KW, TokenType.Identifier_Table,TokenType.LBracket, TokenType.Identifier_Key,
                TokenType.DATATYPE,TokenType.Comma,TokenType.Identifier_Key,TokenType.DATATYPE,TokenType.Comma,TokenType.Identifier_Key,
                TokenType.DATATYPE,TokenType.RBracket,TokenType.SemiColon};
            Query Q = new Query("CREATE TABLE Projects(ID int32,Name string,Rating int32);");
            QueryScanner QS = new QueryScanner(Q);
            Q = QS.Scan();
            Assert.AreEqual(Q.QueryTokens.Count, Tokens.Count());
            for (int i = 0; i < Q.QueryTokens.Count; i++)
            {
                if (Q.QueryTokens[i].Type != Tokens[i])
                {
                    throw new Exception("Scanner logic failure, Expected " + Tokens[i].ToString() + "recieved " + Q.QueryTokens[i].Type.ToString());
                }
            }
            QueryParser QP = new QueryParser(Q);
            QueryTree QT = QP.Reorder();
        }
    }
}
