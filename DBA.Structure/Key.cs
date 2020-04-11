using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBA.Refrences;

namespace DBA.Structure
{
    [SerializableAttribute]
    public class Key
    {
        List<byte[]> CHECK_VARS;

        const byte NOTNULL = 0x80;    //10000000
        const byte UNIQUE = 0x40;     //01000000
        const byte DEFAULT = 0x20;    //00100000
        const byte CHECK = 0x10;      //00010000
        const byte PRIMARYKEY = 0x04; //00000100 
        const byte FOREIGNKEY = 0x02; //00000010

        public byte Constraint = 0x00; //Default value at 0

        public bool CheckConstraint(byte Mask)
        {
            return (Constraint & Mask) != 0;
        }

        public string Name
        {
            get;
            set;
        }

        public int Seek
        {
            get;
            set;
        }

        public DATATYPE Type
        {
            get;
            set;
        }

        public List<byte[]> DATA = new List<byte[]>();

        public Key(string a, DATATYPE b,byte C=0x0)
        {
            Name = a;
            Type = b;
            Constraint = C;
        }

        public Key(Key CopyKey, bool shallow=false)
        {
            Name = CopyKey.Name;
            Type = CopyKey.Type;
            if (!shallow)
                foreach (byte[] DATAITEM in CopyKey.DATA)
                {
                    byte[] temp = new byte[DATAITEM.Length];
                    int i = 0;
                    foreach (byte b in DATAITEM)
                    {
                        temp[i++] = b;
                    }
                    DATA.Add(temp);
                }
            Constraint = CopyKey.Constraint;
        }

        byte[] CopyArray(byte[] Input)
        {
            byte[] buffer = new byte[Input.Length];
            int i = 0;
            foreach (byte b in Input)
            {
                buffer[i++] = b;
            }
            return buffer;
        }

        public void Modify(byte[] Input, int i)
        {
            if (Verify(Input))
            {
                DATA[i] = CopyArray(Input);
            }
            else
            {

            }
        }

        public void AddRecord(byte[] Input)
        {
            if (Verify(Input))
            {
                DATA.Add(Input);
            }
        }
        public void AddRecord(string Input)
        {
            AddRecord(Datatypes.ConverterFunctions[Type](Input));
        }

        public virtual bool Verify(byte[] Input)
        {
            bool verified = true;

            if (CheckConstraint(UNIQUE) || CheckConstraint(PRIMARYKEY))
                verified= verified& VerifyUnique(Input);
            if (CheckConstraint(NOTNULL))
                verified = verified & VerifyNotNull(Input); 

            return verified;
        }

        private bool VerifyNotNull(byte[] input)
        {
            return true;
        }

        private bool VerifyUnique(byte[] input)
        {
            return true;
        }
    }
}
