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
        Table Source;
        int StartRecCount = 0;

        Client Cli;
        bool Editor = false;

        public TablePreview(Table _table,Client _cli, bool _editor=false)
        {
            Editor = _editor;
            Source = _table;
            Cli = _cli;
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }



        private void TablePreview_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            int RecordsIndex=0;
            foreach (Key K in Source.Keys)
            {
                TablePreviewGrid.Columns.Add(K.Name, K.Name);
            }
            for (int u=0;u< Source.Records;u++)
            {
                List<string> RowContent = new List<string>();

                foreach (Key K in Source.Keys)
                {
                    RowContent.Add(Datatypes.DecoderFunctions[K.Type](K.DATA[RecordsIndex]));
                }
                RecordsIndex++;

                DataGridViewRow R = new DataGridViewRow();
                R.CreateCells(TablePreviewGrid);
                for (int i = 0; i < Source.Keys.Count; i++)
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
                    string Query;
                    if (eGrid.RowIndex >= Source.Records)
                    {
                        if (TablePreviewGrid[0, eGrid.RowIndex].Value as string == "")
                            throw new Exception("Primary Key has to be assigned first");

                        Source.Records++;

                        Query = string.Format("INSERT INTO {0} ({1}) VALUES ({2});",
                        Source.Name, Source.Keys[eGrid.ColumnIndex].Name,
                        TablePreviewGrid[eGrid.ColumnIndex, eGrid.RowIndex].Value);

                    }
                    else
                    {
                        string Value = TablePreviewGrid[eGrid.ColumnIndex, eGrid.RowIndex].Value as string;
                        if (Source.Keys[eGrid.ColumnIndex].Type == DATATYPE.STRING)
                            Value = "\"" + Value + "\"";
                        Query = string.Format("UPDATE {0} SET {1} = {2} Where {3}={4};",
                            Source.Name, Source.Keys[eGrid.ColumnIndex].Name,Value,
                            Source.Keys[0].Name, TablePreviewGrid[0, eGrid.RowIndex].Value);
                    }
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
                    Source.Name, Source.Keys[0], TablePreviewGrid[0, eGrid.RowIndex]);
                string Response = Cli.QueryServer(Query).Attachment as string;
            };
        }
    }
}
