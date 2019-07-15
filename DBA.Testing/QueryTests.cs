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
            Query Q = new Query("UPDATE Projects SET ID=1, Name=\"Database Architect\", Rating=100;");
            QueryScanner QS = new QueryScanner(Q);
            Q = QS.Scan();
            QueryParser QP = new QueryParser(Q);
            QueryTree QT = QP.Reorder();
        }
    }
}
