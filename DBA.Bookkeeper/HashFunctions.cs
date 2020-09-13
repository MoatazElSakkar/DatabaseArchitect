using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DBA.Bookkeeper
{
    static class HashFunctions
    {
        public static string ComputeSha1Hash(this string rawData)
        {
            using (SHA1 HashFunction = SHA1.Create())
            {
                byte[] bytes = HashFunction.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static byte[] ComputeSha1HashBytes(this string rawData)
        {
            using (SHA1 HashFunction = SHA1.Create())
            {
                return HashFunction.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            }
        }
    }
}
