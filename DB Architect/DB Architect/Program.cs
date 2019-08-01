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
            Request Rq = new Request();
            Rq.Header = RequestType.Connect;
            Rq.Attachment = "SELECT * FROM PROJECTS WHERE i<90;";
            ClientSocket CS = new ClientSocket("Apex");
            CS.send(Rq);
            Application.Run(new Home());

        }
    }
}
