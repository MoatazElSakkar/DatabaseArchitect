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
        public bool[] AfterEffect =
        {
            false,  //Deserialize database
            false,  //Deserialize Table structure
            false,  //Deserialize Table Records
            false   //Desireialize Index
        };
        public delegate void TouchTable(Table Tableu);
        public TouchTable Touch;

        public string Result = "";
        private class Comparison
        {
            public Token Condition;
            public Comparison(Key i1, Key i2, bool i, Token C)
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
                    return ChildCondition != null;
                }
            }
            public Node ChildCondition;
        }


        List<Key> KeyIDs = new List<Key>();
        List<int> KeyCodes = new List<int>();
        public List<Table> Tables = new List<Table>();
        List<int> Filter = new List<int>();

        QueryTree Query;
        Database database;


        public delegate Table Executive(Node Root);
        static Dictionary<TokenType, Executive> Execs;
        static Dictionary<TokenType, Executive> Joiners;
        static Dictionary<TokenType, Executive> Alters;
        static Dictionary<TokenType, Executive> Conditionals;
        public QueryExecutioner(QueryTree Q_Entry, Database DB,TouchTable t)
        {
            Touch = t;
            Query = Q_Entry;
            database = DB;
            Execs = new Dictionary<TokenType, Executive>()
            {
                {TokenType.SELECT_cmd,Select },
                {TokenType.INSERT_cmd,Insert },
                {TokenType.UPDATE_cmd,Update },
                {TokenType.DELETE_cmd,Delete },
                {TokenType.CREATE_cmd,Create },
                {TokenType.ALTER_cmd,Alter }
            };

            Joiners = new Dictionary<TokenType, Executive>()
            {
                {TokenType.INNER_KW,InnerJoin },
                {TokenType.OUTER_KW,OuterJoin },
                {TokenType.LEFT_KW,LeftJoin },
                {TokenType.RIGHT_KW,RightJoin },
            };

            Alters = new Dictionary<TokenType, Executive>()
            {
                {TokenType.ADD_KW, AlterAdd },
                {TokenType.DROP_cmd,AlterDrop },
                {TokenType.ALTER_cmd,AlterModify },
                {TokenType.RENAME_cmd,AltereName }
            };

            Conditionals = new Dictionary<TokenType, Executive>()
            {
                {TokenType.WHERE_KW, AlterAdd }
            };
        }

        private Table RightJoin(Node Root)
        {
            throw new NotImplementedException();
        }

        private Table LeftJoin(Node Root)
        {
            throw new NotImplementedException();
        }

        private Table OuterJoin(Node Root)
        {
            throw new NotImplementedException();
        }

        private Table InnerJoin(Node Root)
        {
            throw new NotImplementedException();
        }

        private void From(Node Root)
        {
            Table T = database.getTable(Root.Children[0].HostedToken.TokenData);
            if (T==null) {
                throw new Exception("Designated table " + 
                    Root.Children[0].HostedToken.TokenData + 
                    " was not found");
            }
            if (!T.Survayed)
                Touch(T);
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

            Filter = Enumerable.Range(0, Tables.Last().Records).ToList();

            for (int i = 2; i < Root.Children.Count; i++)
                if (Joiners.ContainsKey(Root.Children[i].HostedToken.Type))
                    Joiners[Root.Children[i].HostedToken.Type](Root.Children[i]);
                else if (Conditionals.ContainsKey(Root.Children[i].HostedToken.Type))
                    Conditionals[Root.Children[i].HostedToken.Type](Root.Children[i]);

            Table Response = new Table(Tables.Last().Name);
            Response.Records = Filter.Count;
            List<int> KIndices = new List<int>();
            foreach (Key Ki in KeyIDs)
            {
                Response.Keys.Add(new Key(Ki,true));
                KIndices.Add(Tables.Last().getKeyIndex(Ki.Name));
            }
            for (int i=0;i<Filter.Count;i++)
            {
                List<byte[]> Record = Tables.Last().RetrieveRecord(KIndices, Filter[i]);
                Response.AppendRecord(Enumerable.Range(0,KIndices.Count).ToList(), Record);
            }

            return Response;
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


        private Dictionary<char, int> ComparisonDecoder = new Dictionary<char, int>()
        {
            { '<' ,-1  },
            { '>' , 1  },
            { '=' , 0  }
        };
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
            From(Root.Children[0]);
            Dictionary<int, byte[]> Record = new Dictionary<int, byte[]>();

            for(int i =0;i<Root.Children[1].Children.Count;i++)
            {
                Key Ki = Tables.Last().getKey(Root.Children[1].Children[i].HostedToken.TokenData);
                int index= Tables.Last().getKeyIndex(Root.Children[1].Children[i].HostedToken.TokenData);
                Record.Add(index,
                    Datatypes.ConverterFunctions[Ki.Type](Root.Children[2].Children[i].HostedToken.TokenData));
            }
            Tables.Last().AppendRecord(Record);
            Result = "1 record appended";
            AfterEffect[1] = true;
            AfterEffect[2] = true;
            return null;
        }

        private Table Update(Node Root)
        {
            From(Root);
            if (Root.Children.Count > 2) { Where(Root.Children[2]); }
            Dictionary<Key, byte[]> Values = new Dictionary<Key, byte[]>();
            foreach (Node ni in Root.Children[1].Children)
            {
                Key Ki = Tables.Last().getKey(ni.Children[0].literal);
                if (Ki == null)
                    throw new Exception("Invalid key name");
                try
                {
                    Values.Add(Ki, Datatypes.ConverterFunctions[Ki.Type](ni.Children[1].literal));
                }
                catch
                {
                    throw new Exception("Invalid input data");
                }
            }
            foreach (Key Ki in Values.Keys)
            {
                foreach (int i in Filter)
                {
                    Ki.DATA[i] = Values[Ki];
                }
            }
            AfterEffect[2] = true;
            Result = Filter.Count.ToString() + " records affected";
            return null;
        }

        private Table Delete(Node Root)
        {
            From(Root.Children[0]);
            if (Root.Children.Count > 1) { Where(Root.Children[1]); }
            foreach (int i in Filter)
            {
                Tables.Last().RemoveRecord(i);
            }
            Result = Filter.Count.ToString() + " records affected";
            AfterEffect[1] = true;
            AfterEffect[2] = true;
            Tables.Last().Records -= Filter.Count;
            return null;
        }

        private Table Create(Node Root)
        {
            string res = "Unknown Error";
            switch(Root.Children[0].HostedToken.Type)
            {
                case TokenType.TABLE_KW:
                    Table Tx=CreateTable(Root);
                    if (database.getTable(Tx.Name) != null)
                        throw new Exception("Table with duplicate name exists");
                    database.Tables.Add(Tx);
                    Tables.Add(Tx);
                    AfterEffect[1] = true;
                    AfterEffect[2] = true;
                    res = "1 table added";
                    break;
            }
            Result = res;
            return null;
        }

        private Table CreateTable(Node Root)
        {
            Table Ti = new Table(Root.Children[1].literal);
            for (int i=2;i<Root.Children.Count;i++)
            {
                if (Ti.getKey(Root.Children[i].Children[0].literal) != null)
                    throw new Exception("Key with duplicate name exists");

                if (!Datatypes.Datatype_str.ContainsKey(Root.Children[i].Children[1].literal))
                    throw new Exception("Datatype invalid");

                Ti.AddKey(Root.Children[i].Children[0].literal,
                    Datatypes.Datatype_str[Root.Children[i].Children[1].literal],false);
            }
            Ti.SchemaFile = Ti.Name + Extensions.TableSchemaExtension;
            return Ti;
        }

        private Table Alter(Node Root)
        {
            From(Root.Children[1]);
            if (Alters.ContainsKey(Root.Children[2].HostedToken.Type))
                Alters[Root.Children[2].HostedToken.Type](Root.Children[2]);
            else
                throw new Exception("Invalid Alter command");
            AfterEffect[1] = true;
            AfterEffect[2] = true;
            return null;
        }

        private Table AlterModify(Node Root)
        {
            throw new NotImplementedException();
        }

        private Table AlterDrop(Node Root)
        {
            throw new NotImplementedException();
        }

        private Table AlterAdd(Node Root)
        {
            throw new NotImplementedException();
        }

        private Table AltereName(Node Root)
        {
            int subjectKeyID = -1;
            if (Root.Children[0].HostedToken.Type == TokenType.Identifier_Key)
                subjectKeyID = Tables.Last().getKeyIndex(Root.Children[0].HostedToken.TokenData);
            if (subjectKeyID == -1)
                Tables.Last().Name = Root.Children[1].HostedToken.TokenData;
            else
                Tables.Last().Keys[subjectKeyID].Name = Root.Children[1].HostedToken.TokenData;

            AfterEffect[1] = true;
            AfterEffect[2] = true;
            return null;
        }
    }
}
