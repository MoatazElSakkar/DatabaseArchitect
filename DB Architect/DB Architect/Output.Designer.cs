﻿namespace DB_Architect
{
    partial class Output
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
            this.OutputBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // OutputBox
            // 
            this.OutputBox.BackColor = System.Drawing.SystemColors.Control;
            this.OutputBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OutputBox.DetectUrls = false;
            this.OutputBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutputBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputBox.ForeColor = System.Drawing.Color.Black;
            this.OutputBox.Location = new System.Drawing.Point(0, 0);
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.ReadOnly = true;
            this.OutputBox.Size = new System.Drawing.Size(694, 261);
            this.OutputBox.TabIndex = 0;
            this.OutputBox.Text = "";
            // 
            // Output
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 261);
            this.Controls.Add(this.OutputBox);
            this.Name = "Output";
            this.Text = "Output";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox OutputBox;
    }
}