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
            (this as Control).Dock = DockStyle.Fill;
        }


        private void TreeView_Load(object sender, EventArgs e)
        {
            ServerMenu.Renderer = new Home.renderer(new Home.cols());
            DatabaseMenu.Renderer = new Home.renderer(new Home.cols());
            TableMenu.Renderer = new Home.renderer(new Home.cols());
            Toolbar.Renderer = new Home.renderer(new Home.cols());
            Database DB=Cli.GetServerInformation().Attachment as Database;
            TreeNode Tn=new TreeNode(DB.Name, 4,4);
            foreach (Table T in DB.Tables)
                Tn.Nodes.Add(new TreeNode(T.Name, 5, 5));
            Tree.Nodes.Add(Tn);
        }

        private void Tree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
        }

        private void Tree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Tree.SelectedNode = e.Node;
            if (e.Button == MouseButtons.Right)
            {
                if (e.Node.ImageIndex == 3)
                {
                    ServerMenu.Show(Cursor.Position);
                }
                else if (e.Node.ImageIndex == 4)
                {
                    DatabaseMenu.Show(Cursor.Position);
                }
                else if (e.Node.ImageIndex == 5)
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
            Cli.Workspace_Upper.Controls.Add(new DesignView(new Table("Unnamed table"), Cli,true));
        }

        private void DBMen_NewQuery_Click(object sender, EventArgs e)
        {
            Cli.Workspace_Upper.Controls.Clear();
            Cli.Workspace_Upper.Controls.Add(new NewQuery(Cli));
        }

        private void DBMen_Relt_Click(object sender, EventArgs e)
        {

        }

        private void DBMen_Drop_Click(object sender, EventArgs e)
        {

        }

        private void DBMen_Refresh_Click(object sender, EventArgs e)
        {
            Tree.Nodes.Clear();
            Cli.UpdateHost("Updating...", 1, false, true);
            Database DB = Cli.GetServerInformation().Attachment as Database;
            TreeNode Tn = new TreeNode(DB.Name, 4, 4);
            foreach (Table T in DB.Tables)
                Tn.Nodes.Add(new TreeNode(T.Name, 5, 5));
            Tree.Nodes.Add(Tn);
            Tree.ExpandAll();
        }

        private void DBmen_Prop_Click(object sender, EventArgs e)
        {
        }
        #endregion

        #region TableMenu
        private void Tblmen_DesignView_Click(object sender, EventArgs e)
        {
            Cli.UpdateHost("Processing Query...", 0, false, true);
            Database DB=Cli.GetServerInformation().Attachment as Database;
            Cli.Workspace_Upper.Controls.Add(new DesignView(DB.getTable(Tree.SelectedNode.Text), Cli));
        }

        private void Tblmen_EditRecords_Click(object sender, EventArgs e)
        {
            try
            {
                Cli.UpdateHost("Processing Query...", 0, false, true);
                string Script = String.Format("SELECT * FROM {0};", Tree.SelectedNode.Text);
                Table Tcx = Cli.QueryServer(Script).Attachment as Table;
                Cli.Workspace_Upper.Controls.Add(new TablePreview(Tcx, Cli,true));
            }
            catch
            {
            }
        }

        private void Tblmen_ViewRecords_Click(object sender, EventArgs e)
        {
            try
            {
                string Script = String.Format("SELECT * FROM {0};", Tree.SelectedNode.Text);
                Cli.UpdateHost("Processing Query...", 0, false, true);
                Table Tcx = Cli.QueryServer(Script).Attachment as Table;
                Cli.Workspace_Upper.Controls.Add(new TablePreview(Tcx, Cli));
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
            TextBox RenameBox = new TextBox();
            RenameBox.Location = new Point(Tree.SelectedNode.Bounds.X, Tree.SelectedNode.Bounds.Y+24);
            RenameBox.Text = Tree.SelectedNode.Text;
            RenameBox.Size = new Size(Tree.SelectedNode.Bounds.Width+10, Tree.SelectedNode.Bounds.Height);
            this.Controls.Add(RenameBox);
            RenameBox.BringToFront();
            RenameBox.Focus();
            RenameBox.Leave += (object obj, EventArgs EA) =>
                {
                    string Table_NewName = Tree.SelectedNode.Text;
                    Tree.SelectedNode.Text = RenameBox.Text;
                    this.Controls.Remove(RenameBox);
                };
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tree.Nodes.Clear();
            Cli.UpdateHost("Updating...", 1, false, true);
            Database DB = Cli.GetServerInformation().Attachment as Database;
            TreeNode Tn = new TreeNode(DB.Name, 4, 4);
            foreach (Table T in DB.Tables)
                Tn.Nodes.Add(new TreeNode(T.Name, 5, 5));
            Tree.Nodes.Add(Tn);
            Tree.ExpandAll();
        }
    }
}
