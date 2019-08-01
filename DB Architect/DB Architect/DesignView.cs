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
    public partial class DesignView : Window
    {
        string DBname;
        string Tabname;
        bool editorIntialized=false;

        List<string> DataTypes = new List<string>(){"Int", "String", "Float", "Boolean"};
        List<string> AddedKeys = new List<string>();
        List<string> Keys = new List<string>();
        List<string> DeletedKeys = new List<string>();
        List<string> KeysBackup = new List<string>();

        public DesignView(Home P,string Database,string Table):base (P,"DesignView")
        {
            DBname = Database;
            Tabname = Table;
            InitializeComponent();
        }

        private void TableView_Load(object sender, EventArgs e)
        {
            //Keys=Program.TA.Survey(Tabname + "." + DBname, "Table Keys");
            ExtendAero(this.Handle,32);
            KeysBackup = new List<string>(Keys);

            foreach (string Sx in Keys)
            {
                string[] KeyData = Sx.Split('-');
                DataGridViewRow DGVR = new DataGridViewRow();
                var DGVC = new DataGridViewTextBoxCell();
                DGVC.Value = KeyData[0];
                DGVR.Cells.Add(DGVC);
                DataGridViewComboBoxCell DGVCBC = TableGridComboboxCell();
                DGVCBC.Value = KeyData[2];
                DGVR.Cells.Add(DGVCBC);
                TableGrid.Rows.Add(DGVR);
            }

            PKBox.Checked = false;
            UKBox.Checked = false;
            UKBox.Enabled = true;
            MaxBox.Clear();
            MinBox.Clear();
            AllowedChars.Clear();
            KeyName.Text = "";
            TableGrid[1, TableGrid.Rows.Count - 1].Value = "Int";
            editorIntialized = true;
            
        }

        DataGridViewComboBoxCell TableGridComboboxCell()
        {
            DataGridViewComboBoxCell DGVCBC=new DataGridViewComboBoxCell();
            foreach (string S in DataTypes)
            {
                DGVCBC.Items.Add(S);
            }
            return DGVCBC;
        }

        private void Execute_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow R in TableGrid.Rows)
            {

            }
        }

        private void TableGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView DGV = (DataGridView)sender;
            if (e.RowIndex >= 0)
            {
                if (e.RowIndex < Keys.Count)
                {
                    string[] KeyData = Keys[e.RowIndex].Split('-');
                    DisplayProperties(KeyData);
                }
                else if (e.RowIndex < Keys.Count + AddedKeys.Count)
                {
                    string[] KeyData = AddedKeys[e.RowIndex-Keys.Count].Split('-');
                    DisplayProperties(KeyData);
                }
                else
                {
                    PKBox.Checked = false;
                    UKBox.Checked = false;
                    UKBox.Enabled = true;
                    MaxBox.Clear();
                    MinBox.Clear();
                    AllowedChars.Clear();
                    KeyName.Text = "";
                }
            }
        }

        void DisplayProperties(string[] KeyData)
        {
            KeyName.Text = KeyData[0] + " : " + KeyData[2];
            if (KeyData[1] == "PK")
            {
                PKBox.Checked = true;
                UKBox.Checked = true;
                UKBox.Enabled = false;
            }
            else if (KeyData[1] == "UK")
            {
                PKBox.Checked = false;
                UKBox.Checked = true;
                UKBox.Enabled = true;
            }
            else if (KeyData[1] == "SK")
            {
                PKBox.Checked = false;
                UKBox.Checked = false;
                UKBox.Enabled = true;
            }

            MinBox.Text = int.Parse(KeyData[3]).ToString();
            if (KeyData[4] == "%")
            {
                MaxBox.Text = int.MaxValue.ToString();
            }
            else
            {
                MaxBox.Text = KeyData[4];
            }
        }

        private void SaveBtn_MouseEnter(object sender, EventArgs e)
        {
            SaveBtn.Image = Properties.Resources.SaveHighlight;
        }

        private void SaveBtn_MouseLeave(object sender, EventArgs e)
        {
            SaveBtn.Image = Properties.Resources.Save;
        }

        private void TableGrid_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            TableGrid[1, e.Row.Index].Value = "Int";
        }

        private void TableGrid_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            
        }

        private void TableGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (editorIntialized)
            {
                if (e.RowIndex >= 0)
                {
                    if (e.RowIndex < Keys.Count)
                    {
                        Keys[e.RowIndex] = TableGrid[0, e.RowIndex].Value + assembleRestrictions(e.RowIndex);
                    }
                    else
                    {
                        if (e.RowIndex<Keys.Count+AddedKeys.Count)
                        {
                            AddedKeys[e.RowIndex - Keys.Count] = TableGrid[0, e.RowIndex].Value + assembleRestrictions(e.RowIndex);
                        }
                        else
                        {

                           if ((string)TableGrid[0, e.RowIndex].Value != "" && (string)TableGrid[0, e.RowIndex].Value != null)
                           {
                               AddedKeys.Add((string)TableGrid[0, e.RowIndex].Value + assembleRestrictions(e.RowIndex));
                           }
                        }
                    }
                }
            }
        }

        string assembleRestrictions(int Row)
        {
            string Restr = "";

            if (PKBox.Checked)
            {
                Restr += "-PK";
            }
            else if (UKBox.Checked)
            {
                Restr += "-UK";
            }
            else
            {
                Restr += "-SK";
            }

            Restr += "-"+TableGrid[1, Row].Value;

            if (MinBox.Text != "")
            {
                int Min = 0;
                int.TryParse(MinBox.Text,out Min);
                Restr += "-" + Min.ToString();
            }
            else if (MaxBox.Text=="")
            {
                Restr += "-0";
            }

            if (MaxBox.Text != "")
            {
                int Max = 0;
                int.TryParse(MaxBox.Text,out Max);
                Restr += "-" + Max.ToString() ;
            }
            else if (MaxBox.Text=="")
            {
                Restr += "-"+int.MaxValue.ToString();
            }

            return Restr;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            SaveBtn.Image = Properties.Resources.Save;
            Timer T = new Timer();
            T.Interval=150;
            T.Start();
            T.Tick += (object obj, EventArgs EA) =>
                {
                    T.Stop();
                    SaveBtn.Image = Properties.Resources.SaveHighlight;
                };
            try
            {
                foreach (string S in Keys)
                {
                    string Script = "Edit Key " + KeysBackup[Keys.IndexOf(S)].Split('-')[0] + " (" + S.Split(new char[] { '-' }, 2)[0] + ",-" + S.Split(new char[] { '-' }, 2)[1] + "," + Tabname + ")";
                }

                foreach (string S in DeletedKeys)
                {
                    string Script = "Drop Key " + S.Split('-')[0] + "." + Tabname;
                }

                foreach (string S in AddedKeys)
                {
                    string Script = "Create Key" + " (" + S.Split(new char[] { '-' }, 2)[0] + ",-" + S.Split(new char[] { '-' }, 2)[1].Replace(int.MaxValue.ToString(), "%") + "," + Tabname + ")";
                }
            }
            catch
            {
                Stats.Text = "Database inconsistent with the attempted modifications";
                Error.Visible = true;
            }
        }

        private void TableGrid_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (e.RowIndex < Keys.Count && e.RowIndex >= 0)
            {
                DeletedKeys.Add(Keys[e.RowIndex].Split('-')[0]);
                Keys.RemoveAt(e.RowIndex);
            }
            else
            {
                AddedKeys.RemoveAt(e.RowIndex - (Keys.Count + DeletedKeys.Count));
            }
        }
    }
}
