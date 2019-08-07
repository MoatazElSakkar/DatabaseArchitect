using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using DBA.GlaciaProtocol;
using DBA.Structure;

namespace DB_Architect
{
    public partial class NewQuery : Window
    {
        Client Cli;

        int currentLocation = 0;
        bool literal = false;
        char Current
        {
            get
            {
                if (ArchiScript.Text.Length > currentLocation)
                    return ArchiScript.Text[currentLocation];
                else
                    return '\0';
            }
        }

        bool EndOfText
        {
            get
            {
                return currentLocation >= ArchiScript.Text.Length;
            }
        }
        char[] delimiters = { ' ', '\t', '\n', '\r', ';' };

        static List<string>OpRefrence = new List<string>
        {"OR","AN","NO",",","*","+","-","/","x","=",">","<","(",")"};

        string getToken()
        {
            string bufferText = "";

            if (EndOfText)
            {
                //Register Inconsistency
                return string.Empty;
            }
            else if (Current == ';')
            {
                return ";";
            }

            while (delimiters.Contains(Current)) { currentLocation++; }
            if (OpRefrence.Contains(Current.ToString()))
            {
                bufferText += Current;
                currentLocation++;
                return bufferText;
            }

            bool Literal = (Current == '\"');
            literal = Literal;
            if (Literal)
            {
                bufferText += Current;
                currentLocation++;
            }
            bool Escape = false;

            while (!EndOfText &&
                (!delimiters.Contains(Current) || Literal) &&
                !OpRefrence.Contains(Current.ToString()) &&
                (!Literal || Current != '\"') || Escape)
            {
                Escape = (Current == '\\') && !Escape;
                bufferText += Current;
                currentLocation++;
            }
            if (Literal) { currentLocation++; }
            return bufferText;

        }
        Dictionary<string, Color> Colors = new Dictionary<string, Color>()
        {
            {"SELECT",Color.Purple },
            {"FROM",Color.Purple },
            {"WHERE",Color.Purple },
            {"UPDATE",Color.Purple },
            {"SET",Color.Purple },
            {"DELETE",Color.Purple },
            {"INSERT",Color.Purple },
            {"INTO",Color.Purple },
            {"DROP",Color.Purple },

        };
        int maxCharted=0;

        void scanUntil(bool accumaltive=false)
        {
            int current = accumaltive? maxCharted: 0;
            while (current<ArchiScript.SelectionStart && !EndOfText)
            {
                string Token = getToken();
                if (Colors.ContainsKey(Token.ToUpper()))
                {
                    int Selection = ArchiScript.SelectionStart;
                    ArchiScript.Select(currentLocation - Token.Length, Token.Length);
                    ArchiScript.SelectionColor = Colors[Token.ToUpper()];
                    ArchiScript.Select(Selection, 0);
                    ArchiScript.SelectionColor = Color.Black;
                    current += Token.Length;
                    maxCharted = current+1;
                }
                else
                {
                    int Selection = ArchiScript.SelectionStart;
                    ArchiScript.Select(ArchiScript.SelectionStart - Token.Length, Token.Length);
                    ArchiScript.SelectionColor = literal?Color.DarkRed: Color.Black;
                    literal = false;
                    ArchiScript.Select(Selection, 0);
                    ArchiScript.SelectionColor = Color.Black;
                    current += Token.Length;
                }
            }
            currentLocation = maxCharted;
        }

        public NewQuery(Client _cli)
        {
            Cli = _cli;
            InitializeComponent();
            (this as Control).Dock = DockStyle.Fill;
        }

        int CharCount = 0;

        private void ArchiScript_TextChanged(object sender, EventArgs e)
        {
            if (ArchiScript.TextLength < CharCount)
            {
                CharCount = ArchiScript.TextLength;
                if (CharCount != 0)
                {
                    if (CharCount < maxCharted)
                        maxCharted = 0;
                    currentLocation = 0;
                    scanUntil();
                }
                else if (CharCount == 0)
                {
                    ArchiScript.Select(0, 0);
                    ArchiScript.SelectionColor = Color.Black;
                    currentLocation = 0;
                    maxCharted = 0;
                }
            }
            else
            {
                CharCount = ArchiScript.TextLength;
                scanUntil(true);
            }
        }

        private void NewQuery_Load(object sender, EventArgs e)
        {
            Toolbar.Renderer = new Home.renderer(new Home.cols());
        }

        private void NewQuery_Move(object sender, EventArgs e)
        {
            Program.Settings.Windows["NewQuery"] = this.Location;
        }

        private void RunQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string Script = ArchiScript.Text;
                Response R = Cli.QueryServer(Script) as Response;
                if (R.Attachment is string)
                    stats_lbl.Text = R.Attachment as string;
                else if (R.Attachment is Table)
                    Cli.Workspace_Upper.Controls.Add(new TablePreview(R.Attachment as Table, Cli));
                ErrorPanel.Visible = true;
                ErrorSign.Visible = true;
            }
            catch (Exception ex)
            {
                stats_lbl.Text = ex.Message;
                ErrorPanel.Visible = true;
                ErrorSign.Visible = true;
            }
        }
    }
}