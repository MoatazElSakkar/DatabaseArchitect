using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DBA.RelationalModel
{
    public enum CARDINALITY
    {
        Signular,   //one to one
        Repeated, //one to many
        Random //many to many
    }
    

    public class Relationship
    {
        public bool conditional
        {
            get;
            set;
        }

        public string RootPath
        {
            get;
            set;
        }

        public string foreignKey
        {
            get;
            set;
        }

        public string RefrenceKeyDir    //Table/Key
        {
            get;
            set;
        }

        static Dictionary<CARDINALITY, byte> RecordSize = new Dictionary<CARDINALITY, byte>()
        {
            {CARDINALITY.Signular,10 },           //4 chars : 4 chars\n 10 chars per record
            {CARDINALITY.Repeated,15 },        //4 chars : 4 chars > 4 chars\n 15 chars per record
        };

        Dictionary<int, List<int>> Cache;
        public CARDINALITY RelationType
        {
            get;
            set;
        }

        public string IndexerFile;
        public Relationship(Relationship R)
        {
            foreach (KeyValuePair<int,List<int>> Record in  R.Cache)
            {
                Cache.Add(Record.Key, new List<int>(Record.Value));
            }
            conditional = R.conditional;
            RootPath = R.RootPath;
            foreignKey = R.foreignKey;
            RelationType = R.RelationType;
            IndexerFile = R.IndexerFile;
        }


        //Resolves and caches a certain relation
        public int[] ResolveSingleIndex(int input)
        {
            if (Cache==null) { Cache = new Dictionary<int, List<int>>(); }
            else
            {
                if (Cache.ContainsKey(input))
                    return Cache[input].ToArray();
            }
            FileStream Indexer = new FileStream(IndexerFile, FileMode.Open);
            if (!conditional)
            {
                while (true)
                {
                    Indexer.Seek(RecordSize[RelationType] * input, SeekOrigin.Begin);
                    byte[] buffer = new byte[RecordSize[RelationType]];
                    Indexer.Read(buffer, 0, RecordSize[RelationType]);

                    string[] RecordItems = Encoding.ASCII.GetString(buffer).Split
                        (new char[] { ':', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    if (Cache.ContainsKey(int.Parse(RecordItems[0]))) { Cache[int.Parse(RecordItems[0])].Add(int.Parse(RecordItems[1])); }
                    else { Cache.Add(int.Parse(RecordItems[0]), new List<int> { int.Parse(RecordItems[1]) }); }
                    if (RelationType == CARDINALITY.Signular) { return Cache[input].ToArray(); }
                    if (RecordItems.Count() == 3) { input = int.Parse(RecordItems[3]); }
                    else {/*Throw incomplete record exception*/ }
                    if (input == int.MaxValue) { return Cache[input].ToArray(); }
                }
            }
            else
            {
                int i = 0;
                while (true)
                {
                    Indexer.Seek(RecordSize[RelationType] * i++, SeekOrigin.Begin);
                    byte[] buffer = new byte[RecordSize[RelationType]];
                    Indexer.Read(buffer, 0, RecordSize[RelationType]);

                    string[] RecordItems = Encoding.ASCII.GetString(buffer).Split
                        (new char[] { ':', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                    if (Cache.ContainsKey(int.Parse(RecordItems[0]))) { Cache[int.Parse(RecordItems[0])].Add(int.Parse(RecordItems[1])); }
                    else { Cache.Add(int.Parse(RecordItems[0]), new List<int> { int.Parse(RecordItems[1]) }); }
                    if (input== int.Parse(RecordItems[0]) && RelationType == CARDINALITY.Signular) { return Cache[input].ToArray(); }
                    if (input == int.Parse(RecordItems[0]) && RecordItems.Count() == 3) { i = int.Parse(RecordItems[3]); }
                    else {/*Throw incomplete record exception*/ }
                    if (input == int.MaxValue) { return Cache[input].ToArray(); }
                }
            }
        }

        public void SerializeRelation()
        {
            FileStream Extractor = new FileStream(IndexerFile, FileMode.Open);
            foreach (int TargetKey in Cache.Keys)
            {
                byte[] buffer = Encoding.ASCII.GetBytes(TargetKey.ToString());
                Extractor.Write(buffer, 0, buffer.Length);

                Extractor.WriteByte((byte)':');
                buffer = Encoding.ASCII.GetBytes(Cache[TargetKey][0].ToString());
                Extractor.Write(buffer, 0, buffer.Length);
                Extractor.WriteByte((byte)'\n');
                if (RelationType == CARDINALITY.Signular)  {continue;}
                for (int i=1;i< Cache[TargetKey].Count;i++)
                {
                    buffer = Encoding.ASCII.GetBytes(TargetKey.ToString());
                    Extractor.Write(buffer, 0, buffer.Length);
                    Extractor.WriteByte((byte)':');
                    buffer = Encoding.ASCII.GetBytes(Cache[TargetKey][0].ToString());
                    Extractor.Write(buffer, 0, buffer.Length);
                    Extractor.WriteByte((byte)'\n');
                }
            }
        }
    }
}
