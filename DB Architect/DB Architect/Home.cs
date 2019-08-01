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

namespace DB_Architect
{
    public partial class Home : Form
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct MARGINS
        {
            public int Left;
            public int Right;
            public int Top;
            public int Bottom;
        }

        [DllImport("dwmapi.dll", PreserveSig = false)]
        static extern void DwmExtendFrameIntoClientArea(IntPtr hwnd, ref MARGINS margins);

        public Home()
        {
            //Loading configuration and contacting service
            InitializeComponent();

        }

        private MARGINS margins;

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.Clear(Color.Black);
            Rectangle clientArea = new Rectangle(
                    margins.Left,
                    margins.Top,
                    this.ClientRectangle.Width - margins.Left - margins.Right,
                    this.ClientRectangle.Height - margins.Top - margins.Bottom
                );
            Brush b = new SolidBrush(this.BackColor);
            e.Graphics.FillRectangle(b, clientArea);
        }

        public void ResetForConnection()
        {
            Status.Text = "Architect Studio Online";
            Status.Visible = true;
            ServerData.Visible = true;
            ServerName.Text = Program.server.Name;
            IPA.Visible = false;
            while (ServerData.Size.Height != 85)
            {
                ServerData.Size = new Size(ServerData.Size.Width, ServerData.Size.Height + 1);
            }
            Form F = new TreeView(this);
            F.Show();
            ArchitectLogo.Enabled = true;
            StatusPic.Image = StatusList.Images[0];
        }

        private void Home_Load(object sender, EventArgs e)
        {
            //internal windows command increasing the aero effect
            margins = new MARGINS();
            margins.Top = 50;
            margins.Left = 0;
            DwmExtendFrameIntoClientArea(this.Handle, ref margins);

            System.Windows.Forms.Timer T = new System.Windows.Forms.Timer();
            T.Interval = 200;
            T.Start();
            T.Tick += (object Invoker, EventArgs EA) =>
                {
                    T.Stop();
                    Form F = new WelcomeScreen(this);
                    F.Show();
                };
        }

        public void changeStatus(string S, int i)
        {
            Status.Text = S;
            StatusPic.Image = StatusList.Images[i];
            System.Windows.Forms.Timer T = new System.Windows.Forms.Timer();
            T.Interval = 200;
            T.Start();
            T.Tick += (object obj, EventArgs EA) =>
                {
                    T.Stop();
                    Status.Text = "Architect Studio Online";
                    StatusPic.Image = StatusList.Images[0];
                };
        }

        private void ArchitectLogo_MouseEnter(object sender, EventArgs e)
        {
            ArchitectLogo.Image = Properties.Resources.Architect_Logo_Highlight;
        }

        private void ArchitectLogo_MouseLeave(object sender, EventArgs e)
        {
            ArchitectLogo.Image = Properties.Resources.Architect_Logo;
        }

        private void AddNew_MouseEnter(object sender, EventArgs e)
        {
            AddNew.BackColor = Color.DarkOrange;
            AddMenu.Visible = true;
        }

        private void AddNew_MouseLeave(object sender, EventArgs e)
        {
            AddNew.BackColor = Color.Transparent;
        }

        private void Options_MouseEnter(object sender, EventArgs e)
        {
            Options.BackColor = Color.DarkOrange;
            AddMenu.Visible = false;
        }

        private void Options_MouseLeave(object sender, EventArgs e)
        {
            Options.BackColor = Color.Transparent;
        }

        private void Help_MouseEnter(object sender, EventArgs e)
        {
            About.BackColor = Color.DarkOrange;
            AddMenu.Visible = false;
        }

        private void Help_MouseLeave(object sender, EventArgs e)
        {
            About.BackColor = Color.Transparent;
        }

        private void Disconnect_MouseEnter(object sender, EventArgs e)
        {
            Disconnect.BackColor = Color.DarkOrange;
            AddMenu.Visible = false;
        }

        private void Disconnect_MouseLeave(object sender, EventArgs e)
        {
            Disconnect.BackColor = Color.Transparent;
        }

        private void ArchitectLogo_Click(object sender, EventArgs e)
        {
            if (MenuPnl.Visible == false)
            {
                MenuPnl.Visible = true;
            }
            else
            {
                MenuPnl.Visible = false;
                AddMenu.Visible = false;
            }
        }

        private void DatabaseBtn_MouseEnter(object sender, EventArgs e)
        {
            AddNew.BackColor = Color.DarkOrange;
            DatabaseBtn.BackColor = Color.DarkOrange;
        }

        private void DatabaseBtn_MouseLeave(object sender, EventArgs e)
        {
            DatabaseBtn.BackColor = Color.Transparent;
            AddNew.BackColor = Color.Transparent;
        }

        private void TableBtn_MouseEnter(object sender, EventArgs e)
        {
            AddNew.BackColor = Color.DarkOrange;
            TableBtn.BackColor = Color.DarkOrange;
        }

        private void TableBtn_MouseLeave(object sender, EventArgs e)
        {
            TableBtn.BackColor = Color.Transparent;
            AddNew.BackColor = Color.Transparent;
        }

        private void QueryBtn_MouseEnter(object sender, EventArgs e)
        {
            AddNew.BackColor = Color.DarkOrange;
            QueryBtn.BackColor = Color.DarkOrange;
        }

        private void QueryBtn_MouseLeave(object sender, EventArgs e)
        {
            QueryBtn.BackColor = Color.Transparent;
            AddNew.BackColor = Color.Transparent;
        }

        private void QueryBtn_Click(object sender, EventArgs e)
        {
            MenuPnl.Visible = false;
            AddMenu.Visible = false;
            Form F = new NewQuery(this);
            F.Show();
        }

        private void TableBtn_Click(object sender, EventArgs e)
        {
            MenuPnl.Visible = false;
            AddMenu.Visible = false;
            Form F = new NewTable(this);
            F.Show();
        }

        private void DatabaseBtn_Click(object sender, EventArgs e)
        {
            MenuPnl.Visible = false;
            AddMenu.Visible = false;
            Form F = new NewDatabase(this);
            F.Show();
        }

        private void Options_Click(object sender, EventArgs e)
        {
            MenuPnl.Visible = false;
            AddMenu.Visible = false;
            Form F = new Options(this);
            F.Show();
        }

        private void About_Click(object sender, EventArgs e)
        {
            MenuPnl.Visible = false;
            AddMenu.Visible = false;
            Form F = new AboutArchitect(this);
            F.Show();
        }

        private void Disconnect_Click(object sender, EventArgs e)
        {
            changeStatus("Disconnecting...", 3);
            Application.Exit();
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //Program.TA.Terminate();
            }
            catch
            {
            }
        }

        private void ChangePass_MouseEnter(object sender, EventArgs e)
        {
            ChangePass.Cursor = Cursors.Hand;
            ChangePass.ForeColor = Color.DodgerBlue;
        }

        private void ChangePass_MouseLeave(object sender, EventArgs e)
        {
            ChangePass.Cursor = Cursors.Default;
            ChangePass.ForeColor = Color.MidnightBlue;
        }

        private void ChangePass_Click(object sender, EventArgs e)
        {
            Form F = new ChangePassword(this);
            F.Show();
        }
    }
}
