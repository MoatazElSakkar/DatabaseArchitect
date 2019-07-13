using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DBA;

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
                Program.TA = new TransitAgent(ServerName.Text);
                if (Program.TA.Verified(Password.Text) == true)
                {
                    Error.Visible = false;
                    Program.server.Name=ServerName.Text;
                    ParentWindow.ResetForConnection();
                    this.Close();
                }
                else
                {
                    Error.Visible = true;
                    stats_lbl.Text = "Unable to establish connection, Server Response: Incorrect Credentials";
                }
            }
            catch(Exception ex)
            {
                Error.Visible = true;
                stats_lbl.Text = ex.Message;
            }
        }

    }
}
