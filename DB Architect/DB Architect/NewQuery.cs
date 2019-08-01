using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace DB_Architect
{
    public partial class NewQuery : Window
    {
        string DBasic = "";

        public NewQuery(Home P):base (P,"QueryAssembler")
        {
            InitializeComponent();
        }

        public NewQuery(Home P,string DBBasic)
            : base(P, "QueryAssembler")
        {
            DBasic = DBBasic;
            InitializeComponent();
        }
        
        int currentWordStartIndex = 0;
        int CharCount = 0;

        private void ArchiScript_TextChanged(object sender, EventArgs e)
        {
            if (ArchiScript.TextLength > CharCount && ArchiScript.Text[ArchiScript.Text.Length - 1] == ' ')
            {
                CharCount = ArchiScript.TextLength;
                DeHighlightLastWord();
                currentWordStartIndex = ArchiScript.TextLength;
                CodeTune();
            }
            else if (ArchiScript.TextLength > CharCount && ArchiScript.Text[ArchiScript.Text.Length - 1] == '\n')
            {
                if (DBasic != "")
                {
                    ArchiScript.AppendText(DBasic + " => ");
                }
                CharCount = ArchiScript.TextLength;
                DeHighlightLastWord();
                currentWordStartIndex = ArchiScript.TextLength;
                CodeTune();
            }
            else if (ArchiScript.TextLength < CharCount)
            {
                CharCount = ArchiScript.TextLength;
                if (CharCount != 0)
                {
                    Reset();
                    CodeTune();
                }
                else if (CharCount==0)
                {
                    if (DBasic != "")
                    {
                        ArchiScript.AppendText(DBasic+" => ");
                        CharCount += DBasic.Length + 4;
                    }
                    ArchiScript.ForeColor = Color.Black;
                }
                currentWordStartIndex = ArchiScript.Text.LastIndexOf(' ')+1;
                HighlightCurrentWord();
                if (currentWordStartIndex == -1)
                {
                    currentWordStartIndex = 0;
                }

            }
            else
            {
                CharCount = ArchiScript.TextLength;
                HighlightCurrentWord();
            }
            
        }

        private void HighlightCurrentWord()
        {
            int pos = this.ArchiScript.SelectionStart;
            ArchiScript.SelectionStart = currentWordStartIndex;
            ArchiScript.SelectionLength = ArchiScript.TextLength - currentWordStartIndex;
            ArchiScript.SelectionBackColor = Color.Gainsboro;
            this.ArchiScript.Select(pos, 0);
        }

        private void DeHighlightLastWord()
        {
            int pos = this.ArchiScript.SelectionStart;
            ArchiScript.SelectionStart = currentWordStartIndex;
            ArchiScript.SelectionLength = ArchiScript.TextLength - currentWordStartIndex;
            ArchiScript.SelectionBackColor = Color.White;
            this.ArchiScript.Select(pos, 0);
        }

        private void CodeTune()
        {
            Reset();
            AutoColor("Select ", Color.SteelBlue, 0);
            AutoColor("From ", Color.SteelBlue, 0);
            AutoColor("Where ", Color.SteelBlue, 0);
            AutoColor("Create ", Color.SteelBlue, 0);
            AutoColor("Add ", Color.SteelBlue, 0);
            AutoColor("Adjust ", Color.SteelBlue, 0);
            AutoColor("Edit ", Color.SteelBlue, 0);
            AutoColor("Drop ", Color.SteelBlue, 0);
            AutoColor("And ", Color.SteelBlue, 0);
            AutoColor("Or ", Color.SteelBlue, 0);
            AutoColor("#Max", Color.DarkCyan, 0);
            AutoColor("#Min", Color.DarkCyan, 0);
            AutoColor("True", Color.DarkCyan, 0);
            AutoColor("False", Color.DarkCyan, 0);
            AutoColor("Table ", Color.SteelBlue, 0);
            AutoColor("Key ", Color.SteelBlue, 0);
            AutoColor("Database ", Color.SteelBlue, 0);
        }

        private void Reset()
        {
            int pos = this.ArchiScript.SelectionStart;
            ArchiScript.SelectionStart = 0;
            ArchiScript.SelectionLength = ArchiScript.TextLength;
            ArchiScript.SelectionColor = Color.Black;
            this.ArchiScript.Select(pos, 0);
        }

        private void AutoColor(string Word, Color C, int index)
        {
            if (this.ArchiScript.Text.Contains(Word))
            {
                int i=-1;
                int Selection=this.ArchiScript.SelectionStart;

                while ((i = this.ArchiScript.Text.IndexOf(Word, (i + 1))) != -1)
                {
                    this.ArchiScript.Select((i + index), Word.Length);
                    this.ArchiScript.SelectionColor = C;
                    this.ArchiScript.Select(Selection, 0);
                    this.ArchiScript.SelectionColor = Color.Black;
                }
            }
        }

        private void NewQuery_Load(object sender, EventArgs e)
        {
            ExtendAero(this.Handle, 30);
            if (DBasic != "")
            {
                ArchiScript.AppendText(DBasic+" => ");
            }
        }

        private void NewQuery_Move(object sender, EventArgs e)
        {
            Program.Settings.Windows["NewQuery"] = this.Location;
        }

        private void Execute_btn_Click(object sender, EventArgs e)
        {
            try
            {
                ParentWindow.changeStatus("Syncrionizing...", 3);
                string Script = ArchiScript.Text;

                string[] Codes = Script.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string CodeX in Codes)
                {
                    if (Script.Contains("Select"))
                    {
                        string[] Pars = CodeX.Split(new string[] { " => " }, StringSplitOptions.RemoveEmptyEntries);
                        //Table T = Program.TA.Query(Pars[1], Pars[0]);
                        //Form F = new TablePreview(T, ParentWindow);
                        //F.Show();
                    }
                    else
                    {
                        string[] Pars = CodeX.Split(new string[] { " => " }, StringSplitOptions.RemoveEmptyEntries);
                        //string response = Program.TA.ExecuteNonQueryScript(Pars[1], Pars[0]);
                    }
                }
                stats_lbl.Text = "ArchiScript Execution Complete";
                ErrorPanel.Visible = true;
                ErrorSign.Visible = false;
            }
            catch (Exception ex)
            {
                stats_lbl.Text = ex.Message;
                ErrorPanel.Visible = true;
                ErrorSign.Visible = true;
            }
        }

        private void Execute_btn_MouseEnter(object sender, EventArgs e)
        {
            Execute_btn.Image = Properties.Resources.Execute_Higlihht;
        }

        private void Execute_btn_MouseLeave(object sender, EventArgs e)
        {
            Execute_btn.Image = Properties.Resources.Execute;
        }

        private void QueryFile_Btn_MouseEnter(object sender, EventArgs e)
        {
            QueryFile_Btn.Image = Properties.Resources.QueryFileHighlight;
        }

        private void QueryFile_Btn_MouseLeave(object sender, EventArgs e)
        {
            QueryFile_Btn.Image = Properties.Resources.QueryFile;
        }
        }
    }
