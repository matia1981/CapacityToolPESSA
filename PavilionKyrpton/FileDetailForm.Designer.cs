
namespace PavilionKyrpton
{
    partial class FileDetailForm
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
            this.FileDetailGrid = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.FileDetailGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // FileDetailGrid
            // 
            this.FileDetailGrid.AllowUserToOrderColumns = true;
            this.FileDetailGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FileDetailGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileDetailGrid.Location = new System.Drawing.Point(0, 0);
            this.FileDetailGrid.Name = "FileDetailGrid";
            this.FileDetailGrid.RowTemplate.Height = 25;
            this.FileDetailGrid.Size = new System.Drawing.Size(1344, 597);
            this.FileDetailGrid.TabIndex = 0;
            // 
            // FileDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 597);
            this.Controls.Add(this.FileDetailGrid);
            this.Name = "FileDetailForm";
            this.Text = "FileDetailForm";
            ((System.ComponentModel.ISupportInitialize)(this.FileDetailGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public ComponentFactory.Krypton.Toolkit.KryptonDataGridView FileDetailGrid;
    }
}