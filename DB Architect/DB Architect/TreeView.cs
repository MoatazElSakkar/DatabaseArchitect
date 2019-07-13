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
    public partial class TreeView : Window
    {

        public TreeView(Home P):base(P,"TreeView")
        {
            InitializeComponent();
        }


        private void TreeView_Load(object sender, EventArgs e)
        {
            ParentWindow.changeStatus("Syncrionizing...", 3);
            this.Text = Program.server.Name;
            ServerName.Text = Program.server.Name;
            Tree.BeginUpdate();
            Tree.Nodes.Add("%Server", ServerName.Text);
            Tree.Nodes["%Server"].ImageIndex = 0;
            Tree.Nodes["%Server"].Nodes.Add("LoadingPlaceHolder", "Syncronizing...");
            Tree.Nodes["%Server"].Nodes["LoadingPlaceHolder"].ImageIndex = 5;
            Program.server.Charted = false;
            Tree.EndUpdate();
        }

        private void Tree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.ImageIndex == 1 && Program.server.DBS.Find(X => X.Name == e.Node.Text).Charted == false)
            {
                ParentWindow.changeStatus("Syncrionizing...", 3);
                e.Node.TreeView.BeginUpdate();
                List<string> Recd = Program.TA.Survey(e.Node.Text, "Database Tables");

                for (int i = 0; i < Recd.Count; i++)
                {
                    e.Node.Nodes.Add("Table" + i.ToString(), Recd[i]);
                    e.Node.Nodes["Table" + i.ToString()].ImageIndex = 3;
                    e.Node.Nodes["Table" + i.ToString()].SelectedImageIndex = 3;
                }
                e.Node.Nodes["LoadingPlaceHolder"].Remove();
                if (Recd.Count == 0)
                {
                    e.Node.Nodes.Add("Error 109", "No Items Found");
                    e.Node.Nodes["Error 109"].ImageIndex = 4;
                    e.Node.Nodes["Error 109"].SelectedImageIndex = 4;
                }
                Program.server.DBS.Find(X => X.Name == e.Node.Text).Charted = true;
                e.Node.TreeView.EndUpdate();
            }

            else if (e.Node.ImageIndex == 0 && Program.server.Charted == false)
            {
                Program.server.DBS.Clear();
                Program.server.Databases = 0;
                ParentWindow.changeStatus("Syncrionizing...", 3);
                Tree.BeginUpdate();
                Tree.Nodes["%Server"].Nodes.Clear();
                List<string> Recd = Program.TA.Survey(Program.server.Name, "Server");
                for (int i = 0; i < Recd.Count; i++)
                {
                    Tree.Nodes["%Server"].Nodes.Add("%Database" + i.ToString(), Recd[i]);
                    Tree.Nodes["%Server"].Nodes["%Database" + i.ToString()].Nodes.Add("LoadingPlaceHolder", "Loading...");
                    Tree.Nodes["%Server"].Nodes["%Database" + i.ToString()].Nodes["LoadingPlaceHolder"].ImageIndex = 5;
                    Tree.Nodes["%Server"].Nodes["%Database" + i.ToString()].Nodes["LoadingPlaceHolder"].SelectedImageIndex = 5;
                    Tree.Nodes["%Server"].Nodes["%Database" + i.ToString()].ImageIndex = 1;
                    Tree.Nodes["%Server"].Nodes["%Database" + i.ToString()].SelectedImageIndex = 1;
                    Database db = new Database();
                    db.Charted = false;
                    db.Name = Recd[i];
                    Program.server.DBS.Add(db);
                }
                if (Recd.Count == 0)
                {
                    e.Node.Nodes.Add("Error 109", "No Items Found");
                    e.Node.Nodes["Error 109"].ImageIndex = 4;
                    e.Node.Nodes["Error 109"].SelectedImageIndex = 4;
                }
                Tree.EndUpdate();
            }
        }

        private void Tree_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            List<string> Recd=new List<string>();
            if (e.Node.ImageIndex == 1)
            {
                Recd = Program.TA.Survey(e.Node.Text, "Database Tables");
                foreach (Database DB in Program.server.DBS)
                {
                    DB.Charted = false;
                }
            }
            else if (e.Node.ImageIndex == 1)
            {
                Recd = Program.TA.Survey(Program.server.Name, "Server");
                Program.server.Charted = false;
            }
            ParentWindow.changeStatus("Syncrionizing...", 3);
            e.Node.TreeView.BeginUpdate();

            e.Node.Nodes.Clear();
            e.Node.Nodes.Add("LoadingPlaceHolder", "Syncronizing...");
            e.Node.Nodes["LoadingPlaceHolder"].ImageIndex = 0;

            e.Node.TreeView.EndUpdate();
            ParentWindow.changeStatus("Architect Studio Online", 0);
        }

        private void Tree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }

        private void Tree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Tree.SelectedNode = e.Node;
            if (e.Button == MouseButtons.Right)
            {
                if (e.Node.ImageIndex == 0)
                {
                    ServerMenu.Show(Cursor.Position);
                }
                else if (e.Node.ImageIndex == 1)
                {
                    DatabaseMenu.Show(Cursor.Position);
                }
                else if (e.Node.ImageIndex == 3)
                {
                    TableMenu.Show(Cursor.Position);
                }
            }
        }

        #region ServerMenu
        private void SrvrMen_AddDatabase_Click(object sender, EventArgs e)
        {
            Form F = new NewDatabase(ParentWindow);
            F.Show();
            F.FormClosed += (object obj, FormClosedEventArgs FCEA) =>
            {
                Tree.SelectedNode.Collapse();
                Tree.SelectedNode.Expand();
            };
        }

        private void SrvMen_Refresh_Click(object sender, EventArgs e)
        {
            Tree.CollapseAll();
            Tree.Nodes["%Server"].Expand();
        }

        private void SrvMen_Properties_Click(object sender, EventArgs e)
        {
            Form F = new Properties_Dialog(ParentWindow);
            F.Show();
        }
        #endregion

        #region Database Menu
        private void DBMen_NewTable_Click(object sender, EventArgs e)
        {
            Form F = new NewTable(ParentWindow,Tree.SelectedNode.Text);
            F.Show();
            F.FormClosed += (object obj, FormClosedEventArgs FCEA) =>
                {
                    Tree.SelectedNode.Collapse();
                    Tree.SelectedNode.Expand();
                };
        }

        private void DBMen_NewQuery_Click(object sender, EventArgs e)
        {
            Form F = new NewQuery(ParentWindow, Tree.SelectedNode.Text);
            F.Show();
        }

        private void DBMen_Relt_Click(object sender, EventArgs e)
        {

        }

        private void DBMen_Drop_Click(object sender, EventArgs e)
        {
            Dialog F = new Dialog(ParentWindow, "Confirm the request for Database \"" + Tree.SelectedNode.Text + "\" deletion ?");
            F.Show();
            F.FormClosed += (object obj, FormClosedEventArgs Args) =>
            {
                if (F.DialogRes)
                {
                    string Script = "Drop Database";
                    Program.TA.ExecuteNonQueryScript(Script, Tree.SelectedNode.Text);
                    Tree.CollapseAll();
                    Tree.SelectedNode.Expand();
                }
                else
                {

                }
            };
        }

        private void DBMen_Refresh_Click(object sender, EventArgs e)
        {
            Tree.SelectedNode.Collapse();
            Tree.SelectedNode.Expand();
        }

        private void DBmen_Prop_Click(object sender, EventArgs e)
        {
            Form F = new Properties_Dialog(ParentWindow,Tree.SelectedNode.Text);
            F.Show();
        }
        #endregion

        #region TableMenu
        private void Tblmen_DesignView_Click(object sender, EventArgs e)
        {
            Form F = new DesignView(ParentWindow,Tree.SelectedNode.Parent.Text, Tree.SelectedNode.Text);
            F.Show();
        }

        private void Tblmen_EditRecords_Click(object sender, EventArgs e)
        {
            try
            {
                string Script = "Select * From " + Tree.SelectedNode.Text;
                Table Tcx = Program.TA.Query(Script, Tree.SelectedNode.Parent.Text);
                Tcx.Name = Tree.SelectedNode.Text;
                Form F = new TablePreview(Tcx, ParentWindow, true, Tree.SelectedNode.Parent.Text);
                F.Show();
            }
            catch
            {
                Table Tcx = new Table();
                Tcx.Keys.Add(new Key(" "," "));
                Tcx.Name = Tree.SelectedNode.Text;
                Form F = new TablePreview(Tcx, ParentWindow, true, Tree.SelectedNode.Parent.Text);
                F.Show();
            }
        }

        private void Tblmen_ViewRecords_Click(object sender, EventArgs e)
        {
            try
            {
                string Script = "Select * From " + Tree.SelectedNode.Text;
                Table Tcx = Program.TA.Query(Script, Tree.SelectedNode.Parent.Text);
                Form F = new TablePreview(Tcx, ParentWindow);
                F.Show();
            }
            catch
            {
                Table Tcx = new Table();
                Tcx.Keys.Add(new Key(" ", " "));
                Tcx.Name = Tree.SelectedNode.Text;
                Form F = new TablePreview(Tcx, ParentWindow, true, Tree.SelectedNode.Parent.Text);
                F.Show();
            }
        }

        private void Tblmen_Drop_Click(object sender, EventArgs e)
        {
            Dialog F=new Dialog(ParentWindow,"Confirm the request for table \"" + Tree.SelectedNode.Text +"\" deletion ?");
            F.Show();
            F.FormClosed += (object obj, FormClosedEventArgs Args) =>
                {
                    if (F.DialogRes)
                    {
                        string Script = "Drop Table " + Tree.SelectedNode.Text;
                        Program.TA.ExecuteNonQueryScript(Script, Tree.SelectedNode.Parent.Text);
                        Tree.SelectedNode.Parent.Collapse();
                        Tree.SelectedNode.Expand();
                    }
                    else
                    {

                    }
                };
        }

        private void Tblmen_Properties_Click(object sender, EventArgs e)
        {
            Form F = new Properties_Dialog(ParentWindow,  Tree.SelectedNode.Text,Tree.SelectedNode.Parent.Text);
            F.Show();
        }
        #endregion

        private void Tblmen_Rename_Click(object sender, EventArgs e)
        {
            TextBox Tx = new TextBox();
            Tx.Location = new Point(Tree.SelectedNode.Bounds.X+16,Tree.SelectedNode.Bounds.Y+83);
            Tx.Text = Tree.SelectedNode.Text;
            Tx.Size = new Size(Tree.SelectedNode.Bounds.Width, Tree.SelectedNode.Bounds.Height);
            this.Controls.Add(Tx);
            Tx.BringToFront();
            Tx.Focus();
            Tx.Leave += (object obj, EventArgs EA) =>
                {
                    string TableI = Tree.SelectedNode.Text;
                    Tree.SelectedNode.Text = Tx.Text;
                    string Script = "Edit Table " + TableI + " (" + Tx.Text + ")";
                    Program.TA.ExecuteNonQueryScript(Script, Tree.SelectedNode.Parent.Text);
                    this.Controls.Remove(Tx);
                };
        }
    }
}
