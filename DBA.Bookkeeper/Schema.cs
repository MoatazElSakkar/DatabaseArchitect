using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DBA.Bookkeeper
{
    class Schema
    {
        string TableName;
        DateTime LastAccessed, LastEdited, LastIndexed;
        int DatafileSize;
        int recordLength, RecordsCount;
        List<KeySchema> Keys = new List<KeySchema>();

        public static Schema ReadSchemaFile(string FileName)
        {
            FileStream SchemaReader = new FileStream(DBA.Definitions.Fields.DatabaseLocation + FileName,FileMode.Open);
            Schema SubjectSchema = new Schema();
            byte[] Buffer = new byte[16];

            SchemaReader.Read(Buffer, 0, 16);
            SubjectSchema.TableName = Encoding.Default.GetString(Buffer);

            Buffer = new byte[24];
            SchemaReader.Read(Buffer, 0, 24);
            SubjectSchema.LastAccessed = DateTime.FromBinary(BitConverter.ToInt64(Buffer,0));
            SubjectSchema.LastEdited = DateTime.FromBinary(BitConverter.ToInt64(Buffer, 8));
            SubjectSchema.LastIndexed = DateTime.FromBinary(BitConverter.ToInt64(Buffer, 16));

            Buffer = new byte[8];
            SchemaReader.Read(Buffer, 0, 8);
            SubjectSchema.recordLength = BitConverter.ToInt32(Buffer, 0);
            SubjectSchema.RecordsCount = BitConverter.ToInt32(Buffer, 4);

            while (SchemaReader.Position < SchemaReader.Length)
            {
                Buffer = new byte[256];
                SchemaReader.Read(Buffer, 0, 256);
                SubjectSchema.Keys.Add(KeySchema.ReadSchema(Buffer));
            }
            return SubjectSchema;
        }

        public static Schema WriteSchemaFile(Schema SubjectSchema)
        {
            FileStream SchemaWriter = new FileStream(DBA.Definitions.Fields.DatabaseLocation + SubjectSchema.TableName.ComputeSha1Hash()+".tsf", FileMode.OpenOrCreate);

            SchemaWriter.Write(Encoding.Default.GetBytes(SubjectSchema.TableName),0,Encoding.Default.GetByteCount(SubjectSchema.TableName));

            byte[] Buffer = new byte[24];
            Array.Copy(BitConverter.GetBytes(SubjectSchema.LastAccessed.ToBinary()),0, Buffer,0, 8);
            Array.Copy(BitConverter.GetBytes(SubjectSchema.LastEdited.ToBinary()), 0, Buffer, 8, 8);
            Array.Copy(BitConverter.GetBytes(SubjectSchema.LastIndexed.ToBinary()), 0, Buffer, 16, 8);
            SchemaWriter.Write(Buffer, 0, 24);

            SchemaWriter.Write(BitConverter.GetBytes(SubjectSchema.recordLength), 0, 4);
            SchemaWriter.Write(BitConverter.GetBytes(SubjectSchema.RecordsCount), 0, 4);

            foreach(KeySchema KS in SubjectSchema.Keys)
            {
                SchemaWriter.Write(KeySchema.WriteSchema(KS), 0, 256);
            }
            return SubjectSchema;
        }
    }
}
