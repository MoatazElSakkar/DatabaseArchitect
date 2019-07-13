using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBA.Refrences;

namespace DBA.Arithmetic
{
    delegate byte[] ArithmeticOperator(byte[] a, byte[] b);
    public partial class Adders
    {

        static Dictionary<DATATYPE, ArithmeticOperator> ADDERS = new Dictionary<DATATYPE, ArithmeticOperator>()
        {
            {DATATYPE.BYTE,BYTE_ADD },
            {DATATYPE.INT32,INT32_ADD },
            {DATATYPE.INT64,INT64_ADD },
            {DATATYPE.TIME,TIME_ADD },
            {DATATYPE.DATE,DATE_ADD },
            {DATATYPE.TIMESTAMP,TIMESTAMP_ADD },
            {DATATYPE.CHAR,CHAR_ADD },
            {DATATYPE.STRING,STRING_ADD },
            {DATATYPE.BOOLEAN,BOOL_ADD },
            {DATATYPE.BINARY,BINARY_ADD }
        };

        private static byte[] BINARY_ADD(byte[] a, byte[] b)
        {
            throw new NotImplementedException();
        }

        private static byte[] BOOL_ADD(byte[] a, byte[] b)
        {
            throw new NotImplementedException();
        }

        private static byte[] STRING_ADD(byte[] a, byte[] b)
        {
            throw new NotImplementedException();
        }

        private static byte[] CHAR_ADD(byte[] a, byte[] b)
        {
            throw new NotImplementedException();
        }

        private static byte[] TIMESTAMP_ADD(byte[] a, byte[] b)
        {
            throw new NotImplementedException();
        }

        private static byte[] DATE_ADD(byte[] a, byte[] b)
        {
            throw new NotImplementedException();
        }

        private static byte[] TIME_ADD(byte[] a, byte[] b)
        {
            string[] TimeStringA = Encoding.ASCII.GetString(a).Split(new char[] {':',' ' });
            string[] TimeStringB = Encoding.ASCII.GetString(b).Split(new char[] { ':', ' ' });
            int seconds = int.Parse(TimeStringA[2]) + int.Parse(TimeStringB[2]);
            int minutes= int.Parse(TimeStringA[1]) + int.Parse(TimeStringB[1])+(seconds/60);
            seconds = seconds % 60;
            int hours = int.Parse(TimeStringA[0]) + int.Parse(TimeStringB[0])+minutes/60;
            minutes = minutes % 60;
            bool am = (TimeStringA[3] == "am")^(hours/12!=0);
            hours = hours % 12;
            string cycle = am ? "am" : "pm";
            string Output = hours.ToString() + ':' + minutes.ToString() + ':' + seconds.ToString() + ' ' + cycle;
            return Encoding.ASCII.GetBytes(Output);
        }

        private static byte[] INT64_ADD(byte[] a, byte[] b)
        {
            return BitConverter.GetBytes
                (BitConverter.ToInt64(a, 0) + BitConverter.ToInt64(b, 0));
        }

        private static byte[] INT32_ADD(byte[] a, byte[] b)
        {
            return BitConverter.GetBytes
                (BitConverter.ToInt32(a,0)+ BitConverter.ToInt32(b, 0));
        }

        public static byte[] BYTE_ADD(byte[] a, byte[] b)
        {
            return new byte[1] { (byte)(a[0] + b[0]) };
        }

        public static byte[] ADD(byte[] a, byte[] b, DATATYPE DT)
        {
            throw new NotImplementedException();
        }
    }
}
