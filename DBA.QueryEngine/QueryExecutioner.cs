using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBA.Structure;
using DBA.Refrences;

namespace DBA.QueryEngine
{
    class QueryExecutioner
    {
        string Result = "";

        public delegate void Execution(Node Root);

        static Dictionary<TokenType, Execution> Parsers;

        List<Key> KeyIDs = new List<Key>();
        List<Table> Tables = new List<Table>();
        List<int> Filter = new List<int>();

        QueryTree Query;
        Database Target;

        public QueryExecutioner(QueryTree Q_Entry, Database DB)
        {
            Query = Q_Entry;
            Target = DB;
            Parsers = new Dictionary<TokenType, Execution>()
            {
                {TokenType.SELECT_cmd,Select },
                {TokenType.FROM_KW,From },
                {TokenType.INSERT_cmd,Insert },
                {TokenType.UPDATE_cmd,Update },
                {TokenType.DELETE_cmd,Delete },
                {TokenType.CREATE_cmd,Create },
                {TokenType.ALTER_cmd,Alter }
            };
        }

        private void From(Node Root)
        {
            Table T = Target.getTable(Root.Children[0].HostedToken.TokenData);
            if (T==null) {
                throw new Exception("Designated table " + 
                    Root.Children[0].HostedToken.TokenData + 
                    " was not found");
            }
            Tables.Add(T);
        }

        private void Select(Node Root)
        {
            From(Root.Children[1]);
            if (Root.Children[0].Children.Count == 1 && Root.Children[0].Children[0].HostedToken.Type == TokenType.Closure)
                foreach (Key K in Tables[0].Keys)
                {
                    KeyIDs.Add(K);
                }
            else
                foreach (Node Child in Root.Children[0].Children)
                {
                    Key Kt = Tables[0].getKey(Child.HostedToken.TokenData);
                    if (Kt == null)
                    {
                        throw new Exception("Designated key " +
                            Child.HostedToken.TokenData +
                            " was not found");
                    }
                }
            if (Root.Children.Count == 3) { Where(Root.Children[2]); }
        }

        private Dictionary<char, int> ComparisonDecoder = new Dictionary<char, int>()
        {
            { '<' ,-1  },
            { '>' , 1  },
            { '=' , 0  }
        };

        private class Comparison
        {
            Token Condition;
            public Comparison(Key i1,Key i2,bool i, Token C)
            {
                K1 = i1;
                K2 = i2;
                Immediate = i;
                Condition = C;
            }

            public Comparison(Key i1, Key i2, bool i, Token C, Node Child)
            {
                K1 = i1;
                K2 = i2;
                Immediate = i;
                Condition = C;
                ChildCondition = Child;
            }

            public Key K1
            {
                get;
                set;
            }

            public Key K2
            {
                get;
                set;
            }

            public bool Immediate
            {
                get;
                set;
            }

            public bool hasChildCondition
            {
                get
                {
                    return ChildCondition!=null;
                }
            }
            public Node ChildCondition;
        }

        private Comparison CompileComparison(Node N)
        {
            Key ID = Tables.Last().getKey(N.Children[0].HostedToken.TokenData);
            Key ID2;
            bool Immediate = false;
            if (N.Children[2].HostedToken.Type == TokenType.Identifier_Key)
            {
                ID2 = Tables.Last().getKey(N.Children[2].HostedToken.TokenData);
            }
            //else if (ReservedValues.contains()) //*Future Work
            else
            {
                ID2 = new Key("~TEMP", ID.Type, ID.Constraint);
                ID2.AddRecord(Datatypes.ConverterFunctions[ID.Type](N.Children[2].HostedToken.TokenData));
                Immediate = true;
            }
            if (N.Children.Count>3)
                return new Comparison(ID, ID2, Immediate, N.Children[1].HostedToken,N.Children[3]);
            return new Comparison(ID, ID2,Immediate, N.Children[1].HostedToken);
        }

        private void Where(Node Root)
        {
            List<int> PartialFilters = new List<int>();
            PartialFilters = Enumerable.Range(0, Tables.Last().Records).ToList();

            foreach (Node N in Root.Children)
            {
                PartialFilters=AndCombine(PartialFilters,WhereSearch(CompileComparison(N)));
            }
        }

        private List<int> WhereSearch(Comparison C)
        {
            throw new NotImplementedException();
            //List<int> Filter = Enumerable.Range(0, K1.DATA.Count).ToList();

            //Note to self **IMPORTANT** When ORING create a single descent function
            //compare with child compare only with a wheresearch recurse
 
        }

        private List<int> AndCombine(List<int> a,List<int> b)
        {
            throw new NotImplementedException();
        }

        private void Insert(Node Root)
        {
            throw new NotImplementedException();
        }

        private void Update(Node Root)
        {
            throw new NotImplementedException();
        }

        private void Delete(Node Root)
        {
            throw new NotImplementedException();
        }

        private void Create(Node Root)
        {
            throw new NotImplementedException();
        }

        private void Alter(Node Root)
        {
            throw new NotImplementedException();
        }

        public Table ExecuteQuery(Node Root)
        {
            Table Tableu = new Table("Query output");



            return Tableu;
        }
    }
}
