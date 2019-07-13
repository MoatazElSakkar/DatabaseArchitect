namespace DB_Architect
{
    partial class Dialog
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
            this.Question = new System.Windows.Forms.Label();
            this.Canc = new System.Windows.Forms.Button();
            this.Conf = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::DB_Architect.Properties.Resources.MenuBG;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.Lbl1);
            this.panel1.Location = new System.Drawing.Point(-23, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(485, 86);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = global::DB_Architect.Properties.Resources.Question;
            this.pictureBox1.Location = new System.Drawing.Point(30, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Lbl1
            // 
            this.Lbl1.AutoSize = true;
            this.Lbl1.BackColor = System.Drawing.Color.Transparent;
            this.Lbl1.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl1.ForeColor = System.Drawing.Color.White;
            this.Lbl1.Location = new System.Drawing.Point(99, 29);
            this.Lbl1.Name = "Lbl1";
            this.Lbl1.Size = new System.Drawing.Size(195, 27);
            this.Lbl1.TabIndex = 0;
            this.Lbl1.Text = "Comform Operation";
            // 
            // Question
            // 
            this.Question.AutoSize = true;
            this.Question.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Question.Location = new System.Drawing.Point(13, 119);
            this.Question.Name = "Question";
            this.Question.Size = new System.Drawing.Size(357, 20);
            this.Question.TabIndex = 2;
            this.Question.Text = "Are you sure you want to delete the selected item ?";
            // 
            // Canc
            // 
            this.Canc.Location = new System.Drawing.Point(242, 166);
            this.Canc.Name = "Canc";
            this.Canc.Size = new System.Drawing.Size(75, 23);
            this.Canc.TabIndex = 3;
            this.Canc.Text = "Cancel";
            this.Canc.UseVisualStyleBackColor = true;
            this.Canc.Click += new System.EventHandler(this.Canc_Click);
            // 
            // Conf
            // 
            this.Conf.Location = new System.Drawing.Point(333, 166);
            this.Conf.Name = "Conf";
            this.Conf.Size = new System.Drawing.Size(75, 23);
            this.Conf.TabIndex = 4;
            this.Conf.Text = "Confirm";
            this.Conf.UseVisualStyleBackColor = true;
            this.Conf.Click += new System.EventHandler(this.Conf_Click);
            // 
            // Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(414, 195);
            this.ControlBox = false;
            this.Controls.Add(this.Conf);
            this.Controls.Add(this.Canc);
            this.Controls.Add(this.Question);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Confirm Operation";
            this.Load += new System.EventHandler(this.Dialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Lbl1;
        private System.Windows.Forms.Label Question;
        private System.Windows.Forms.Button Canc;
        private System.Windows.Forms.Button Conf;
    }
}