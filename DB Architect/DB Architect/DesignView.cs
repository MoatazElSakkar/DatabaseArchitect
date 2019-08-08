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
using DBA.GlaciaProtocol;

namespace DB_Architect
{
    public partial class DesignView : Window
    {
        Table Table;
        Client Cli;
        bool editorIntialized=false;
        bool NewTable;

        object[] items = Datatypes.Datatype_str.Keys.ToArray();
        List<string> AddedKeys = new List<string>();
        List<string> Keys = new List<string>();
        List<string> DeletedKeys = new List<string>();
        List<string> KeysBackup = new List<string>();

        string Query = "ALTER TABLE ";

        public DesignView(Table _tab,Client _cli,bool createNew= false)
        {
            Table= _tab;
            Cli = _cli;
            NewTable = createNew;
            Query += Table.Name;
            InitializeComponent();
        }

        private void TableView_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            (this as Control).Dock = DockStyle.Fill;
            (TableGrid.Columns[1] as DataGridViewComboBoxColumn).Items.AddRange(items);
            TabName.Text = Table.Name;
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

        private void TableGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
        }

        void DisplayProperties()
        {

        }


        private void TableGrid_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void TableGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!editorIntialized)
                return;

        }

        string assembleRestrictions(int Row)
        {
            return "";
        }


        private void Apply_Click(object sender, EventArgs e)
        {
            Response R;
            //Case it was editing a table
            if (!NewTable)
            {
                R = Cli.QueryServer(Query);
                if (R.Attachment is string)
                {
                    Error.Visible = true;
                    Stats.Text = R.Attachment as string;
                }
                return;
            }

            //Case it was a New table
            Query = "CREATE TABLE {0}(";
            for(int i=0;;Query+=',')
            {
                Query += TableGrid.Rows[i].Cells[0].Value +
                    " " + TableGrid.Rows[i].Cells[1].Value;

                if (i++ == TableGrid.Rows.Count-1)
                    break;
            }

            Query += ");";
            R=Cli.QueryServer(string.Format(Query,TabName.Text));
            NewTable = false;
            if (R.Attachment is string)
            {
                Error.Visible = true;
                Stats.Text = R.Attachment as string;
            }
        }

        private void Add_Row_Click(object sender, EventArgs e)
        {
            TableGrid.Rows.Add(1);
        }
    }
}