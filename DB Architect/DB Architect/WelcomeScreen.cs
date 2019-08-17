using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DBA.GlaciaProtocol;

namespace DB_Architect
{
    public partial class WelcomeScreen : Window
    {
        public Client Cli;

        public WelcomeScreen(Client _cli)
        {
            InitializeComponent();
            Cli = _cli;
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            Cli.CliSocket = new ClientSocket();
            Cli.CliSocket.ClienSocketName = ServerName.Text;
            Response R = Cli.VerifyCredentials(Password.Text);
            if (R.Header==ResponseType.IdentityVerified)
            {
                Cli.UpdateHost("Database Architect Connected", 5,false,true);
                Cli.UpdateHost("Ready", 6);
                Close();
            }
            else
            {
                Error.Visible = true;
                stats_lbl.Text = R.Attachment as string;
                Cli.UpdateHost("Incorrect Credentials", 3);
            }
        }

        private const int cGrip = 16;      // Grip size
        private const int cCaption = 32;   // Caption bar height;

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.LightGray, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {  // Trap WM_NCHITTEST
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    //m.Result = (IntPtr)2;  // HTCAPTION
                    return;
                }
            }
            base.WndProc(ref m);
        }

    }
}
