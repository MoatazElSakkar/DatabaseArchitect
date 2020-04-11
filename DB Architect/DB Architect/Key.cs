using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DB_Architect
{
    public class Key
    {
        public string Name;
        public bool Primary;
        public string Type;
        public bool Unique;
        public int Max;
        public int Min;

        public List<string> Records=new List<string>();

        public Key()
        {
        }

        public Key(string a, string C)
        {
            Name = a;
            Type = C;
        }

        public Key(string a)
        {
            Name = a; 
        }

    }
}
