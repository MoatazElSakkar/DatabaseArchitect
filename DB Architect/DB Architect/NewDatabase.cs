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
    public partial class NewDatabase : Window
    {

        public NewDatabase(Home P)
        {
            InitializeComponent();
        }

        private void NewDatabase_Load(object sender, EventArgs e)
        {

        }

        private void Create_Click(object sender, EventArgs e)
        {
            string Script="~%Database%~"+DBnameBox.Text;
            //Program.TA.ExecuteServerScript(Script);
            this.Close();
        }
    }
}
