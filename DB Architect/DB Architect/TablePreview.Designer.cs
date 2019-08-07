namespace DB_Architect
{
    partial class TablePreview
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
            this.TablePreviewGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.TablePreviewGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // TablePreviewGrid
            // 
            this.TablePreviewGrid.AllowUserToResizeRows = false;
            this.TablePreviewGrid.BackgroundColor = System.Drawing.Color.White;
            this.TablePreviewGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TablePreviewGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.TablePreviewGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablePreviewGrid.GridColor = System.Drawing.Color.White;
            this.TablePreviewGrid.Location = new System.Drawing.Point(12, 12);
            this.TablePreviewGrid.MultiSelect = false;
            this.TablePreviewGrid.Name = "TablePreviewGrid";
            this.TablePreviewGrid.ReadOnly = true;
            this.TablePreviewGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.TablePreviewGrid.RowHeadersWidth = 24;
            this.TablePreviewGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.TablePreviewGrid.Size = new System.Drawing.Size(690, 452);
            this.TablePreviewGrid.TabIndex = 0;
            // 
            // TablePreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(714, 476);
            this.Controls.Add(this.TablePreviewGrid);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TablePreview";
            this.ShowInTaskbar = false;
            this.Text = "Table Preview";
            this.Load += new System.EventHandler(this.TablePreview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TablePreviewGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView TablePreviewGrid;
    }
}