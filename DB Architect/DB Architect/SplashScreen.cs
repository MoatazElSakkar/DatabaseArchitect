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
    public partial class SplashScr : Form
    {
        public SplashScr()
        {
            InitializeComponent();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            //SplashAnimation.Movie = Application.StartupPath + @"/Resources/Splash.swf";
            //SplashAnimation.Play();
            //System.Windows.Forms.Timer T = new System.Windows.Forms.Timer();
            //T.Interval = 750;
            //T.Start();
            //T.Tick += (object Invoker, EventArgs EA) =>
            //{
            //    T.Stop();
            //    this.Close();
            //};
        }
    }
}
