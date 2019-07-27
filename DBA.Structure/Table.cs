﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBA.RelationalModel;
using DBA.Refrences;

namespace DBA.Structure
{
    public partial class Table
    {
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

        public Table(Table T)
        {
            Name = T.Name;
            Records = T.Records;
            KeysCount = T.KeysCount;
            foreach (Key k in T.Keys)
            {
                Keys.Add(new Key(k));
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
