using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBA.Refrences
{
    public enum DATATYPE
    {
        BYTE, INT32, INT64, FLOAT,
        DATE, TIME, TIMESTAMP, YEAR,
        CHAR, STRING,
        BOOLEAN,
        BINARY
    }
    public delegate byte[] ByteConverter(string input);
    public class Datatypes
    {
        public static Dictionary<DATATYPE, ByteConverter> ConverterFunctions = new Dictionary<DATATYPE, ByteConverter>()
        {
            {DATATYPE.BYTE      ,SingleByteConverter},
            {DATATYPE.INT32     ,Int32Converter     },
            {DATATYPE.INT64     ,Int64Converter     },
            {DATATYPE.FLOAT     ,FloatConverter     },
            {DATATYPE.DATE      ,DateTimeConverter  },
            {DATATYPE.TIME      ,DateTimeConverter  },
            {DATATYPE.TIMESTAMP ,DateTimeConverter  },
            {DATATYPE.YEAR      ,DateTimeConverter  },
            {DATATYPE.CHAR      ,SingleByteConverter},
            {DATATYPE.STRING    ,VarcharConverter   },
            {DATATYPE.BOOLEAN   ,SingleByteConverter},
            {DATATYPE.BINARY    ,BinFileConverter   }
        };

        public static byte[] BinFileConverter(string input)
        {
            throw new NotImplementedException();
        }

        public static byte[] VarcharConverter(string input)
        {
            return Encoding.ASCII.GetBytes(input);
        }

        public static byte[] DateTimeConverter(string input)
        {
            throw new NotImplementedException();
        }

        public static byte[] FloatConverter(string input)
        {
            return BitConverter.GetBytes(float.Parse(input));
        }

        public static byte[] Int64Converter(string input)
        {
            return BitConverter.GetBytes(long.Parse(input));
        }

        public static byte[] Int32Converter(string input)
        {
            return BitConverter.GetBytes(int.Parse(input));
        }

        public static byte[] SingleByteConverter(string input)
        {
            return BitConverter.GetBytes(byte.Parse(input));
        }

        public static Dictionary<DATATYPE, Type> DatatypePreConverter = new Dictionary<DATATYPE, Type>()
        {
            {DATATYPE.BYTE      ,typeof(byte)   },
            {DATATYPE.INT32     ,typeof(int)    },
            {DATATYPE.INT64     ,typeof(long)   },
            {DATATYPE.FLOAT     ,typeof(float)  },
            {DATATYPE.DATE      ,typeof(string) },
            {DATATYPE.TIME      ,typeof(string) },
            {DATATYPE.TIMESTAMP ,typeof(string) },
            {DATATYPE.YEAR      ,typeof(string) },
            {DATATYPE.CHAR      ,typeof(char)   },
            {DATATYPE.STRING    ,typeof(string) },
            {DATATYPE.BOOLEAN   ,typeof(bool)   },
            {DATATYPE.BINARY    ,typeof(byte[]) }
        };
        public static Dictionary<DATATYPE, byte[]> Intializations = new Dictionary<DATATYPE, byte[]>()
        {
            {DATATYPE.BYTE,     BitConverter.GetBytes(0) },
            {DATATYPE.INT32,    BitConverter.GetBytes(0) },
            {DATATYPE.INT64,    BitConverter.GetBytes(0) },
            {DATATYPE.FLOAT,    BitConverter.GetBytes(0) },
            {DATATYPE.DATE,     BitConverter.GetBytes(0) },
            {DATATYPE.TIME,     BitConverter.GetBytes(0) },
            {DATATYPE.TIMESTAMP,BitConverter.GetBytes(0) },
            {DATATYPE.YEAR,     BitConverter.GetBytes(0) },
            {DATATYPE.CHAR,     BitConverter.GetBytes(0) },
            {DATATYPE.STRING,Encoding.ASCII.GetBytes("") },
            {DATATYPE.BOOLEAN,  BitConverter.GetBytes(0) },
            {DATATYPE.BINARY,   BitConverter.GetBytes(0) }
        };
        public static Dictionary<string,DATATYPE > Datatype_str = new Dictionary<string, DATATYPE>()
        {
            {"BYTE"     ,DATATYPE.BYTE     },
            {"INT32"    ,DATATYPE.INT32    },
            {"INT64"    ,DATATYPE.INT64    },
            {"FLOAT"    ,DATATYPE.FLOAT    },
            {"DATE"     ,DATATYPE.DATE     },
            {"TIME"     ,DATATYPE.TIME     },
            {"TIMESTAMP",DATATYPE.TIMESTAMP},
            {"YEAR"     ,DATATYPE.YEAR     },
            {"CHAR"     ,DATATYPE.CHAR     },
            {"STRING"   ,DATATYPE.STRING   },
            {"BOOLEAN"  ,DATATYPE.BOOLEAN  },
            {"BINARY"   ,DATATYPE.BINARY   }
        };
    }
}
