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
    partial class TablePreview : Window
    {
        Table Table;
        int StartRecCount = 0;

        Client Cli;
        bool Editor = false;

        public TablePreview(Table _table,Client _cli, bool _editor=false)
        {
            Editor = _editor;
            Table = _table;
            Cli = _cli;
            InitializeComponent();
        }



        private void TablePreview_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            int RecordsIndex=0;
            foreach (Key K in Table.Keys)
            {
                TablePreviewGrid.Columns.Add(K.Name, K.Name);
            }
            for (int u=0;u< Table.Records;u++)
            {
                List<string> RowContent = new List<string>();

                foreach (Key K in Table.Keys)
                {
                    RowContent.Add(Datatypes.DecoderFunctions[K.Type](K.DATA[RecordsIndex]));
                }
                RecordsIndex++;

                DataGridViewRow R = new DataGridViewRow();
                R.CreateCells(TablePreviewGrid);
                for (int i = 0; i < Table.Keys.Count; i++)
                {
                    R.Cells[i].Value = RowContent[i];
                }
                TablePreviewGrid.Rows.Add(R);
            }
            StartRecCount = TablePreviewGrid.Rows.Count-1;

            if (Editor)
                IntializeEditorWorkframe();
        }

        private void IntializeEditorWorkframe()
        {
            TablePreviewGrid.ReadOnly = false;
            TablePreviewGrid.CellValueChanged += (object obj, DataGridViewCellEventArgs eGrid) =>
            {
                try
                {
                    int RecIndex = eGrid.RowIndex + 1;
                    string Query = string.Format("UPDATE {0} SET {1} = {2} Where {3}={4}",
                        Table.Name, Table.Keys[eGrid.ColumnIndex].Name,
                        TablePreviewGrid[eGrid.ColumnIndex, eGrid.RowIndex],
                        Table.Keys[0], TablePreviewGrid[0, eGrid.RowIndex]);
                    string Response = Cli.QueryServer(Query).Attachment as string;
                }
                catch
                {
                }
            };

            TablePreviewGrid.RowsRemoved += (object obj, DataGridViewRowsRemovedEventArgs eGrid) =>
            {
                int RecIndex = eGrid.RowIndex + 1;
                string Query = string.Format("DELETE FROM {0} Where {3}={4}",
                    Table.Name, Table.Keys[0], TablePreviewGrid[0, eGrid.RowIndex]);
                string Response = Cli.QueryServer(Query).Attachment as string;
            };
        }
    }
}
