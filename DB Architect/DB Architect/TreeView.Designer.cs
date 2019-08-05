namespace DB_Architect
{
    partial class TreeView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreeView));
            this.Tree = new System.Windows.Forms.TreeView();
            this.TreeViewIcons = new System.Windows.Forms.ImageList(this.components);
            this.ServerMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SrvrMen_AddDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.SrvrMen_Seprator = new System.Windows.Forms.ToolStripSeparator();
            this.SrvMen_Refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.SrvMen_Properties = new System.Windows.Forms.ToolStripMenuItem();
            this.DatabaseMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DBMen_NewTable = new System.Windows.Forms.ToolStripMenuItem();
            this.DBMen_NewQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.DBMen_Relt = new System.Windows.Forms.ToolStripMenuItem();
            this.DBmen_Sep = new System.Windows.Forms.ToolStripSeparator();
            this.DBMen_Drop = new System.Windows.Forms.ToolStripMenuItem();
            this.DBMen_Refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.DBmen_Prop = new System.Windows.Forms.ToolStripMenuItem();
            this.TableMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Tblmen_DesignView = new System.Windows.Forms.ToolStripMenuItem();
            this.Tblmen_EditRecords = new System.Windows.Forms.ToolStripMenuItem();
            this.Tblmen_ViewRecords = new System.Windows.Forms.ToolStripMenuItem();
            this.Tblmen_Sep = new System.Windows.Forms.ToolStripSeparator();
            this.Tblmen_ViewRecords_Drop = new System.Windows.Forms.ToolStripMenuItem();
            this.Tblmen_Rename = new System.Windows.Forms.ToolStripMenuItem();
            this.Tblmen_Properties = new System.Windows.Forms.ToolStripMenuItem();
            this.ServerMenu.SuspendLayout();
            this.DatabaseMenu.SuspendLayout();
            this.TableMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tree
            // 
            this.Tree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Tree.ImageIndex = 0;
            this.Tree.ImageList = this.TreeViewIcons;
            this.Tree.Location = new System.Drawing.Point(0, 3);
            this.Tree.Name = "Tree";
            this.Tree.SelectedImageIndex = 0;
            this.Tree.Size = new System.Drawing.Size(285, 460);
            this.Tree.TabIndex = 0;
            this.Tree.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.Tree_BeforeCollapse);
            this.Tree.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.Tree_BeforeExpand);
            this.Tree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.Tree_NodeMouseClick);
            this.Tree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.Tree_NodeMouseDoubleClick);
            // 
            // TreeViewIcons
            // 
            this.TreeViewIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TreeViewIcons.ImageStream")));
            this.TreeViewIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.TreeViewIcons.Images.SetKeyName(0, "Exclaim.png");
            this.TreeViewIcons.Images.SetKeyName(1, "Activity.png");
            this.TreeViewIcons.Images.SetKeyName(2, "syncronization.png");
            this.TreeViewIcons.Images.SetKeyName(3, "Server.png");
            this.TreeViewIcons.Images.SetKeyName(4, "Database_Frameless.png");
            this.TreeViewIcons.Images.SetKeyName(5, "Table.png");
            // 
            // ServerMenu
            // 
            this.ServerMenu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ServerMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SrvrMen_AddDatabase,
            this.SrvrMen_Seprator,
            this.SrvMen_Refresh,
            this.SrvMen_Properties});
            this.ServerMenu.Name = "ServerMenu";
            this.ServerMenu.Size = new System.Drawing.Size(150, 76);
            // 
            // SrvrMen_AddDatabase
            // 
            this.SrvrMen_AddDatabase.Image = global::DB_Architect.Properties.Resources.Database_Frameless;
            this.SrvrMen_AddDatabase.Name = "SrvrMen_AddDatabase";
            this.SrvrMen_AddDatabase.Size = new System.Drawing.Size(149, 22);
            this.SrvrMen_AddDatabase.Text = "New Database";
            this.SrvrMen_AddDatabase.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.SrvrMen_AddDatabase.Click += new System.EventHandler(this.SrvrMen_AddDatabase_Click);
            // 
            // SrvrMen_Seprator
            // 
            this.SrvrMen_Seprator.Name = "SrvrMen_Seprator";
            this.SrvrMen_Seprator.Size = new System.Drawing.Size(146, 6);
            // 
            // SrvMen_Refresh
            // 
            this.SrvMen_Refresh.Image = global::DB_Architect.Properties.Resources.Activity;
            this.SrvMen_Refresh.Name = "SrvMen_Refresh";
            this.SrvMen_Refresh.Size = new System.Drawing.Size(149, 22);
            this.SrvMen_Refresh.Text = "Refresh";
            this.SrvMen_Refresh.Click += new System.EventHandler(this.SrvMen_Refresh_Click);
            // 
            // SrvMen_Properties
            // 
            this.SrvMen_Properties.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SrvMen_Properties.Name = "SrvMen_Properties";
            this.SrvMen_Properties.Size = new System.Drawing.Size(149, 22);
            this.SrvMen_Properties.Text = "Properties";
            this.SrvMen_Properties.Click += new System.EventHandler(this.SrvMen_Properties_Click);
            // 
            // DatabaseMenu
            // 
            this.DatabaseMenu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.DatabaseMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DBMen_NewTable,
            this.DBMen_NewQuery,
            this.DBMen_Relt,
            this.DBmen_Sep,
            this.DBMen_Drop,
            this.DBMen_Refresh,
            this.DBmen_Prop});
            this.DatabaseMenu.Name = "DatabaseMenu";
            this.DatabaseMenu.Size = new System.Drawing.Size(191, 142);
            // 
            // DBMen_NewTable
            // 
            this.DBMen_NewTable.Image = global::DB_Architect.Properties.Resources.Table;
            this.DBMen_NewTable.Name = "DBMen_NewTable";
            this.DBMen_NewTable.Size = new System.Drawing.Size(190, 22);
            this.DBMen_NewTable.Text = "New Table";
            this.DBMen_NewTable.Click += new System.EventHandler(this.DBMen_NewTable_Click);
            // 
            // DBMen_NewQuery
            // 
            this.DBMen_NewQuery.Image = global::DB_Architect.Properties.Resources.Query_Frameless;
            this.DBMen_NewQuery.Name = "DBMen_NewQuery";
            this.DBMen_NewQuery.Size = new System.Drawing.Size(190, 22);
            this.DBMen_NewQuery.Text = "Query";
            this.DBMen_NewQuery.Click += new System.EventHandler(this.DBMen_NewQuery_Click);
            // 
            // DBMen_Relt
            // 
            this.DBMen_Relt.Image = global::DB_Architect.Properties.Resources.RelationShips2;
            this.DBMen_Relt.Name = "DBMen_Relt";
            this.DBMen_Relt.Size = new System.Drawing.Size(190, 22);
            this.DBMen_Relt.Text = "Manage Relationships";
            this.DBMen_Relt.Click += new System.EventHandler(this.DBMen_Relt_Click);
            // 
            // DBmen_Sep
            // 
            this.DBmen_Sep.Name = "DBmen_Sep";
            this.DBmen_Sep.Size = new System.Drawing.Size(187, 6);
            // 
            // DBMen_Drop
            // 
            this.DBMen_Drop.Name = "DBMen_Drop";
            this.DBMen_Drop.Size = new System.Drawing.Size(190, 22);
            this.DBMen_Drop.Text = "Delete";
            this.DBMen_Drop.Click += new System.EventHandler(this.DBMen_Drop_Click);
            // 
            // DBMen_Refresh
            // 
            this.DBMen_Refresh.Image = global::DB_Architect.Properties.Resources.Activity;
            this.DBMen_Refresh.Name = "DBMen_Refresh";
            this.DBMen_Refresh.Size = new System.Drawing.Size(190, 22);
            this.DBMen_Refresh.Text = "Refresh";
            this.DBMen_Refresh.Click += new System.EventHandler(this.DBMen_Refresh_Click);
            // 
            // DBmen_Prop
            // 
            this.DBmen_Prop.Name = "DBmen_Prop";
            this.DBmen_Prop.Size = new System.Drawing.Size(190, 22);
            this.DBmen_Prop.Text = "Properties";
            this.DBmen_Prop.Click += new System.EventHandler(this.DBmen_Prop_Click);
            // 
            // TableMenu
            // 
            this.TableMenu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TableMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Tblmen_DesignView,
            this.Tblmen_EditRecords,
            this.Tblmen_ViewRecords,
            this.Tblmen_Sep,
            this.Tblmen_ViewRecords_Drop,
            this.Tblmen_Rename,
            this.Tblmen_Properties});
            this.TableMenu.Name = "Table_Menu";
            this.TableMenu.Size = new System.Drawing.Size(145, 142);
            // 
            // Tblmen_DesignView
            // 
            this.Tblmen_DesignView.Image = global::DB_Architect.Properties.Resources.DesignView;
            this.Tblmen_DesignView.Name = "Tblmen_DesignView";
            this.Tblmen_DesignView.Size = new System.Drawing.Size(144, 22);
            this.Tblmen_DesignView.Text = "Design View";
            this.Tblmen_DesignView.Click += new System.EventHandler(this.Tblmen_DesignView_Click);
            // 
            // Tblmen_EditRecords
            // 
            this.Tblmen_EditRecords.Image = global::DB_Architect.Properties.Resources.EditRecords;
            this.Tblmen_EditRecords.Name = "Tblmen_EditRecords";
            this.Tblmen_EditRecords.Size = new System.Drawing.Size(144, 22);
            this.Tblmen_EditRecords.Text = "Edit Records";
            this.Tblmen_EditRecords.Click += new System.EventHandler(this.Tblmen_EditRecords_Click);
            // 
            // Tblmen_ViewRecords
            // 
            this.Tblmen_ViewRecords.Image = global::DB_Architect.Properties.Resources.ViewRecords;
            this.Tblmen_ViewRecords.Name = "Tblmen_ViewRecords";
            this.Tblmen_ViewRecords.Size = new System.Drawing.Size(144, 22);
            this.Tblmen_ViewRecords.Text = "View Records";
            this.Tblmen_ViewRecords.Click += new System.EventHandler(this.Tblmen_ViewRecords_Click);
            // 
            // Tblmen_Sep
            // 
            this.Tblmen_Sep.Name = "Tblmen_Sep";
            this.Tblmen_Sep.Size = new System.Drawing.Size(141, 6);
            // 
            // Tblmen_ViewRecords_Drop
            // 
            this.Tblmen_ViewRecords_Drop.Name = "Tblmen_ViewRecords_Drop";
            this.Tblmen_ViewRecords_Drop.Size = new System.Drawing.Size(144, 22);
            this.Tblmen_ViewRecords_Drop.Text = "Delete";
            this.Tblmen_ViewRecords_Drop.Click += new System.EventHandler(this.Tblmen_Drop_Click);
            // 
            // Tblmen_Rename
            // 
            this.Tblmen_Rename.Name = "Tblmen_Rename";
            this.Tblmen_Rename.Size = new System.Drawing.Size(144, 22);
            this.Tblmen_Rename.Text = "Rename";
            this.Tblmen_Rename.Click += new System.EventHandler(this.Tblmen_Rename_Click);
            // 
            // Tblmen_Properties
            // 
            this.Tblmen_Properties.Name = "Tblmen_Properties";
            this.Tblmen_Properties.Size = new System.Drawing.Size(144, 22);
            this.Tblmen_Properties.Text = "Properties";
            this.Tblmen_Properties.Click += new System.EventHandler(this.Tblmen_Properties_Click);
            // 
            // TreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 465);
            this.ControlBox = false;
            this.Controls.Add(this.Tree);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TreeView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.TreeView_Load);
            this.ServerMenu.ResumeLayout(false);
            this.DatabaseMenu.ResumeLayout(false);
            this.TableMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView Tree;
        private System.Windows.Forms.ImageList TreeViewIcons;
        private System.Windows.Forms.ContextMenuStrip ServerMenu;
        private System.Windows.Forms.ToolStripMenuItem SrvMen_Refresh;
        private System.Windows.Forms.ToolStripMenuItem SrvrMen_AddDatabase;
        private System.Windows.Forms.ToolStripMenuItem SrvMen_Properties;
        private System.Windows.Forms.ToolStripSeparator SrvrMen_Seprator;
        private System.Windows.Forms.ContextMenuStrip DatabaseMenu;
        private System.Windows.Forms.ToolStripMenuItem DBMen_NewTable;
        private System.Windows.Forms.ToolStripMenuItem DBMen_Refresh;
        private System.Windows.Forms.ToolStripSeparator DBmen_Sep;
        private System.Windows.Forms.ToolStripMenuItem DBmen_Prop;
        private System.Windows.Forms.ToolStripMenuItem DBMen_Relt;
        private System.Windows.Forms.ContextMenuStrip TableMenu;
        private System.Windows.Forms.ToolStripMenuItem Tblmen_DesignView;
        private System.Windows.Forms.ToolStripMenuItem Tblmen_EditRecords;
        private System.Windows.Forms.ToolStripMenuItem Tblmen_ViewRecords;
        private System.Windows.Forms.ToolStripSeparator Tblmen_Sep;
        private System.Windows.Forms.ToolStripMenuItem Tblmen_ViewRecords_Drop;
        private System.Windows.Forms.ToolStripMenuItem Tblmen_Properties;
        private System.Windows.Forms.ToolStripMenuItem DBMen_Drop;
        private System.Windows.Forms.ToolStripMenuItem DBMen_NewQuery;
        private System.Windows.Forms.ToolStripMenuItem Tblmen_Rename;
    }
}