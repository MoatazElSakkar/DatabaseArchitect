namespace DB_Architect
{
    partial class DesignView
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
            this.Error = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Stats = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.TableGrid = new System.Windows.Forms.DataGridView();
            this.DesignTabs = new System.Windows.Forms.TabControl();
            this.Toolbar = new System.Windows.Forms.MenuStrip();
            this.Apply = new System.Windows.Forms.ToolStripMenuItem();
            this.Key_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Key_DataType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Error.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TableGrid)).BeginInit();
            this.DesignTabs.SuspendLayout();
            this.Toolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // Error
            // 
            this.Error.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Error.BackColor = System.Drawing.Color.LightYellow;
            this.Error.Controls.Add(this.pictureBox1);
            this.Error.Controls.Add(this.Stats);
            this.Error.Location = new System.Drawing.Point(-2, 457);
            this.Error.Name = "Error";
            this.Error.Size = new System.Drawing.Size(718, 22);
            this.Error.TabIndex = 6;
            this.Error.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DB_Architect.Properties.Resources.ErrorIcon;
            this.pictureBox1.Location = new System.Drawing.Point(2, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(22, 22);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Stats
            // 
            this.Stats.AutoSize = true;
            this.Stats.BackColor = System.Drawing.Color.Transparent;
            this.Stats.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Stats.Location = new System.Drawing.Point(26, 2);
            this.Stats.Name = "Stats";
            this.Stats.Size = new System.Drawing.Size(36, 16);
            this.Stats.TabIndex = 0;
            this.Stats.Text = "label4";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.comboBox1);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(682, 400);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Restrictions";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(109, 42);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(223, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Primary Key";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.TableGrid);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(682, 400);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Design view";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // TableGrid
            // 
            this.TableGrid.AllowUserToResizeColumns = false;
            this.TableGrid.AllowUserToResizeRows = false;
            this.TableGrid.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.TableGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TableGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.TableGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.TableGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TableGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Key_Name,
            this.Key_DataType});
            this.TableGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.TableGrid.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.TableGrid.Location = new System.Drawing.Point(3, 3);
            this.TableGrid.Name = "TableGrid";
            this.TableGrid.RowHeadersWidth = 28;
            this.TableGrid.Size = new System.Drawing.Size(676, 394);
            this.TableGrid.TabIndex = 3;
            // 
            // DesignTabs
            // 
            this.DesignTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DesignTabs.Controls.Add(this.tabPage1);
            this.DesignTabs.Controls.Add(this.tabPage2);
            this.DesignTabs.Location = new System.Drawing.Point(12, 25);
            this.DesignTabs.Name = "DesignTabs";
            this.DesignTabs.SelectedIndex = 0;
            this.DesignTabs.Size = new System.Drawing.Size(690, 426);
            this.DesignTabs.TabIndex = 7;
            // 
            // Toolbar
            // 
            this.Toolbar.BackColor = System.Drawing.Color.White;
            this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Apply});
            this.Toolbar.Location = new System.Drawing.Point(0, 0);
            this.Toolbar.Name = "Toolbar";
            this.Toolbar.Size = new System.Drawing.Size(714, 24);
            this.Toolbar.TabIndex = 8;
            this.Toolbar.Text = "menuStrip1";
            // 
            // Apply
            // 
            this.Apply.Image = global::DB_Architect.Properties.Resources.Execute1;
            this.Apply.Name = "Apply";
            this.Apply.Size = new System.Drawing.Size(28, 20);
            // 
            // Key_Name
            // 
            this.Key_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Key_Name.FillWeight = 135.4965F;
            this.Key_Name.HeaderText = "Name";
            this.Key_Name.Name = "Key_Name";
            this.Key_Name.Width = 200;
            // 
            // Key_DataType
            // 
            this.Key_DataType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Key_DataType.FillWeight = 92.64719F;
            this.Key_DataType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Key_DataType.HeaderText = "Data type";
            this.Key_DataType.Name = "Key_DataType";
            this.Key_DataType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Key_DataType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Key_DataType.Width = 130;
            // 
            // DesignView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(714, 476);
            this.Controls.Add(this.Toolbar);
            this.Controls.Add(this.DesignTabs);
            this.Controls.Add(this.Error);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(250, 80);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DesignView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Design View";
            this.Load += new System.EventHandler(this.TableView_Load);
            this.Error.ResumeLayout(false);
            this.Error.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TableGrid)).EndInit();
            this.DesignTabs.ResumeLayout(false);
            this.Toolbar.ResumeLayout(false);
            this.Toolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel Error;
        private System.Windows.Forms.Label Stats;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView TableGrid;
        private System.Windows.Forms.TabControl DesignTabs;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip Toolbar;
        private System.Windows.Forms.ToolStripMenuItem Apply;
        private System.Windows.Forms.DataGridViewTextBoxColumn Key_Name;
        private System.Windows.Forms.DataGridViewComboBoxColumn Key_DataType;
    }
}