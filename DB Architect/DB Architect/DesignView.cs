using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DBA.Structure;
using DBA.Refrences;

namespace DB_Architect
{
    public partial class DesignView : Window
    {
        Table Table;
        Client Cli;
        bool editorIntialized=false;

        object[] items = Datatypes.Datatype_str.Keys.ToArray();
        List<string> AddedKeys = new List<string>();
        List<string> Keys = new List<string>();
        List<string> DeletedKeys = new List<string>();
        List<string> KeysBackup = new List<string>();

        public DesignView(Table _tab,Client _cli)
        {
            Table= _tab;
            Cli = _cli;
            InitializeComponent();
        }

        private void TableView_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            (this as Control).Dock = DockStyle.Fill;
            (TableGrid.Columns[1] as DataGridViewComboBoxColumn).Items.AddRange(items);
            foreach (Key Ki in Table.Keys)
            {
                DataGridViewRow KiRow = new DataGridViewRow();
                var KiName = new DataGridViewTextBoxCell();
                KiName.Value = Ki.Name;
                KiRow.Cells.Add(KiName);
                DataGridViewComboBoxCell KiType = TableGridComboboxCell();
                KiType.Value = Ki.Type.ToString();
                KiRow.Cells.Add(KiType);
                TableGrid.Rows.Add(KiRow);
            }
            editorIntialized = true;            
        }

        DataGridViewComboBoxCell TableGridComboboxCell()
        {
            DataGridViewComboBoxCell TypeBox=new DataGridViewComboBoxCell();
            TypeBox.Items.AddRange(items);
            return TypeBox;
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

                }
            }
        }

        void DisplayProperties(string[] KeyData)
        {

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
            return "";
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
