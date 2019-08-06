using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBA.Structure;
using System.IO;
using DBA.Refrences;

namespace DBA_Server_Test
{
    public static class ServerWriters
    {
        public static void Write(this Database DB)
        {
            File.WriteAllText(DB.FileUri, "");
            FileStream Writer_stream = new FileStream(DB.FileUri, FileMode.Append);
            StreamWriter Writer = new StreamWriter(Writer_stream);
            Writer.Write("DBNAME:" + DB.Name + "\r\n");
            Writer.Write("TABS-DIR" + DB.TablesDir + "\r\n");
            Writer.Write("IND-DIR" + DB.IndexersDir);
            Writer.Close();
        }

        public static void Write(this Table Tableu)
        {
            File.WriteAllText(Tableu.SchemaFile, "");
            FileStream Writer_stream = new FileStream(Tableu.SchemaFile, FileMode.Append);
            StreamWriter Writer = new StreamWriter(Writer_stream);
            Writer.Write("TAB-NAME:" + Tableu.Name+"\r\n");
            Writer.Write("RECORDS:" + Tableu.Records.ToString() + "\r\n");
            Writer.Write("KEYS:" + Tableu.KeysCount.ToString() + "\r\n");
            for(int i=0;i< Tableu.Keys.Count;i++)
            {
                Writer.Write(Tableu.Keys[i].Name + ":" + Tableu.Keys[i].Type.ToString() + ':' + Tableu.Keys[i].Constraint.ToString());
                Writer.Write("\r\n");
            }
            Writer.Close();
        }

        public static void WriteRecords(this Table Tableu)
        {
            File.WriteAllText(Tableu.DataFile, "");
            FileStream Writer_stream = new FileStream(Tableu.DataFile, FileMode.Append);
            StreamWriter Writer = new StreamWriter(Writer_stream);
            for (int j= 0; j < Tableu.Keys.Count; j++)
            {
                Writer.Write(Tableu.Keys[j].Name + '{');
                for (int i=0;i< Tableu.Keys[j].DATA.Count-1;i++)
                {
                    if (Tableu.Keys[j].Type == DATATYPE.STRING)
                        Writer.Write('\"');
                    Writer.Write(Datatypes.DecoderFunctions[Tableu.Keys[j].Type](Tableu.Keys[j].DATA[i]));
                    if (Tableu.Keys[j].Type == DATATYPE.STRING)
                        Writer.Write('\"');
                    Writer.Write(',');
                }

                if (Tableu.Keys[j].Type == DATATYPE.STRING)
                    Writer.Write('\"');
                Writer.Write(Datatypes.DecoderFunctions[Tableu.Keys[j].Type](Tableu.Keys[j].DATA.Last()));
                if (Tableu.Keys[j].Type == DATATYPE.STRING)
                    Writer.Write('\"');

                Writer.Write('}');
                if (j < Tableu.Keys.Count - 1)
                    Writer.Write("\r\n");
            }
            Writer.Close();
        }
    }
}