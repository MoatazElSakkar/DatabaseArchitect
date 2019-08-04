using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using DBA.GlaciaProtocol;

namespace DB_Architect
{
    static class Program
    {
        public static int Port=0;
        public static SettingsParser Settings = new SettingsParser();
        //public static TransitAgent TA;
        public static Server server=new Server();

        public static string Version = "1.19a";
        public static string Build = "129";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Request Rq1 = new Request();
            //ClientSocket CS = new ClientSocket("Apex");
            //Rq1.Header = RequestType.VerifyIdentity;
            //Rq1.Attachment = "1234567";
            //CS.send(Rq1);
            //Response Rs = CS.recieve() as Response;


            //Request Rq2 = new Request();
            //Rq2.Header = RequestType.RetrieveServerInfo;
            //CS.send(Rq2);
            //Response Rs2= CS.recieve() as Response;


            Application.Run(new Home());

        }
    }
}
