using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBA.Structure;
using System.IO;
using DBA.Refrences;

namespace DBA_Server_Test
{
    public static class ServerReaders
    {
        public static string ReadRecord(FileStream Reader,char Delimeter= '\n')
        {
            char buffer;
            string bufferStr = "";
            bool escape = false;
            Stack<char> Scope = new Stack<char>();
            while (((buffer = (char)Reader.ReadByte()) != Delimeter || Scope.Count != 0) && Reader.Position != Reader.Length)
            {
                if (buffer == '\"')
                {
                    if (!escape)
                    {
                        if (Scope.Count != 0) { Scope.Pop(); }
                        else { Scope.Push('\"'); }
                        continue;
                    }
                    else
                        escape = false;
                }
                if (buffer == '\\') { escape = true; }
                bufferStr += buffer;
            }
            return bufferStr;
        }

        public static void Read(this Database DB)
        {
            if (!File.Exists(DB.FileUri))
            {
                //Register Inconsistency
                return;
            }
            FileStream Reader = new FileStream(DB.FileUri, FileMode.Open);
            while (Reader.Position < Reader.Length)
            {
                string bufferStr = ReadRecord(Reader);
                string[] bufferSplit = bufferStr.Split(new char[] { ':', '\n', '\r' },StringSplitOptions.RemoveEmptyEntries);
                switch(bufferSplit[0])
                {
                    case "DBNAME":
                        DB.Name = bufferSplit[1];
                        break;
                    case "TABS-DIR":
                        DB.TablesDir= bufferSplit[1];
                        break;
                    case "IND-DIR":
                        DB.IndexersDir = bufferSplit[1];
                        break;
                }
            }
            //Loading Database tables Schematics
            foreach (string s in Directory.GetFiles
               (DB.dir + DB.TablesDir,"*"+Extensions.TableSchemaExtension+".txt"))
            {
                DB.Tables.Add(new Table(s));
                DB.Tables.Last().Read();
            }
            Reader.Close();
        }

        public static void Read(this Table Tableu)
        {
            if (!File.Exists(Tableu.SchemaFile))
            {
                //Register Inconsistency
                return;
            }
            
            FileStream Reader = new FileStream(Tableu.SchemaFile, FileMode.Open);
            while (Reader.Position < Reader.Length)
            {
                string bufferStr = ReadRecord(Reader);
                string[] bufferSplit = bufferStr.Split(new char[] { ':', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                switch (bufferSplit[0])
                {
                    case "TAB-NAME":
                        Tableu.Name = bufferSplit[1];
                        break;
                    case "RECORDS":
                        Tableu.Records = int.Parse(bufferSplit[1]);
                        break;
                    case "KEYS":
                        Tableu.KeysCount= int.Parse(bufferSplit[1]);
                        break;
                    default:
                        Tableu.Keys.Add(new Key(
                            bufferSplit[0], 
                            Datatypes.Datatype_str[bufferSplit[1]], 
                            byte.Parse(bufferSplit[2])));
                        break;
                }
            }
            Reader.Close();
        }

        public static void ReadRecords(this Table Tableu)
        {
            if (!File.Exists(Tableu.DataFile))
            {
                //Register Inconsistency
                return;
            }
            FileStream Reader = new FileStream(Tableu.DataFile, FileMode.Open);
            foreach (Key Kx in Tableu.Keys)
            {
                string bufferStr = ReadRecord(Reader,'{');
                string[] bufferSplit = bufferStr.Split(new char[] {'\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                bufferStr = ReadRecord(Reader, '}');
                bufferSplit = bufferStr.Split(',');
                for (int i=0;i<Tableu.Records;i++)
                {
                    Kx.AddRecord(bufferSplit[i]);
                }
            }
            Tableu.Survayed = true;
        }
    }
}