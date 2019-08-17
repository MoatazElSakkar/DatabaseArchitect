namespace DB_Architect
{
    partial class WelcomeScreen
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
            this.button1 = new System.Windows.Forms.Button();
            this.Credentials = new System.Windows.Forms.Panel();
            this.info1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.TextBox();
            this.ServerName = new System.Windows.Forms.TextBox();
            this.Error = new System.Windows.Forms.Panel();
            this.statusImage = new System.Windows.Forms.PictureBox();
            this.stats_lbl = new System.Windows.Forms.Label();
            this.Credentials.SuspendLayout();
            this.Error.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusImage)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(275, 113);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Connect_Click);
            // 
            // Credentials
            // 
            this.Credentials.BackColor = System.Drawing.Color.Transparent;
            this.Credentials.Controls.Add(this.info1);
            this.Credentials.Controls.Add(this.lbl2);
            this.Credentials.Controls.Add(this.lbl1);
            this.Credentials.Controls.Add(this.Password);
            this.Credentials.Controls.Add(this.ServerName);
            this.Credentials.Controls.Add(this.button1);
            this.Credentials.Location = new System.Drawing.Point(12, 145);
            this.Credentials.Name = "Credentials";
            this.Credentials.Size = new System.Drawing.Size(362, 150);
            this.Credentials.TabIndex = 1;
            // 
            // info1
            // 
            this.info1.AutoSize = true;
            this.info1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.info1.Location = new System.Drawing.Point(32, 14);
            this.info1.Name = "info1";
            this.info1.Size = new System.Drawing.Size(255, 13);
            this.info1.TabIndex = 5;
            this.info1.Text = "Please enter server credentials below to proceed";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.Location = new System.Drawing.Point(30, 76);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(56, 13);
            this.lbl2.TabIndex = 4;
            this.lbl2.Text = "Password";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(30, 47);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(70, 13);
            this.lbl1.TabIndex = 3;
            this.lbl1.Text = "Server Name";
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(105, 73);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(177, 20);
            this.Password.TabIndex = 2;
            this.Password.UseSystemPasswordChar = true;
            // 
            // ServerName
            // 
            this.ServerName.Location = new System.Drawing.Point(105, 45);
            this.ServerName.Name = "ServerName";
            this.ServerName.Size = new System.Drawing.Size(177, 20);
            this.ServerName.TabIndex = 1;
            // 
            // Error
            // 
            this.Error.BackColor = System.Drawing.Color.LightYellow;
            this.Error.Controls.Add(this.statusImage);
            this.Error.Controls.Add(this.stats_lbl);
            this.Error.Location = new System.Drawing.Point(-1, 305);
            this.Error.Name = "Error";
            this.Error.Size = new System.Drawing.Size(675, 25);
            this.Error.TabIndex = 2;
            this.Error.Visible = false;
            // 
            // statusImage
            // 
            this.statusImage.Image = global::DB_Architect.Properties.Resources.Exclaim;
            this.statusImage.Location = new System.Drawing.Point(3, 0);
            this.statusImage.Name = "statusImage";
            this.statusImage.Size = new System.Drawing.Size(22, 22);
            this.statusImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.statusImage.TabIndex = 1;
            this.statusImage.TabStop = false;
            // 
            // stats_lbl
            // 
            this.stats_lbl.AutoSize = true;
            this.stats_lbl.BackColor = System.Drawing.Color.Transparent;
            this.stats_lbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stats_lbl.Location = new System.Drawing.Point(27, 5);
            this.stats_lbl.Name = "stats_lbl";
            this.stats_lbl.Size = new System.Drawing.Size(235, 13);
            this.stats_lbl.TabIndex = 0;
            this.stats_lbl.Text = "Unable to establish connection to the server";
            // 
            // WelcomeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::DB_Architect.Properties.Resources.WelcomeScreen;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(674, 326);
            this.ControlBox = false;
            this.Controls.Add(this.Error);
            this.Controls.Add(this.Credentials);
            this.DoubleBuffered = true;
            this.Location = new System.Drawing.Point(300, 120);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(674, 326);
            this.MinimizeBox = false;
            this.Name = "WelcomeScreen";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Welcome Screen";
            this.Credentials.ResumeLayout(false);
            this.Credentials.PerformLayout();
            this.Error.ResumeLayout(false);
            this.Error.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel Credentials;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.TextBox ServerName;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Panel Error;
        private System.Windows.Forms.Label stats_lbl;
        private System.Windows.Forms.PictureBox statusImage;
        private System.Windows.Forms.Label info1;
    }
}