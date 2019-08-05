using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DBA.Structure;

namespace DB_Architect
{
    public partial class TreeView : Window
    {
        Client Cli;

        public TreeView(Client _cli)
        {
            InitializeComponent();
            Cli = _cli;
        }


        private void TreeView_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            Database DB=Cli.GetServerInformation().Attachment as Database;
            TreeNode Tn=new TreeNode(DB.Name, 4,4);
            foreach (Table T in DB.Tables)
                Tn.Nodes.Add(new TreeNode(T.Name, 5, 5));
            Tree.Nodes.Add(Tn);
        }

        private void Tree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {

        }

        private void Tree_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
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
        }

        private void SrvMen_Refresh_Click(object sender, EventArgs e)
        {
            Tree.CollapseAll();
            Tree.Nodes["%Server"].Expand();
        }

        private void SrvMen_Properties_Click(object sender, EventArgs e)
        {
        }
        #endregion

        #region Database Menu
        private void DBMen_NewTable_Click(object sender, EventArgs e)
        {
        }

        private void DBMen_NewQuery_Click(object sender, EventArgs e)
        {
        }

        private void DBMen_Relt_Click(object sender, EventArgs e)
        {

        }

        private void DBMen_Drop_Click(object sender, EventArgs e)
        {

        }

        private void DBMen_Refresh_Click(object sender, EventArgs e)
        {
            Tree.SelectedNode.Collapse();
            Tree.SelectedNode.Expand();
        }

        private void DBmen_Prop_Click(object sender, EventArgs e)
        {
        }
        #endregion

        #region TableMenu
        private void Tblmen_DesignView_Click(object sender, EventArgs e)
        {
        }

        private void Tblmen_EditRecords_Click(object sender, EventArgs e)
        {
            try
            {
                string Script = "Select * From " + Tree.SelectedNode.Text;
                //Table Tcx = Program.TA.Query(Script, Tree.SelectedNode.Parent.Text);
                //Tcx.Name = Tree.SelectedNode.Text;
                //Form F = new TablePreview(Tcx, ParentWindow, true, Tree.SelectedNode.Parent.Text);
                //F.Show();
            }
            catch
            {
            }
        }

        private void Tblmen_ViewRecords_Click(object sender, EventArgs e)
        {
            try
            {
                string Script = "Select * From " + Tree.SelectedNode.Text;
                //Table Tcx = Program.TA.Query(Script, Tree.SelectedNode.Parent.Text);
                //Form F = new TablePreview(Tcx, ParentWindow);
                //F.Show();
            }
            catch
            {

            }
        }

        private void Tblmen_Drop_Click(object sender, EventArgs e)
        {

        }

        private void Tblmen_Properties_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void Tblmen_Rename_Click(object sender, EventArgs e)
        {
            TextBox Tx = new TextBox();
            Tx.Location = new Point(Tree.SelectedNode.Bounds.X + 16, Tree.SelectedNode.Bounds.Y + 83);
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
                    this.Controls.Remove(Tx);
                };
        }
    }
}
