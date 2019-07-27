using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBA.Refrences
{
    public abstract class Datatype
    {
        public virtual int Compare(byte[] A, byte[] B)
        {
            return int.MinValue;
        }
        public virtual byte[] Encode(string data)
        {
            return null;
        }

        public virtual string decode(byte[] Data)
        {
            return null;
        }
    }
}
