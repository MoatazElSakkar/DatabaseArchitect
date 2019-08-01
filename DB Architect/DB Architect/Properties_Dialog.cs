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
    public partial class Properties_Dialog : Window
    {
        int mode;
        string parentName;
        string TargetName;
        string[] Modes ={"Server","Database","Table"};

        public Properties_Dialog(Home P,string a,string b):base(P,"PropertiesDialog")
        {
            mode = 2;
            TargetName = a;
            parentName = b;
            InitializeComponent();
        }

        public Properties_Dialog(Home P, string a)
            : base(P, "PropertiesDialog")
        {
            mode = 1;
            TargetName = a;
            InitializeComponent();
        }
        public Properties_Dialog(Home P)
            : base(P, "PropertiesDialog")
        {
            mode = 0;
            InitializeComponent();
        }

        private void Properties_Dialog_Load(object sender, EventArgs e)
        {
            if (mode == 0)
            {
                Lbl1.Text = "Server Properties";
                Iconic.Image = Properties.Resources.Server;
                ServerProperties();
            }
            else if (mode == 1)
            {
                Lbl1.Text = TargetName + " Properties";
                Iconic.Image = Properties.Resources.Database_Frameless;
                DBProperties();
            }
            else if (mode == 2)
            {
                Lbl1.Text = TargetName + " Properties";
                Iconic.Image = Properties.Resources.Table;
                TableProperties();
            }
        }

        void ServerProperties()
        {
            //string Recieved=Program.TA.AssumeProperties("Server");
            //string[] Data = Recieved.Split('~');

            //int Delta = 0;

            //foreach (string S in Data)
            //{
            //    Label L = new Label();
            //    L.AutoSize = true;
            //    L.Location = new Point(10, 110 + Delta);
            //    Delta += 20;
            //    L.Text = S;
            //    this.Controls.Add(L);
            //}
        }

        void DBProperties()
        {
            //string Recieved = Program.TA.AssumeProperties("Database " + TargetName);
            //string[] Data = Recieved.Split('~');
            //int Delta = 0;

            //foreach (string S in Data)
            //{
            //    Label L = new Label();
            //    L.AutoSize = true;
            //    L.Location = new Point(10, 110 + Delta);
            //    Delta += 20;
            //    L.Text = S;
            //    this.Controls.Add(L);
            //}
        }

        void TableProperties()
        {
            //string Recieved = Program.TA.AssumeProperties("Table " + TargetName + " " + parentName);
            //string[] Data = Recieved.Split('~');
            //int Delta = 0;

            //foreach (string S in Data)
            //{
            //    Label L = new Label();
            //    L.AutoSize = true;
            //    L.Location = new Point(10, 110 + Delta);
            //    Delta += 20;
            //    L.Text = S;
            //    this.Controls.Add(L);
            //}
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
