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
    public partial class ChangePassword : Window
    {
        public ChangePassword(Home P):base(P,"Change Password Dialog")
        {
            InitializeComponent();
        }

        private void Apply_Click(object sender, EventArgs e)
        {
            if (OldPassword.Text == Program.server.Password)
            {
                Program.TA.ExecuteServerScript("ServerScript~%Password%~" + NewPassword.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect Credential, Unable To Comply", "Unable To Comply", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
