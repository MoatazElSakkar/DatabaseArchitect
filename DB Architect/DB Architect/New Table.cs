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
    public partial class NewTable : Window
    {
        string DBstr = "";

        public NewTable(Home P):base(P,"NewTable")
        {
            InitializeComponent();
        }

        public NewTable(Home P,string DBname)
            : base(P, "NewTable")
        {
            DBstr = DBname;
            InitializeComponent();
        }

        private void NewTable_Load(object sender, EventArgs e)
        {
            if (DBstr == "")
            {
                foreach (Database DB in Program.server.DBS)
                {
                    DBBox.Items.Add(DB.Name);
                    try
                    {
                        DBBox.SelectedIndex = 0;
                    }
                    catch
                    {

                    }
                }
            }
            else
            {
                DBBox.Visible = false;
                lbl0.Visible = false;
            }
        }

        private void Create_Click(object sender, EventArgs e)
        {
            if (DBstr == "")
            {
                string Script = "Create Table (" + TableName.Text + ")";
                this.Close();
            }
            else
            {
                string Script = "Create Table (" + TableName.Text + ")";
                this.Close();
            }
        }
    }
}
