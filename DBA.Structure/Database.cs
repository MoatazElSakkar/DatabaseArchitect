using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBA.Structure
{
    public class Database
    {
        public string TablesDir
        {
            get;
            set;
        }
        public string IndexersDir
        {
            get;
            set;
        }

        public string dir
        {
            get
            {
                return FileUri.Remove(FileUri.Length - 1).Remove(FileUri.LastIndexOf('\\'));
            }
        }

        public Database(string _file)
        {
            FileUri = _file;
        }
        public string FileUri
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public int TablesCount
        {
            get;
            set;
        }

        public int Seek
        {
            get;
            set;
        }

        public List<Table> Tables = new List<Table>();
    }
}
