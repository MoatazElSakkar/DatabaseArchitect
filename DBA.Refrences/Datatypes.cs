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
            return BitConverter.GetBytes(double.Parse(input));
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

        public static Dictionary<DATATYPE, Type> DatatypeReConverter = new Dictionary<DATATYPE, Type>()
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

        public delegate string ByteDecoder(byte[] input);
        public static Dictionary<DATATYPE, ByteDecoder> DecoderFunctions = new Dictionary<DATATYPE, ByteDecoder>()
        {
            {DATATYPE.BYTE      ,SingleByteDecoder},
            {DATATYPE.INT32     ,Int32Decoder     },
            {DATATYPE.INT64     ,Int64Decoder     },
            {DATATYPE.FLOAT     ,FloatDecoder     },
            {DATATYPE.DATE      ,DateTimeDecoder  },
            {DATATYPE.TIME      ,DateTimeDecoder  },
            {DATATYPE.TIMESTAMP ,DateTimeDecoder  },
            {DATATYPE.YEAR      ,DateTimeDecoder  },
            {DATATYPE.CHAR      ,SingleByteDecoder},
            {DATATYPE.STRING    ,VarcharDecoder   },
            {DATATYPE.BOOLEAN   ,SingleByteDecoder},
            {DATATYPE.BINARY    ,BinFileDecoder   }
        };
        public static string BinFileDecoder(byte[] input)
        {
            throw new NotImplementedException();
        }

        public static string VarcharDecoder(byte[] input)
        {
            return Encoding.ASCII.GetString(input);
        }

        public static string DateTimeDecoder(byte[] input)
        {
            throw new NotImplementedException();
        }

        public static string FloatDecoder(byte[] input)
        {
            return BitConverter.ToString(input,0);
        }

        public static string Int64Decoder(byte[] input)
        {
            return BitConverter.ToString(input, 0);
        }

        public static string Int32Decoder(byte[] input)
        {
            return BitConverter.ToInt32(input,0).ToString();
        }

        public static string SingleByteDecoder(byte[] input)
        {
            return input[0].ToString();
        }

        public delegate int Compare(byte[] A,byte[] B);
        public static Dictionary<DATATYPE, Compare> CompareFunctions = new Dictionary<DATATYPE, Compare>()
        {
            {DATATYPE.BYTE      ,SingleByteDecoder},
            {DATATYPE.INT32     ,Int32Decoder     },
            {DATATYPE.INT64     ,Int64Decoder     },
            {DATATYPE.FLOAT     ,FloatDecoder     },
            {DATATYPE.DATE      ,DateTimeDecoder  },
            {DATATYPE.TIME      ,DateTimeDecoder  },
            {DATATYPE.TIMESTAMP ,DateTimeDecoder  },
            {DATATYPE.YEAR      ,DateTimeDecoder  },
            {DATATYPE.CHAR      ,SingleByteDecoder},
            {DATATYPE.STRING    ,VarcharCompare   },
            {DATATYPE.BOOLEAN   ,SingleByteDecoder},
            {DATATYPE.BINARY    ,BinFileCompare   }
        };
        public static int BinFileCompare(byte[] A, byte[] B)
        {
            //Use MD5 For files comparison
            throw new NotImplementedException();
        }

        public static int VarcharCompare(byte[] A, byte[] B)
        {
            string a = Encoding.Default.GetString(A);
            string b = Encoding.Default.GetString(B);
            return a == b ? 0 : 1;
        }

        public static int  DateTimeDecoder(byte[] A, byte[] B)
        {
            throw new NotImplementedException();
        }

        public static int  FloatDecoder(byte[] A, byte[] B)
        {
            double a = BitConverter.ToDouble(A, 0);
            double b = BitConverter.ToDouble(B, 0);
            return a != b ? (int)((a - b) / Math.Abs(a - b)) : 0;

        }

        public static int  Int64Decoder(byte[] A, byte[] B)
        {
            long a = BitConverter.ToInt64(A, 0);
            long b = BitConverter.ToInt64(B, 0);
            return a!=b?(int)((a - b)/ Math.Abs(a- b)):0;
        }

        public static int  Int32Decoder(byte[] A, byte[] B)
        {
            int a = BitConverter.ToInt32(A, 0);
            int b = BitConverter.ToInt32(B, 0);
            return a != b ? (int)((a - b) / Math.Abs(a - b)) : 0;
        }

        public static int  SingleByteDecoder(byte[] A, byte[] B)
        {
            return A[0] != B[0] ? (int)((A[0] - B[0]) / Math.Abs(A[0] - B[0])) : 0;
        }
    }
}
