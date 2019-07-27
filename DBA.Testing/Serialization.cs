using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBA.Structure;
using DBA_Server_Test;
using DBA.QueryEngine;

namespace DBA.Testing
{
    [TestClass]
    public class Serialization
    {
        [TestMethod]
        public void DatabaseDeserializing()
        {
            Database DB = new Database(@"C:\Users\Moataz\Workspace\Software\Database Architect\Active Code\DatabaseArchitect\Southwind\Database.db.txt");
            DB.Read();
            foreach (Table Tb in DB.Tables)
            {
                Tb.ReadRecords();
            }
        } 
    }
}
