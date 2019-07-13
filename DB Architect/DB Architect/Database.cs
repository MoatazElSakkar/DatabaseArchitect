using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace DB_Architect
{
    class Database
    {
        public string Name
        {
            get;
            set;
        }

        public bool Charted = false;

        public int Tables
        {
            get;
            set;
        }

        public int Seek
        {
            get;
            set;
        }

        public int SeekEnd
        {
            get;
            set;
        }

        public List<Table> TBS = new List<Table>();

    }
}
