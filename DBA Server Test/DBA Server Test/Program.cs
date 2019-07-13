using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace DBA_Server_Test
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Server.ServerFile = "File.xml";
            Thread Thread = new Thread(() => { commence(); });
            Thread.Start();
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }

        static void commence()
        {
            while (true)
            {
            //    TransitAgent TA = new TransitAgent(2250);
            }
        }
    }
}
