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
            this.Execute_btn = new System.Windows.Forms.PictureBox();
            this.QueryFile_Btn = new System.Windows.Forms.PictureBox();
            this.ErrorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorSign)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Execute_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QueryFile_Btn)).BeginInit();
            this.SuspendLayout();
            // 
            // ArchiScript
            // 
            this.ArchiScript.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ArchiScript.Location = new System.Drawing.Point(14, 55);
            this.ArchiScript.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ArchiScript.Name = "ArchiScript";
            this.ArchiScript.Size = new System.Drawing.Size(456, 336);
            this.ArchiScript.TabIndex = 0;
            this.ArchiScript.Text = "";
            this.ArchiScript.TextChanged += new System.EventHandler(this.ArchiScript_TextChanged);
            // 
            // ErrorPanel
            // 
            this.ErrorPanel.BackColor = System.Drawing.Color.LightYellow;
            this.ErrorPanel.Controls.Add(this.ErrorSign);
            this.ErrorPanel.Controls.Add(this.stats_lbl);
            this.ErrorPanel.Location = new System.Drawing.Point(-1, 398);
            this.ErrorPanel.Name = "ErrorPanel";
            this.ErrorPanel.Size = new System.Drawing.Size(485, 19);
            this.ErrorPanel.TabIndex = 3;
            this.ErrorPanel.Visible = false;
            // 
            // ErrorSign
            // 
            this.ErrorSign.Image = global::DB_Architect.Properties.Resources.ErrorIcon;
            this.ErrorSign.Location = new System.Drawing.Point(5, -2);
            this.ErrorSign.Name = "ErrorSign";
            this.ErrorSign.Size = new System.Drawing.Size(22, 22);
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
            // Execute_btn
            // 
            this.Execute_btn.BackColor = System.Drawing.Color.Black;
            this.Execute_btn.Image = global::DB_Architect.Properties.Resources.Execute;
            this.Execute_btn.Location = new System.Drawing.Point(447, 1);
            this.Execute_btn.Name = "Execute_btn";
            this.Execute_btn.Size = new System.Drawing.Size(25, 25);
            this.Execute_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Execute_btn.TabIndex = 6;
            this.Execute_btn.TabStop = false;
            this.Execute_btn.MouseLeave += new System.EventHandler(this.Execute_btn_MouseLeave);
            this.Execute_btn.Click += new System.EventHandler(this.Execute_btn_Click);
            this.Execute_btn.MouseEnter += new System.EventHandler(this.Execute_btn_MouseEnter);
            // 
            // QueryFile_Btn
            // 
            this.QueryFile_Btn.BackColor = System.Drawing.Color.Black;
            this.QueryFile_Btn.Image = global::DB_Architect.Properties.Resources.QueryFile;
            this.QueryFile_Btn.Location = new System.Drawing.Point(415, 1);
            this.QueryFile_Btn.Name = "QueryFile_Btn";
            this.QueryFile_Btn.Size = new System.Drawing.Size(25, 25);
            this.QueryFile_Btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.QueryFile_Btn.TabIndex = 7;
            this.QueryFile_Btn.TabStop = false;
            this.QueryFile_Btn.MouseLeave += new System.EventHandler(this.QueryFile_Btn_MouseLeave);
            this.QueryFile_Btn.MouseEnter += new System.EventHandler(this.QueryFile_Btn_MouseEnter);
            // 
            // NewQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 415);
            this.Controls.Add(this.QueryFile_Btn);
            this.Controls.Add(this.Execute_btn);
            this.Controls.Add(this.ErrorPanel);
            this.Controls.Add(this.ArchiScript);
            this.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
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
            ((System.ComponentModel.ISupportInitialize)(this.Execute_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QueryFile_Btn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox ArchiScript;
        private System.Windows.Forms.Panel ErrorPanel;
        private System.Windows.Forms.PictureBox ErrorSign;
        private System.Windows.Forms.Label stats_lbl;
        private System.Windows.Forms.PictureBox Execute_btn;
        private System.Windows.Forms.PictureBox QueryFile_Btn;
    }
}