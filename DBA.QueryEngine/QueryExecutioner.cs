using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBA.Structure;
using DBA.Refrences;

namespace DBA.QueryEngine
{
    public class QueryExecutioner
    {
        string Result = "";

        public delegate Table Executive(Node Root);

        static Dictionary<TokenType, Executive> Execs;

        List<Key> KeyIDs = new List<Key>();
        List<int> KeyCodes = new List<int>();
        List<Table> Tables = new List<Table>();
        List<int> Filter = new List<int>();

        QueryTree Query;
        Database Target;

        public QueryExecutioner(QueryTree Q_Entry, Database DB)
        {
            Query = Q_Entry;
            Target = DB;
            Execs = new Dictionary<TokenType, Executive>()
            {
                {TokenType.SELECT_cmd,Select },
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

        private Table Select(Node Root)
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
                    KeyIDs.Add(Kt);
                }
            if (Root.Children.Count == 3) { Where(Root.Children[2]); }
            Table Response = new Table("Query Response");
            List<int> KIndices = new List<int>();
            foreach (Key Ki in KeyIDs)
            {
                Response.Keys.Add(new Key(Ki,true));
                KIndices.Add(Tables.Last().getKeyIndex(Ki.Name));
            }

            for (int i=0;i<Filter.Count;i++)
            {
                List<byte[]> Record = Tables.Last().RetrieveRecord(KIndices, i);
                Response.AppendRecord(Enumerable.Range(0,KIndices.Count).ToList(), Record);
            }
            return Response;
        }

        private Dictionary<char, int> ComparisonDecoder = new Dictionary<char, int>()
        {
            { '<' ,-1  },
            { '>' , 1  },
            { '=' , 0  }
        };

        private class Comparison
        {
            public Token Condition;
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

            public int Capacity
            {
                get
                {
                    return K1.DATA.Count;
                }
            }

            public DATATYPE Datatype
            {
                get
                {
                    return K1.Type;
                }
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

        public Table ExecuteQuery()
        {
            return Execs[Query.Root.HostedToken.Type](Query.Root);
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
                PartialFilters=AndCombine(PartialFilters,WhereSearch(CompileComparison(N)));

            Filter = PartialFilters;
        }

        private List<int> WhereSearch(Comparison C)
        {
            List<int> Filter = new List<int>();
            
            for (int i1 = 0, i2 = 0;i1<C.Capacity;i1++)
            {
                if (Datatypes.CompareFunctions[C.Datatype](C.K1.DATA[i1], C.K2.DATA[i2])==ComparisonDecoder[C.Condition.TokenData[0]])
                {
                    Filter.Add(i1);
                }
                else if (C.hasChildCondition)
                {
                    if (WhereSearch(C.ChildCondition, i1))
                    {
                        Filter.Add(i1);
                    }
                }
            }
            return Filter;
        }

        private bool WhereSearch(Node Ni, int index)
        {
            bool allTrue = true;
            foreach (Node Ci in Ni.Children)
            {
                Comparison C = CompileComparison(Ci);
                int i1 = index, i2 = C.Immediate ? 0 : index;
                if (Datatypes.CompareFunctions[C.Datatype](C.K1.DATA[i1], C.K2.DATA[i2]) == ComparisonDecoder[C.Condition.TokenData[0]])
                {
                    continue;
                }
                else if (C.hasChildCondition)
                {
                    if (WhereSearch(C.ChildCondition, i1))
                    {
                        continue;
                    }
                }
                allTrue = false;
            }
            return allTrue;
        }

        private List<int> AndCombine(List<int> a,List<int> b)
        {
            List<int> Combined = new List<int>();
            for (int i1=0,i2=0;i1<a.Count && i2<b.Count;)
            {
                if (a[i1] == b[i2])
                {
                    Combined.Add(a[i1]);
                    i1++;
                    i2++;
                }
                else if (a[i1] < b[i2])
                    i1++;
                else if (a[i1] > b[i2])
                    i2++;
            }
            return Combined;
        }

        private Table Insert(Node Root)
        {
            throw new NotImplementedException();
        }

        private Table Update(Node Root)
        {
            throw new NotImplementedException();
        }

        private Table Delete(Node Root)
        {
            throw new NotImplementedException();
        }

        private Table Create(Node Root)
        {
            throw new NotImplementedException();
        }

        private Table Alter(Node Root)
        {
            throw new NotImplementedException();
        }
    }
}
