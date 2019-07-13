using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using DBA;

namespace DB_Architect
{
    static class Program
    {
        public static int Port=0;
        public static SettingsParser Settings = new SettingsParser();
        public static TransitAgent TA;
        public static Server server=new Server();

        public static string Version = "1.12a";
        public static string Build = "112";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SplashScr());
            Application.Run(new Home());

        }
    }
}
