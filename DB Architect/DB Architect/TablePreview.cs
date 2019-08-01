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
    partial class TablePreview : Window
    {
        Table Subject;
        List<int> Added=new List<int>();
        int StartRecCount = 0;
        public TablePreview(Table T,Home P):base(P,"TablePreview")
        {
            Subject = T;
            InitializeComponent();
        }

        bool editor = false;
        string Database = "";

        public TablePreview(Table T, Home P,bool Edit,string DB)
            : base(P, "TablePreview")
        {
            editor = Edit;
            Database = DB;
            Subject = T;
            InitializeComponent();
        }

        private void TablePreview_Load(object sender, EventArgs e)
        {
            int RecordsIndex=0;
            foreach (Key K in Subject.Keys)
            {
                TablePreviewGrid.Columns.Add(K.Name, K.Name);
            }
            for (int u=0;u< Subject.Keys[0].Records.Count;u++)
            {
                List<string> RowContent = new List<string>();

                foreach (Key K2 in Subject.Keys)
                {
                    RowContent.Add(K2.Records[RecordsIndex]);
                }
                RecordsIndex++;

                DataGridViewRow R = new DataGridViewRow();
                R.CreateCells(TablePreviewGrid);
                for (int i = 0; i < Subject.Keys.Count; i++)
                {
                    R.Cells[i].Value = RowContent[i];
                }
                TablePreviewGrid.Rows.Add(R);
            }
            StartRecCount = TablePreviewGrid.Rows.Count-1;
            if (editor)
            {
                TablePreviewGrid.ReadOnly = false;
                TablePreviewGrid.CellValueChanged += (object obj, DataGridViewCellEventArgs DGEA) =>
                {
                    //if (DGEA.RowIndex <StartRecCount-1)
                    try
                    {
                        int RecIndex = DGEA.RowIndex + 1;
                        string Script = "Adjust " + Subject.Name + " [" + RecIndex.ToString() + "]" + " =";
                        for (int i = 0; i < TablePreviewGrid.ColumnCount; i++)
                        {
                            string Temp = (string)TablePreviewGrid[i, DGEA.RowIndex].Value;
                            if (Temp != null)
                            {
                                Temp = Temp.Replace(" ", "%20%");
                                Script += " " + Temp;
                            }
                            else
                            {
                                Script += " 0";
                            }
                        }
                        //Program.TA.ExecuteNonQueryScript(Script, Database);
                    }
                    //else
                    catch
                    {
                        string Record = "";
                        for (int i = 0; i < TablePreviewGrid.ColumnCount; i++)
                        {
                            if (TablePreviewGrid[i, DGEA.RowIndex].Value == null)
                            {
                                Record += "0";
                            }
                            else
                            {
                                Record += (string)TablePreviewGrid[i, DGEA.RowIndex].Value;
                            }
                            if (i != TablePreviewGrid.ColumnCount-1)
                            {
                                Record += ",";
                            }
                        }
                        Added.Add(DGEA.RowIndex);
                        string Script = "Add " + Subject.Name + " (" + Record + ")";
                        //Program.TA.ExecuteNonQueryScript(Script, Database);
                        StartRecCount = TablePreviewGrid.Rows.Count-1;
                    }
                };

                TablePreviewGrid.RowsRemoved += (object obj, DataGridViewRowsRemovedEventArgs DGVRREA) =>
                    {
                        int i = 1 + DGVRREA.RowIndex;
                        string Script = "Drop Record " + Subject.Name + " [" + i.ToString() +"]";
                        //Program.TA.ExecuteNonQueryScript(Script, Database);
                    };
            }
        }
    }
}
