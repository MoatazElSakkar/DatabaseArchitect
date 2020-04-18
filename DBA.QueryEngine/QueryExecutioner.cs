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

        Dictionary<string,List<Key>> KeyIDs = new Dictionary<string, List<Key>>();

        public List<Table> Tables = new List<Table>();

        //Filters contain the indicies that will be displayed hashed by the table itself
        Dictionary<string, List<int>> Filters = new Dictionary<string, List<int>>();

        //Only recording the Reordered Records
        Dictionary<string, Dictionary<int, int>> Order = new Dictionary<string, Dictionary<int, int>>();

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
                {TokenType.WHERE_KW, Where }
            };
        }

        private Table RightJoin(Node Root)
        {
            From(Root.Children[1]);
            Where(Root.Children[2]);
            return null;
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
            //We add a filter for each table added --Join Case
            Tables.Add(T);
            Filters.Add(T.Name,Enumerable.Range(0, Tables.Last().Records).ToList());
            KeyIDs.Add(T.Name, new List<Key>());
        }

        void SelectKeys(Node Keys)
        {
            if (Keys.Children[0].HostedToken.Type == TokenType.Closure)
                foreach (Key K in Tables.Last().Keys)
                {
                    KeyIDs[Tables.Last().Name].Add(K);
                }
            else
                foreach (Node Child in Keys.Children)
                {
                    string TableName = Tables.Last().Name;

                    if (Child.HostedToken.Type == TokenType.Composite 
                        && TableName != Child.Children[0].literal)
                        continue;

                    Key Kt = Tables.Last().getKey(Child.literal);
                    if (Kt == null)
                        throw new Exception(string.Format("Designated key \"{0}\" was not found in Table \"{1}\"",Child.literal,TableName));

                    KeyIDs[TableName].Add(Kt);
                }
        }

        private Table Select(Node Root)
        {
            From(Root.Children[1]);

            SelectKeys(Root.Children[0]);

            for (int i = 2; i < Root.Children.Count; i++)
                if (Joiners.ContainsKey(Root.Children[i].HostedToken.Type))
                {
                    Joiners[Root.Children[i].HostedToken.Type](Root.Children[i]);
                    SelectKeys(Root.Children[0]);
                }
                else if (Conditionals.ContainsKey(Root.Children[i].HostedToken.Type))
                {
                    Conditionals[Root.Children[i].HostedToken.Type](Root.Children[i]);
                }

            Table Response = new Table(Tables[0].Name+((Tables.Count>1)?"featuring "+Tables[1].Name:""));

            Response.Records = Filters.First().Value.Count;
            foreach (List<int> Li in Filters.Values)
                if (Li.Count > Response.Records)
                    Response.Records = Li.Count;

            Dictionary<string,List<int>> KIndices = new Dictionary <string, List<int>>();

            foreach (Table Ti in Tables)
            {
                KIndices.Add(Ti.Name, new List<int>());
                foreach (Key Ki in KeyIDs[Ti.Name])
                {
                    Response.Keys.Add(new Key(Ki, true));
                    KIndices[Ti.Name].Add(Ti.getKeyIndex(Ki.Name));
                }
            }

            for (int i=0;i<Response.Records;i++)
            {
                List<byte[]> Record = new List<byte[]>();
                foreach (Table Ti in Tables)     //Assembling records that span multiple tables
                    Record.AddRange(Ti.RetrieveRecord(KIndices[Ti.Name], Filters[Ti.Name][i]));
                Response.AppendRecord(Enumerable.Range(0,Response.KeysCount).ToList(), Record);
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

        
        private Table Where(Node Root)
        {
            /*
            This where implmentation is tricky so pay attention
            PartialFilters stores records that satisfy the conditions evaluated cumulatively
            Where each WhereSearch function call would take the node with 
            the condition and then filter the last table in "Tables" with that condition,
            then AndCombine function call would combine the outputs with the cumulative list.
            */

            List<int> PartialFilters = new List<int>();
            PartialFilters = Enumerable.Range(0, Tables.Last().Records).ToList();

            foreach (Node N in Root.Children)
                PartialFilters=AndCombine(PartialFilters,WhereSearch(CompileComparison(N)));

            Filters[Tables.Last().Name] = PartialFilters;
            return null;
        }


        private Dictionary<char, int> ComparisonDecoder = new Dictionary<char, int>()
        {
            { '<' ,-1  },
            { '>' , 1  },
            { '=' , 0  }
        };
        private List<int> WhereSearch(Comparison C)
        {
            /*
            Single parameter "WhereSearch" is the most primitive version of WhereSearch, 
            It itirates on all indicies from both Keys.
            "And" conditions are evaluated itirativly
            "Or" Conditions are evaluated recursivly when needed
            Database Architect Parser ensures all Ands are evaluated by maintaining levels

            --Refer to the parser's documentation for exact details of how 
            boolean expressions are evaluated. 
            */

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
                i2 += C.Immediate ? 0 : 1;  //Incrementing if the second key wasn't virtual
            }
            return Filter;
        }

        private bool WhereSearch(Node Ni, int index)
        {
            /*
            Dual parameter "WhereSearch" is more controlled, 
            It's used to evaluate Expressions paired with an OR operator
            these expressions can include sub expressions with AND & OR
            however for the sake of optimization an OR expression is evaluated
            at a single specific index via the index given.
            */

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
            //Uses 2 variables comparator design for a singular loop design.
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

            SelectKeys(Root.Children[0]);
            for (int i = 2; i < Root.Children.Count; i++)
                if (Joiners.ContainsKey(Root.Children[i].HostedToken.Type))
                {
                    Joiners[Root.Children[i].HostedToken.Type](Root.Children[i]);
                    SelectKeys(Root.Children[0]);
                }
                else if (Conditionals.ContainsKey(Root.Children[i].HostedToken.Type))
                {
                    Conditionals[Root.Children[i].HostedToken.Type](Root.Children[i]);
                }
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
            foreach (Table Ti in Tables)
            {
                foreach (Key Ki in Ti.Keys)
                {
                    foreach (int i in Filters[Ti.Name])
                    {
                        Ki.DATA[i] = Values[Ki];
                    }
                }
            }
            AfterEffect[2] = true;
            Result = Filters.Count.ToString() + " records affected";
            return null;
        }

        private Table Delete(Node Root)
        {
            int Impact = 0;
            From(Root.Children[0]);
            if (Root.Children.Count > 1) { Where(Root.Children[1]); }
            foreach (Table Ti in Tables)
            {
                foreach (int i in Filters[Ti.Name])
                    Ti.RemoveRecord(i);
                Impact = Math.Max(Impact, Filters[Ti.Name].Count);
                Ti.Records -= Filters[Ti.Name].Count;
            }
            Result = Impact.ToString() + " records affected";
            AfterEffect[1] = true;
            AfterEffect[2] = true;
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
            From(Root.Children[0]);
            if (Alters.ContainsKey(Root.Children[1].HostedToken.Type))
                Alters[Root.Children[1].HostedToken.Type](Root.Children[1]);
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
