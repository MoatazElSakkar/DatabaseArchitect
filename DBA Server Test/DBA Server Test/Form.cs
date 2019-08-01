using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace DBA_Server_Test
{
    public partial class F : Form
    {
        public F()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread Thread = new Thread(() => { PrimalLoop(); });
            Thread.Start();
        }

        void PrimalLoop()
        {
            while (true)
            {
                //TransitAgent TA = new TransitAgent(2250);
            }
        }
    }
}
