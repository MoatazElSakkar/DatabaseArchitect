using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBA.Bookkeeper
{
    class KeySchema
    {
        int KeyLength;
        string KeyName;

        public const byte NOTNULL = 0x80;          //10000000
        public const byte UNIQUE = 0x40;           //01000000
        public const byte PRIMARYKEY = 0x20;       //00100000
        public const byte FOREIGNKEY = 0x10;       //00010000
        public const byte CHECK= 0x08;             //00001000 
        public const byte DEFAULT = 0x04;          //00000100
        public const byte INDEX = 0x02;            //00000010
        public const byte AlwaysOFF = 0x01;        //00000001



        byte Constraint = 0x00;

        byte[] RelatedTableName = new byte[16];
        byte[] CheckConstraintCondition = new byte[64];
        byte[] IndexFileName = new byte[20];
        private byte[] DefaultValue=new byte[128];

        public bool CheckConstraint(byte Mask)
        {
            return (Constraint & Mask) != 0;
        }


        public static KeySchema ReadSchema(byte[] buffer)
        {
            int offset=0;
            KeySchema SubjectSchema = new KeySchema();
            SubjectSchema.KeyName = Encoding.Default.GetString(buffer, offset, 12);offset += 12;
            SubjectSchema.KeyLength = BitConverter.ToInt32(buffer, 12); offset += 4;
            SubjectSchema.Constraint = buffer[24]; offset += 1;
            if (SubjectSchema.CheckConstraint(FOREIGNKEY))
            {
                Array.Copy(buffer, offset, SubjectSchema.RelatedTableName, 0, 16);
                offset += 16;
            }
            if (SubjectSchema.CheckConstraint(CHECK))
            {
                Array.Copy(buffer, offset, SubjectSchema.CheckConstraintCondition, 0, 64);
                offset += 64;
            }
            if (SubjectSchema.CheckConstraint(DEFAULT))
            {
                Array.Copy(buffer, offset, SubjectSchema.DefaultValue, 0, 128);
                offset += 128;
            }
            if (SubjectSchema.CheckConstraint(INDEX))
            {
                Array.Copy(buffer, offset, SubjectSchema.IndexFileName, 0, 20);
                offset += 20;
            }
            return SubjectSchema;
        }

        public static byte[] WriteSchema(KeySchema SubjectSchema)
        {
            int offset = 0;
            byte[] Buffer = new byte[256];
            Array.Copy(Encoding.Default.GetBytes(SubjectSchema.KeyName), 0, Buffer,offset, 12);offset += 12;
            Array.Copy(BitConverter.GetBytes(SubjectSchema.KeyLength), 0, Buffer, offset, 4); offset += 4;
            Buffer[offset++] = SubjectSchema.Constraint;

            Array.Copy(SubjectSchema.RelatedTableName, 0, SubjectSchema.RelatedTableName, offset, 16);
            offset += 16;

            Array.Copy(SubjectSchema.CheckConstraintCondition, 0, Buffer, offset, 64);
            offset += 64;

            Array.Copy(SubjectSchema.DefaultValue, 0,Buffer , offset, 128);
            offset += 128;

            Array.Copy(SubjectSchema.IndexFileName, 0,Buffer ,offset , 20);
            offset += 20;
            return Buffer;
        }
    }
}
