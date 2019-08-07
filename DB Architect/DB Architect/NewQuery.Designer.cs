namespace DB_Architect
{
    partial class NewQuery
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
            this.ArchiScript = new System.Windows.Forms.RichTextBox();
            this.ErrorPanel = new System.Windows.Forms.Panel();
            this.ErrorSign = new System.Windows.Forms.PictureBox();
            this.stats_lbl = new System.Windows.Forms.Label();
            this.Toolbar = new System.Windows.Forms.MenuStrip();
            this.RunQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.NumberLine = new System.Windows.Forms.RichTextBox();
            this.ErrorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorSign)).BeginInit();
            this.Toolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // ArchiScript
            // 
            this.ArchiScript.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ArchiScript.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ArchiScript.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArchiScript.Location = new System.Drawing.Point(32, 24);
            this.ArchiScript.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ArchiScript.Name = "ArchiScript";
            this.ArchiScript.Size = new System.Drawing.Size(715, 444);
            this.ArchiScript.TabIndex = 0;
            this.ArchiScript.Text = "";
            this.ArchiScript.TextChanged += new System.EventHandler(this.ArchiScript_TextChanged);
            // 
            // ErrorPanel
            // 
            this.ErrorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ErrorPanel.BackColor = System.Drawing.Color.LightYellow;
            this.ErrorPanel.Controls.Add(this.ErrorSign);
            this.ErrorPanel.Controls.Add(this.stats_lbl);
            this.ErrorPanel.Location = new System.Drawing.Point(-4, 446);
            this.ErrorPanel.Name = "ErrorPanel";
            this.ErrorPanel.Size = new System.Drawing.Size(754, 21);
            this.ErrorPanel.TabIndex = 3;
            this.ErrorPanel.Visible = false;
            // 
            // ErrorSign
            // 
            this.ErrorSign.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ErrorSign.Image = global::DB_Architect.Properties.Resources.Exclaim;
            this.ErrorSign.Location = new System.Drawing.Point(5, -1);
            this.ErrorSign.Name = "ErrorSign";
            this.ErrorSign.Size = new System.Drawing.Size(22, 21);
            this.ErrorSign.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ErrorSign.TabIndex = 3;
            this.ErrorSign.TabStop = false;
            // 
            // stats_lbl
            // 
            this.stats_lbl.AutoSize = true;
            this.stats_lbl.BackColor = System.Drawing.Color.Transparent;
            this.stats_lbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stats_lbl.Location = new System.Drawing.Point(29, 3);
            this.stats_lbl.Name = "stats_lbl";
            this.stats_lbl.Size = new System.Drawing.Size(235, 13);
            this.stats_lbl.TabIndex = 2;
            this.stats_lbl.Text = "Unable to establish connection to the server";
            // 
            // Toolbar
            // 
            this.Toolbar.BackColor = System.Drawing.Color.White;
            this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RunQuery});
            this.Toolbar.Location = new System.Drawing.Point(0, 0);
            this.Toolbar.Name = "Toolbar";
            this.Toolbar.Size = new System.Drawing.Size(746, 24);
            this.Toolbar.TabIndex = 4;
            this.Toolbar.Text = "menuStrip1";
            // 
            // RunQuery
            // 
            this.RunQuery.Image = global::DB_Architect.Properties.Resources.Execute1;
            this.RunQuery.Name = "RunQuery";
            this.RunQuery.Size = new System.Drawing.Size(28, 20);
            this.RunQuery.Click += new System.EventHandler(this.RunQuery_Click);
            // 
            // NumberLine
            // 
            this.NumberLine.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NumberLine.Location = new System.Drawing.Point(0, 24);
            this.NumberLine.Name = "NumberLine";
            this.NumberLine.Size = new System.Drawing.Size(27, 422);
            this.NumberLine.TabIndex = 5;
            this.NumberLine.Text = "";
            // 
            // NewQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(746, 467);
            this.Controls.Add(this.ErrorPanel);
            this.Controls.Add(this.NumberLine);
            this.Controls.Add(this.Toolbar);
            this.Controls.Add(this.ArchiScript);
            this.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewQuery";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "New Query";
            this.Load += new System.EventHandler(this.NewQuery_Load);
            this.Move += new System.EventHandler(this.NewQuery_Move);
            this.ErrorPanel.ResumeLayout(false);
            this.ErrorPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorSign)).EndInit();
            this.Toolbar.ResumeLayout(false);
            this.Toolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox ArchiScript;
        private System.Windows.Forms.Panel ErrorPanel;
        private System.Windows.Forms.PictureBox ErrorSign;
        private System.Windows.Forms.Label stats_lbl;
        private System.Windows.Forms.MenuStrip Toolbar;
        private System.Windows.Forms.ToolStripMenuItem RunQuery;
        private System.Windows.Forms.RichTextBox NumberLine;
    }
}