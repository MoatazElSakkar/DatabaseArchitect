using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DB_Architect
{
    public class Window:Form
    {
        bool Aero = false;
        public IntPtr Handlerdata;

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

        private MARGINS margins;

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (Aero == true)
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
            else
            {
                base.OnPaintBackground(e);
            }
        }


        public Home ParentWindow
        {
            get;
            set;
        }

        public string InstanceName
        {
            get;
            set;
        }

        public Window()
        {
        }

        public Window(Home Par,string Inst)
        {
            ParentWindow = Par;
            this.Owner = ParentWindow;
            InstanceName = Inst;
            if (Program.Settings.Windows.Keys.Contains(InstanceName))
            {
                this.Location = Program.Settings.Windows[InstanceName];
            }

            this.Move += (object obj, EventArgs EA) =>
            {
                if (Program.Settings.Windows.Keys.Contains(InstanceName))
                {
                    Program.Settings.Windows[InstanceName] = this.Location;
                }
                else
                {
                    Program.Settings.Windows.Add(InstanceName, this.Location);
                }
            };
        }

        public void ExtendAero(IntPtr Data,int margin)
        {
            Aero = true;
            Handlerdata = Data;
            margins = new MARGINS();
            margins.Top = margin;
            margins.Left = 0;
            DwmExtendFrameIntoClientArea(Handlerdata, ref margins);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Window
            // 
            this.ClientSize = new System.Drawing.Size(284, 265);
            this.Name = "Window";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.ResumeLayout(false);

        }
    }
}
