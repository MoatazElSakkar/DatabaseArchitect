using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBA.Structure;

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

        private void Where(Node Root)
        {
            List<Key> Sources = new List<Key>();
            List<int> PartialFilters = new List<int>();
            foreach (Node N in Root.Children)
            {
                
            }
        }

        private List<int> AndCombine(List<int> a,List<int> b)
        {
            
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
