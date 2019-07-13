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
    public partial class Dialog : Window
    {
        public bool DialogRes;
        string message;

        public Dialog(Home P,string msg):base(P,"Dialog")
        {
            message = msg;
            InitializeComponent();
        }

        private void Conf_Click(object sender, EventArgs e)
        {
            DialogRes = true;
            this.Close();
        }

        private void Canc_Click(object sender, EventArgs e)
        {
            DialogRes = false;
            this.Close();
        }

        private void Dialog_Load(object sender, EventArgs e)
        {
            Question.Text = message;
        }
    }
}
