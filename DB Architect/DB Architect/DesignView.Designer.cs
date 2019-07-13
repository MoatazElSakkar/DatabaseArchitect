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
            this.TablePanel = new System.Windows.Forms.Panel();
            this.TableGrid = new System.Windows.Forms.DataGridView();
            this.Key_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Key_DataType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Restrictions = new System.Windows.Forms.Panel();
            this.PropertiesSet = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.PKBox = new System.Windows.Forms.CheckBox();
            this.KeyName = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.AllowedChars = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.UKBox = new System.Windows.Forms.CheckBox();
            this.MaxBox = new System.Windows.Forms.TextBox();
            this.MinBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SaveBtn = new System.Windows.Forms.PictureBox();
            this.Error = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Stats = new System.Windows.Forms.Label();
            this.TablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TableGrid)).BeginInit();
            this.Restrictions.SuspendLayout();
            this.PropertiesSet.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SaveBtn)).BeginInit();
            this.Error.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TablePanel
            // 
            this.TablePanel.AutoScroll = true;
            this.TablePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TablePanel.Controls.Add(this.TableGrid);
            this.TablePanel.Location = new System.Drawing.Point(12, 40);
            this.TablePanel.Name = "TablePanel";
            this.TablePanel.Size = new System.Drawing.Size(690, 330);
            this.TablePanel.TabIndex = 1;
            // 
            // TableGrid
            // 
            this.TableGrid.AllowUserToResizeColumns = false;
            this.TableGrid.AllowUserToResizeRows = false;
            this.TableGrid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TableGrid.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.TableGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TableGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Key_Name,
            this.Key_DataType});
            this.TableGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.TableGrid.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.TableGrid.Location = new System.Drawing.Point(7, 7);
            this.TableGrid.Name = "TableGrid";
            this.TableGrid.Size = new System.Drawing.Size(676, 312);
            this.TableGrid.TabIndex = 2;
            this.TableGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.TableGrid_CellValueChanged);
            this.TableGrid.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.TableGrid_UserAddedRow);
            this.TableGrid.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.TableGrid_UserDeletedRow);
            this.TableGrid.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.TableGrid_CellEnter);
            this.TableGrid.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.TableGrid_RowsRemoved);
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
            this.Key_DataType.HeaderText = "Data Type";
            this.Key_DataType.Items.AddRange(new object[] {
            "Int",
            "String",
            "Boolean",
            "Float"});
            this.Key_DataType.Name = "Key_DataType";
            this.Key_DataType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Key_DataType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Key_DataType.Width = 130;
            // 
            // Restrictions
            // 
            this.Restrictions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Restrictions.Controls.Add(this.PropertiesSet);
            this.Restrictions.Location = new System.Drawing.Point(12, 372);
            this.Restrictions.Name = "Restrictions";
            this.Restrictions.Size = new System.Drawing.Size(690, 83);
            this.Restrictions.TabIndex = 3;
            // 
            // PropertiesSet
            // 
            this.PropertiesSet.Controls.Add(this.tabPage1);
            this.PropertiesSet.Controls.Add(this.tabPage2);
            this.PropertiesSet.Location = new System.Drawing.Point(3, 2);
            this.PropertiesSet.Name = "PropertiesSet";
            this.PropertiesSet.SelectedIndex = 0;
            this.PropertiesSet.Size = new System.Drawing.Size(680, 78);
            this.PropertiesSet.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.PKBox);
            this.tabPage1.Controls.Add(this.KeyName);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(672, 52);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Properties";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // PKBox
            // 
            this.PKBox.AutoSize = true;
            this.PKBox.Location = new System.Drawing.Point(49, 27);
            this.PKBox.Name = "PKBox";
            this.PKBox.Size = new System.Drawing.Size(81, 17);
            this.PKBox.TabIndex = 3;
            this.PKBox.Text = "Primary Key";
            this.PKBox.UseVisualStyleBackColor = true;
            // 
            // KeyName
            // 
            this.KeyName.AutoSize = true;
            this.KeyName.Location = new System.Drawing.Point(48, 11);
            this.KeyName.Name = "KeyName";
            this.KeyName.Size = new System.Drawing.Size(53, 13);
            this.KeyName.TabIndex = 2;
            this.KeyName.Text = "KeyName";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.AllowedChars);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.UKBox);
            this.tabPage2.Controls.Add(this.MaxBox);
            this.tabPage2.Controls.Add(this.MinBox);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(672, 52);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Restrictions";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // AllowedChars
            // 
            this.AllowedChars.Location = new System.Drawing.Point(123, 16);
            this.AllowedChars.Name = "AllowedChars";
            this.AllowedChars.Size = new System.Drawing.Size(345, 20);
            this.AllowedChars.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Allowed charectar Set";
            // 
            // UKBox
            // 
            this.UKBox.AutoSize = true;
            this.UKBox.Location = new System.Drawing.Point(474, 19);
            this.UKBox.Name = "UKBox";
            this.UKBox.Size = new System.Drawing.Size(60, 17);
            this.UKBox.TabIndex = 4;
            this.UKBox.Text = "Unique";
            this.UKBox.UseVisualStyleBackColor = true;
            // 
            // MaxBox
            // 
            this.MaxBox.Location = new System.Drawing.Point(589, 29);
            this.MaxBox.Name = "MaxBox";
            this.MaxBox.Size = new System.Drawing.Size(49, 20);
            this.MaxBox.TabIndex = 3;
            // 
            // MinBox
            // 
            this.MinBox.Location = new System.Drawing.Point(589, 4);
            this.MinBox.Name = "MinBox";
            this.MinBox.Size = new System.Drawing.Size(49, 20);
            this.MinBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(559, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Max";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(560, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Min";
            // 
            // SaveBtn
            // 
            this.SaveBtn.BackColor = System.Drawing.Color.Black;
            this.SaveBtn.Image = global::DB_Architect.Properties.Resources.Save;
            this.SaveBtn.Location = new System.Drawing.Point(686, 3);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(25, 25);
            this.SaveBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SaveBtn.TabIndex = 5;
            this.SaveBtn.TabStop = false;
            this.SaveBtn.MouseLeave += new System.EventHandler(this.SaveBtn_MouseLeave);
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            this.SaveBtn.MouseEnter += new System.EventHandler(this.SaveBtn_MouseEnter);
            // 
            // Error
            // 
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
            this.pictureBox1.Image = global::DB_Architect.Properties.Resources.Error_Icon;
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
            // DesignView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(714, 476);
            this.Controls.Add(this.Error);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.Restrictions);
            this.Controls.Add(this.TablePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(250, 80);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DesignView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Design View";
            this.Load += new System.EventHandler(this.TableView_Load);
            this.TablePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TableGrid)).EndInit();
            this.Restrictions.ResumeLayout(false);
            this.PropertiesSet.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SaveBtn)).EndInit();
            this.Error.ResumeLayout(false);
            this.Error.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TablePanel;
        private System.Windows.Forms.Panel Restrictions;
        private System.Windows.Forms.TabControl PropertiesSet;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox PKBox;
        private System.Windows.Forms.Label KeyName;
        private System.Windows.Forms.TextBox MaxBox;
        private System.Windows.Forms.TextBox MinBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox UKBox;
        private System.Windows.Forms.TextBox AllowedChars;
        private System.Windows.Forms.DataGridView TableGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Key_Name;
        private System.Windows.Forms.DataGridViewComboBoxColumn Key_DataType;
        private System.Windows.Forms.PictureBox SaveBtn;
        private System.Windows.Forms.Panel Error;
        private System.Windows.Forms.Label Stats;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}