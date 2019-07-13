
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DB_Architect
{
    class Server
    {
        public string ServerName { get; set; }
        public string Password { get; set; }
        public string ServerFile { get; set; }
        public int Databases { get; set; }

        public bool Charted
        {
            get;
            set;
        }

        public List<Database> DBS = new List<Database>();

        public string Name
        {
            get;
            set;
        }

        public int DBC
        {
            get;
            set;
        }
    }
}
