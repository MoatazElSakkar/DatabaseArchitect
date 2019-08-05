namespace DB_Architect
{
    partial class AboutArchitect
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Lbl1 = new System.Windows.Forms.Label();
            this.Version = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Link = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Build = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::DB_Architect.Properties.Resources.MenuBG;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.Lbl1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(485, 86);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = global::DB_Architect.Properties.Resources.AboutIco;
            this.pictureBox1.Location = new System.Drawing.Point(24, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 70);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Lbl1
            // 
            this.Lbl1.AutoSize = true;
            this.Lbl1.BackColor = System.Drawing.Color.Transparent;
            this.Lbl1.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl1.ForeColor = System.Drawing.Color.White;
            this.Lbl1.Location = new System.Drawing.Point(110, 28);
            this.Lbl1.Name = "Lbl1";
            this.Lbl1.Size = new System.Drawing.Size(249, 27);
            this.Lbl1.TabIndex = 0;
            this.Lbl1.Text = "About Database Architect";
            // 
            // Version
            // 
            this.Version.AutoSize = true;
            this.Version.Location = new System.Drawing.Point(86, 158);
            this.Version.Name = "Version";
            this.Version.Size = new System.Drawing.Size(48, 13);
            this.Version.TabIndex = 2;
            this.Version.Text = "Version: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(252, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Moataz M. El Sakkar - moataz_elsakkar@aol.com - ";
            // 
            // Link
            // 
            this.Link.AutoSize = true;
            this.Link.ForeColor = System.Drawing.Color.SteelBlue;
            this.Link.Location = new System.Drawing.Point(291, 244);
            this.Link.Name = "Link";
            this.Link.Size = new System.Drawing.Size(122, 13);
            this.Link.TabIndex = 4;
            this.Link.Text = "www.auroradesign.co.nr";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(26, 129);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(54, 54);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(83, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 27);
            this.label3.TabIndex = 2;
            this.label3.Text = "Database Architect";
            // 
            // Build
            // 
            this.Build.AutoSize = true;
            this.Build.Location = new System.Drawing.Point(86, 172);
            this.Build.Name = "Build";
            this.Build.Size = new System.Drawing.Size(33, 13);
            this.Build.TabIndex = 5;
            this.Build.Text = "Build:";
            // 
            // AboutArchitect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 266);
            this.Controls.Add(this.Build);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.Link);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Version);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutArchitect";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About Database Architect";
            this.Load += new System.EventHandler(this.AboutArchitect_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Lbl1;
        private System.Windows.Forms.Label Version;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Link;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Build;



    }
}