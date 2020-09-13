using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBA.Definitions
{
    public class Fields
    {
        const string dbloc = "C:\\ProgramData\\DatabaseArchitect\\dbloc\\";
        const string certsloc = "C:\\ProgramData\\DatabaseArchitect\\certsloc\\";

        public static string DatabaseLocation
        {
            get
            {
                if (!System.IO.Directory.Exists(dbloc))
                    System.IO.Directory.CreateDirectory(dbloc);
                return dbloc;
            }
        }

        public static string CertificatesLoc
        {
            get
            {
                if (!System.IO.Directory.Exists(certsloc))
                    System.IO.Directory.CreateDirectory(certsloc);
                return certsloc;
            }
        }

    }
}
