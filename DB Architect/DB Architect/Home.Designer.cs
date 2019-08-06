namespace DB_Architect
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.Status = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.Label();
            this.Toolbox = new System.Windows.Forms.MenuStrip();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.queryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relationshipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.execToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Captionbox = new System.Windows.Forms.MenuStrip();
            this.minimizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maximizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusPic = new System.Windows.Forms.PictureBox();
            this.ArchitectLogo = new System.Windows.Forms.PictureBox();
            this.ActivePanel = new System.Windows.Forms.Panel();
            this.RightLowerPanel = new System.Windows.Forms.Panel();
            this.RightUpperPanel = new System.Windows.Forms.Panel();
            this.LeftFormPanel = new System.Windows.Forms.Panel();
            this.Toolbox.SuspendLayout();
            this.Captionbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StatusPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArchitectLogo)).BeginInit();
            this.ActivePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Status
            // 
            this.Status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Status.AutoSize = true;
            this.Status.BackColor = System.Drawing.Color.Transparent;
            this.Status.ForeColor = System.Drawing.Color.Black;
            this.Status.Location = new System.Drawing.Point(30, 706);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(0, 13);
            this.Status.TabIndex = 5;
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Kozuka Gothic Pr6N R", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(59, 14);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(177, 33);
            this.Title.TabIndex = 13;
            this.Title.Text = "Database Architect";
            // 
            // Toolbox
            // 
            this.Toolbox.Dock = System.Windows.Forms.DockStyle.None;
            this.Toolbox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.historyToolStripMenuItem,
            this.execToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.disconnectToolStripMenuItem});
            this.Toolbox.Location = new System.Drawing.Point(10, 53);
            this.Toolbox.Name = "Toolbox";
            this.Toolbox.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.Toolbox.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.Toolbox.Size = new System.Drawing.Size(200, 28);
            this.Toolbox.TabIndex = 14;
            this.Toolbox.Text = "menuStrip1";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionToolStripMenuItem,
            this.databaseToolStripMenuItem,
            this.tableToolStripMenuItem,
            this.queryToolStripMenuItem,
            this.relationshipToolStripMenuItem});
            this.connectToolStripMenuItem.Image = global::DB_Architect.Properties.Resources.AddNew;
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Padding = new System.Windows.Forms.Padding(8, 8, 4, 0);
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(32, 28);
            // 
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.BackgroundImage = global::DB_Architect.Properties.Resources.MenustripBackground;
            this.connectionToolStripMenuItem.Image = global::DB_Architect.Properties.Resources.Server;
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.connectionToolStripMenuItem.Text = "Connection";
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("databaseToolStripMenuItem.BackgroundImage")));
            this.databaseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("databaseToolStripMenuItem.Image")));
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.databaseToolStripMenuItem.Text = "Database";
            // 
            // tableToolStripMenuItem
            // 
            this.tableToolStripMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableToolStripMenuItem.BackgroundImage")));
            this.tableToolStripMenuItem.Image = global::DB_Architect.Properties.Resources.Table;
            this.tableToolStripMenuItem.Name = "tableToolStripMenuItem";
            this.tableToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.tableToolStripMenuItem.Text = "Table";
            // 
            // queryToolStripMenuItem
            // 
            this.queryToolStripMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("queryToolStripMenuItem.BackgroundImage")));
            this.queryToolStripMenuItem.Image = global::DB_Architect.Properties.Resources.Query_Frameless;
            this.queryToolStripMenuItem.Name = "queryToolStripMenuItem";
            this.queryToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.queryToolStripMenuItem.Text = "Query";
            // 
            // relationshipToolStripMenuItem
            // 
            this.relationshipToolStripMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("relationshipToolStripMenuItem.BackgroundImage")));
            this.relationshipToolStripMenuItem.Image = global::DB_Architect.Properties.Resources.RelationShips2;
            this.relationshipToolStripMenuItem.Name = "relationshipToolStripMenuItem";
            this.relationshipToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.relationshipToolStripMenuItem.Text = "Relationship";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Image = global::DB_Architect.Properties.Resources.GearMetro;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Padding = new System.Windows.Forms.Padding(8, 8, 4, 0);
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(32, 28);
            // 
            // historyToolStripMenuItem
            // 
            this.historyToolStripMenuItem.Image = global::DB_Architect.Properties.Resources.History_wider;
            this.historyToolStripMenuItem.Name = "historyToolStripMenuItem";
            this.historyToolStripMenuItem.Padding = new System.Windows.Forms.Padding(8, 8, 4, 0);
            this.historyToolStripMenuItem.Size = new System.Drawing.Size(32, 28);
            // 
            // execToolStripMenuItem
            // 
            this.execToolStripMenuItem.Image = global::DB_Architect.Properties.Resources.Execute1;
            this.execToolStripMenuItem.Name = "execToolStripMenuItem";
            this.execToolStripMenuItem.Padding = new System.Windows.Forms.Padding(8, 8, 4, 0);
            this.execToolStripMenuItem.Size = new System.Drawing.Size(32, 28);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Image = global::DB_Architect.Properties.Resources.QMark;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Padding = new System.Windows.Forms.Padding(8, 8, 4, 0);
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(32, 28);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Image = global::DB_Architect.Properties.Resources.DC;
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Padding = new System.Windows.Forms.Padding(8, 8, 4, 0);
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(32, 28);
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // Captionbox
            // 
            this.Captionbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Captionbox.BackColor = System.Drawing.Color.Transparent;
            this.Captionbox.Dock = System.Windows.Forms.DockStyle.None;
            this.Captionbox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minimizeToolStripMenuItem,
            this.maximizeToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.Captionbox.Location = new System.Drawing.Point(1258, 0);
            this.Captionbox.Name = "Captionbox";
            this.Captionbox.Size = new System.Drawing.Size(92, 24);
            this.Captionbox.TabIndex = 15;
            this.Captionbox.Text = "menuStrip2";
            // 
            // minimizeToolStripMenuItem
            // 
            this.minimizeToolStripMenuItem.Image = global::DB_Architect.Properties.Resources.Minimiz;
            this.minimizeToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.minimizeToolStripMenuItem.Name = "minimizeToolStripMenuItem";
            this.minimizeToolStripMenuItem.Size = new System.Drawing.Size(28, 20);
            this.minimizeToolStripMenuItem.Click += new System.EventHandler(this.minimizeToolStripMenuItem_Click);
            // 
            // maximizeToolStripMenuItem
            // 
            this.maximizeToolStripMenuItem.Image = global::DB_Architect.Properties.Resources.Maximize;
            this.maximizeToolStripMenuItem.Name = "maximizeToolStripMenuItem";
            this.maximizeToolStripMenuItem.Size = new System.Drawing.Size(28, 20);
            this.maximizeToolStripMenuItem.Click += new System.EventHandler(this.maximizeToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Image = global::DB_Architect.Properties.Resources.Close;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(28, 20);
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // StatusPic
            // 
            this.StatusPic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StatusPic.BackColor = System.Drawing.Color.Transparent;
            this.StatusPic.Location = new System.Drawing.Point(11, 705);
            this.StatusPic.Name = "StatusPic";
            this.StatusPic.Size = new System.Drawing.Size(15, 15);
            this.StatusPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.StatusPic.TabIndex = 12;
            this.StatusPic.TabStop = false;
            // 
            // ArchitectLogo
            // 
            this.ArchitectLogo.Image = ((System.Drawing.Image)(resources.GetObject("ArchitectLogo.Image")));
            this.ArchitectLogo.Location = new System.Drawing.Point(13, 11);
            this.ArchitectLogo.Name = "ArchitectLogo";
            this.ArchitectLogo.Size = new System.Drawing.Size(40, 40);
            this.ArchitectLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ArchitectLogo.TabIndex = 0;
            this.ArchitectLogo.TabStop = false;
            // 
            // ActivePanel
            // 
            this.ActivePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ActivePanel.BackColor = System.Drawing.Color.Transparent;
            this.ActivePanel.Controls.Add(this.RightLowerPanel);
            this.ActivePanel.Controls.Add(this.RightUpperPanel);
            this.ActivePanel.Controls.Add(this.LeftFormPanel);
            this.ActivePanel.Location = new System.Drawing.Point(10, 86);
            this.ActivePanel.Name = "ActivePanel";
            this.ActivePanel.Size = new System.Drawing.Size(1328, 611);
            this.ActivePanel.TabIndex = 16;
            // 
            // RightLowerPanel
            // 
            this.RightLowerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RightLowerPanel.Location = new System.Drawing.Point(312, 418);
            this.RightLowerPanel.Name = "RightLowerPanel";
            this.RightLowerPanel.Size = new System.Drawing.Size(1015, 190);
            this.RightLowerPanel.TabIndex = 2;
            // 
            // RightUpperPanel
            // 
            this.RightUpperPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RightUpperPanel.Location = new System.Drawing.Point(312, 0);
            this.RightUpperPanel.Name = "RightUpperPanel";
            this.RightUpperPanel.Size = new System.Drawing.Size(1015, 415);
            this.RightUpperPanel.TabIndex = 1;
            // 
            // LeftFormPanel
            // 
            this.LeftFormPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LeftFormPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftFormPanel.Name = "LeftFormPanel";
            this.LeftFormPanel.Size = new System.Drawing.Size(310, 611);
            this.LeftFormPanel.TabIndex = 0;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.ActivePanel);
            this.Controls.Add(this.StatusPic);
            this.Controls.Add(this.ArchitectLogo);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.Toolbox);
            this.Controls.Add(this.Captionbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.Toolbox;
            this.MaximizeBox = false;
            this.Name = "Home";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database Architect";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Home_FormClosing);
            this.Load += new System.EventHandler(this.Home_Load);
            this.Toolbox.ResumeLayout(false);
            this.Toolbox.PerformLayout();
            this.Captionbox.ResumeLayout(false);
            this.Captionbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StatusPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArchitectLogo)).EndInit();
            this.ActivePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ArchitectLogo;
        public System.Windows.Forms.Label Status;
        private System.Windows.Forms.PictureBox StatusPic;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.MenuStrip Toolbox;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem queryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relationshipToolStripMenuItem;
        private System.Windows.Forms.MenuStrip Captionbox;
        private System.Windows.Forms.ToolStripMenuItem minimizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maximizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem execToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem;
        private System.Windows.Forms.Panel ActivePanel;
        private System.Windows.Forms.Panel LeftFormPanel;
        private System.Windows.Forms.Panel RightUpperPanel;
        private System.Windows.Forms.Panel RightLowerPanel;
    }
}