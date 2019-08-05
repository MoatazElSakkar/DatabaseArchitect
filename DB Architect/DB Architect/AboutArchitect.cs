using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DB_Architect
{
    public partial class AboutArchitect : Window
    {

        public AboutArchitect(Home P):base ()
        {
            InitializeComponent();
        }

        private void AboutArchitect_Load(object sender, EventArgs e)
        {
            Version.Text = "Version: " + Program.Version;
            Build.Text = "Build: " + Program.Build;
        }

    }
}
