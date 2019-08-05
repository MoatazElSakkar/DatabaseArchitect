using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBA.SplashScreen
{
    public partial class SplashScreen : Form
    {
        public SplashScreen(int limit=200)
        {
            Limit = limit;
            InitializeComponent();
        }

        int Limit;
        int i = 1;

        Timer T = new Timer();
        private void SplashScreen_Load(object sender, EventArgs e)
        {
            T.Interval = 10;
            T.Tick += T_Tick;
            T.Start();
        }

        private void T_Tick(object sender, EventArgs e)
        {
            if (i == Limit)
                Close();

            if (i == 200)
                i = 10;

            SplashBox.Image = Properties.Resources.ResourceManager.GetObject
                ("SplashScr" + i++.ToString().PadLeft(4, '0')) as Image;
        }
    }
}
