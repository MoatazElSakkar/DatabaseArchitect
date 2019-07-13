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
    public partial class Options : Window
    {
        public Options(Home P):base (P,"OptionsWindow")
        {
            InitializeComponent();
        }

        private void Options_Load(object sender, EventArgs e)
        {
            Port.Text = Program.Port.ToString();
            XMLParse.Items.Add("Architect XML Agent");
            XMLParse.SelectedItem = 0;
        }

        private void apply_Click(object sender, EventArgs e)
        {
            Program.Port = int.Parse(Port.Text);
        }
    }
}
