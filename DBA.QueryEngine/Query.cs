using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBA.QueryEngine
{
    public class Query
    {
        bool parsed = false;

        public List<Token> QueryTokens;

        bool isParsed
        {
            get
            {
                return parsed;
            }
        }

        public string Literal
        {
            get;
            set;
        }
        public Query(string LiteralQuery)
        {
            Literal = LiteralQuery;
        }

        public Query()
        {
            parsed = true;
        }
    }
}
