using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBA.Refrences.CustomClass
{
    class Time
    {
        public byte Hour;
        public byte minute;

        public bool am;

        public char seperator = ':';
        
        public Time(string Input)
        {
            string[] timeSplit = Input.Split
                (new char[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Hour = byte.Parse(timeSplit[0]);
            minute = byte.Parse(timeSplit[1]);
            am = (timeSplit[2].ToLower() == "am");
        }

        public static bool operator > (Time A,Time B)
        {
            if (A.Hour < B.Hour && ((A.am ^ B.am && A.am) || !A.am ^ B.am))
                return false;
            else if (A.Hour == B.Hour && A.minute < B.minute)
                return false;
            else
                return true;
        }
        public static bool operator <(Time A, Time B)
        {
            return !(A>B);
        }

        public static bool operator == (Time A, Time B)
        {
            if (A.Hour != B.Hour) { return false; }
            if (A.minute != B.minute) { return false; }
            if (A.am != B.am) { return false; }
            return true;
        }

        public static bool operator !=(Time A, Time B)
        {
            return !(A== B);
        }

        public override bool Equals(object o)
        {
            if (this == (o as Time))
                return true;
            return false;
        }

        public override string ToString()
        {
            return Hour.ToString() + seperator + minute.ToString() + (am?" am":" pm");
        }
    }
}
