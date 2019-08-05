using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBA.RelationalModel;
using DBA.Refrences;

namespace DBA.Structure
{
    [SerializableAttribute]
    public partial class Table
    {
        public bool Survayed = false;
        public string SchemaFile
        {
            get;
            set;
        }

        public string DataFile
        {
            get
            {
                return SchemaFile.Replace(Extensions.TableSchemaExtension, Extensions.TableDataExtension);
            }
        }


        List<Relationship> Relationships = new List<Relationship>();
        public List<Key> Keys = new List<Key>();
        
        public string Name
        {
            get;
            set;
        }

        public int KeysCount
        {
            get;
            set;
        }


        public int Records
        {
            get;
            set;
        }

        public Table(Table T, bool Shallow=false)
        {
            Name = T.Name;
            Records = T.Records;
            KeysCount = T.KeysCount;
            foreach (Key k in T.Keys)
            {
                Keys.Add(new Key(k,Shallow));
            }
            foreach(Relationship R in T.Relationships)
            {
                Relationships.Add(new Relationship(R));
            }
        }

        public void AddKey(string KeyName,DATATYPE DT,bool referencing, byte Constraint=0x00)
        {
            Key key = new Key(KeyName, DT);
            key.Constraint = Constraint;
            Keys.Add(key);
        }

        public void AppendRecord(Dictionary<int,byte[]> Input)
        {
            foreach (KeyValuePair<int, byte[]> RecordPair in Input)
            {
                if (!Keys[RecordPair.Key].Verify(RecordPair.Value))
                {
                    //Register Inconsistency
                    return;
                }
            }
            for (int i = 0; i < Keys.Count; i++)
            {
                if (Input.ContainsKey(i))
                    Keys[i].AddRecord(Input[i]);
                else
                    Keys[i].AddRecord(Datatypes.Intializations[Keys[i].Type]);
            }
        }

        internal Table GetShallowCopy()
        {
            return new Table(this, true);
        }

        public void AppendRecord(List<int>KIndex,List<byte[]> Data)
        {
            for(int i=0;i<KIndex.Count;i++)
            {
                if (!Keys[KIndex[i]].Verify(Data[i]))
                {
                    throw new Exception("Record append failed, invalid data!");
                }
            }
            for (int i = 0; i < Keys.Count; i++)
            {
                if (KIndex.Contains(i))
                    Keys[i].AddRecord(Data[i]);
                else
                    Keys[i].AddRecord(Datatypes.Intializations[Keys[i].Type]);
            }
        }

        public void RemoveRecord(int Record)
        {
            foreach (Key Ki in Keys)
            {
                Ki.DATA.RemoveAt(Record);
            }
        }

        public List<byte[]> RetrieveRecord(List<int> keys, int Record)
        {
            List<byte[]> Output = new List<byte[]>();
            foreach (int si in keys)
            {
                Output.Add(Keys[si].DATA[Record]);
            }
            return Output;
        }

        public int getKeyIndex(string KeyName)
        {
            for(int i=0;i<Keys.Count;i++)
            {
                if (Keys[i].Name == KeyName)
                {
                    return i;
                }
            }
            return -1;
        }
        public Key getKey(string KeyName)
        {
            foreach (Key K in Keys)
            {
                if (K.Name==KeyName)
                {
                    return K;
                }
            }
            return null;
        }

        public Table(string input)
        {
            if (!input.Contains('\\'))
                Name = input;
            else
                SchemaFile = input;
        }
    }
}
