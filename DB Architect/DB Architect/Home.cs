using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using DBA.GlaciaProtocol;

namespace DB_Architect
{
    public partial class Home : Form
    {
        Client Cli;

        public delegate void statusChange(string stat, int index);

        List<Image> stati = new List<Image>()
        {
            Properties.Resources.syncronization,
            Properties.Resources.DatabaseSync,
            Properties.Resources.QMark,
            Properties.Resources.Exclaim,
            Properties.Resources.DC,
            Properties.Resources.Server
        };
        public void changeStatus(string stat, int index)
        {
            Status.Text = stat;
            StatusPic.Image = stati[index];
        }

        public Home()
        {
            //Loading configuration and contacting service
            InitializeComponent();
            Cli = new Client(changeStatus);
            Cli.Connected += Cli_Connected;
            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private void Cli_Connected(Client C, EventArgs E)
        {
            LeftFormPanel.ControlAdded += ActivePanel_ControlAdded;
            LeftFormPanel.Controls.Add(new TreeView(Cli));
            Status.Text = "Syncronizing...";
            StatusPic.Image = Properties.Resources.Activity;
        }

        public void ResetForConnection()
        {

        }

        private const int cGrip = 16;      // Grip size
        private const int cCaption = 32;   // Caption bar height;
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.LightGray,new Rectangle(0,0,this.Width-1,this.Height-1));
            Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
            ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {  // Trap WM_NCHITTEST
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;  // HTCAPTION
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17; // HTBOTTOMRIGHT
                    return;
                }
            }
            base.WndProc(ref m);
        }

        private class renderer : ToolStripProfessionalRenderer
        {
            public renderer(ProfessionalColorTable PTC)
                : base(new cols())
            {
                base.RoundedEdges = true;

            }

            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                if (!e.Item.Selected)
                {
                    base.OnRenderMenuItemBackground(e);
                }
                else if (e.Item.Pressed)
                {
                    Rectangle rc = new Rectangle(new Point(-1, 0), new Size(e.Item.Width, e.Item.Height));
                    e.Graphics.FillRectangle(Brushes.LightBlue, rc);
                    e.Graphics.DrawRectangle(Pens.Gray, 0, 0, rc.Width - 1, rc.Height);
                }
                else
                {
                    Rectangle rce = new Rectangle(new Point(-1, 0), new Size(3, e.Item.Height));
                    e.Graphics.FillRectangle(Brushes.LightBlue, rce);
                    e.Graphics.DrawRectangle(Pens.LightBlue, 0, 0, rce.Width - 3, rce.Height);
                    Rectangle rc = new Rectangle(new Point(2, 0), new Size(e.Item.Size.Width - 2, e.Item.Height));
                    e.Graphics.FillRectangle(Brushes.LightBlue, rc);
                    e.Graphics.DrawRectangle(Pens.LightBlue, 1, 0, rc.Width - 3, rc.Height);
                }
            }
        }

        private class cols : ProfessionalColorTable
        {
            public override Color MenuItemSelected
            {
                // when the menu is selected
                get { return Color.Blue; }
            }
            public override Color MenuItemSelectedGradientBegin
            {
                get { return Color.Black; }
            }
            public override Color MenuItemSelectedGradientEnd
            {
                get { return Color.White; }
            }
        }

        private void Home_Load(object sender, EventArgs e)
        {
            Toolbox.Renderer = new renderer(new cols());
            Captionbox.Renderer = new renderer(new cols());
            //LeftFormPanel.Visible = false;
            //RightFormPanel.Visible = false;
            ActivePanel.ControlAdded += ActivePanel_ControlAdded;
            ActivePanel.Controls.Add(new WelcomeScreen(Cli));
            StatusPic.Image = Properties.Resources.DC;
            Status.Text = "Database Architect disconnected";
        }

        private void ActivePanel_ControlAdded(object sender, ControlEventArgs e)
        {
            e.Control.BringToFront();
            e.Control.Show();
        }
     
        private void Disconnect_Click(object sender, EventArgs e)
        {
            changeStatus("Disconnecting...", 0);
            Application.Exit();
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {

            }
            catch
            {

            }
        }

        private void ChangePass_Click(object sender, EventArgs e)
        {
            Form F = new ChangePassword(this);
            F.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void maximizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                WindowState = FormWindowState.Normal;
            else if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Cli.CliSocket.Transit.Connected) { return; }
            Cli.Disconnect();
            RightFormPanel.Controls.Clear();
            LeftFormPanel.Controls.Clear();
            ActivePanel.Controls.Add(new WelcomeScreen(Cli));
            StatusPic.Image = Properties.Resources.DC;
            Status.Text = "Database Architect disconnected";
        }
    }
}
