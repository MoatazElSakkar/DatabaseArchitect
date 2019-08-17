using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Architect
{
    public partial class Output : Window
    {
        public void Write(string input)
        {
            OutputBox.Text += input + "\r\n\r\n";
        }
        public Output()
        {
            InitializeComponent();
            (this as Control).Dock = DockStyle.Fill;
        }
    }
}
