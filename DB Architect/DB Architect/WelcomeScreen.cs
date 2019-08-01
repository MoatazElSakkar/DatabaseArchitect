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
    public partial class WelcomeScreen : Window
    {
        public WelcomeScreen(Home P):base(P,"Welcome Screen")
        {
            InitializeComponent();
            
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch(Exception ex)
            {
                Error.Visible = true;
                stats_lbl.Text = ex.Message;
            }
        }

    }
}
