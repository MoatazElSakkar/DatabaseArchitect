using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBA.Refrences;

namespace DBA.Arithmetic
{
    public partial class Adders
    {

        static Dictionary<DATATYPE, ArithmeticOperator> SUBTRACT = new Dictionary<DATATYPE, ArithmeticOperator>()
        {
            {DATATYPE.BYTE,BYTE_SUB },
            {DATATYPE.INT32,INT32_SUB },
            {DATATYPE.INT64,INT64_SUB },
            {DATATYPE.TIME,TIME_SUB },
            {DATATYPE.DATE,DATE_SUB },
            {DATATYPE.TIMESTAMP,TIMESTAMP_SUB },
            {DATATYPE.CHAR,CHAR_SUB },
            {DATATYPE.STRING,STRING_SUB },
            {DATATYPE.BOOLEAN,BOOL_SUB },
            {DATATYPE.BINARY,BINARY_SUB }
        };

        private static byte[] BYTE_SUB(byte[] a, byte[] b)
        {
            throw new NotImplementedException();
        }

        private static byte[] INT32_SUB(byte[] a, byte[] b)
        {
            throw new NotImplementedException();
        }

        private static byte[] INT64_SUB(byte[] a, byte[] b)
        {
            throw new NotImplementedException();
        }

        private static byte[] TIME_SUB(byte[] a, byte[] b)
        {
            throw new NotImplementedException();
        }

        private static byte[] DATE_SUB(byte[] a, byte[] b)
        {
            throw new NotImplementedException();
        }

        private static byte[] TIMESTAMP_SUB(byte[] a, byte[] b)
        {
            throw new NotImplementedException();
        }

        private static byte[] CHAR_SUB(byte[] a, byte[] b)
        {
            throw new NotImplementedException();
        }

        private static byte[] STRING_SUB(byte[] a, byte[] b)
        {
            throw new NotImplementedException();
        }

        private static byte[] BOOL_SUB(byte[] a, byte[] b)
        {
            throw new NotImplementedException();
        }

        private static byte[] BINARY_SUB(byte[] a, byte[] b)
        {
            throw new NotImplementedException();
        }
    }
}
