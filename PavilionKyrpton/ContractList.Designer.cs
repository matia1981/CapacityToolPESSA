
namespace PavilionKyrpton
{
    partial class ContractList
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
            this.components = new System.ComponentModel.Container();
            this.kryptonDataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RetrieveDataMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportToExcelItemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.locationsDropDown = new System.Windows.Forms.ToolStripComboBox();
            this.HubDropDown = new System.Windows.Forms.ToolStripComboBox();
            this.ServiceTypeDropDown = new System.Windows.Forms.ToolStripComboBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonDataGridView1
            // 
            this.kryptonDataGridView1.AllowUserToOrderColumns = true;
            this.kryptonDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kryptonDataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.kryptonDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonDataGridView1.Location = new System.Drawing.Point(0, 35);
            this.kryptonDataGridView1.Name = "kryptonDataGridView1";
            this.kryptonDataGridView1.RowTemplate.Height = 25;
            this.kryptonDataGridView1.Size = new System.Drawing.Size(1257, 509);
            this.kryptonDataGridView1.TabIndex = 4;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RetrieveDataMenuItem,
            this.ExportToExcelItemMenu});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 48);
            // 
            // RetrieveDataMenuItem
            // 
            this.RetrieveDataMenuItem.Image = global::PavilionKyrpton.Properties.Resources.import;
            this.RetrieveDataMenuItem.Name = "RetrieveDataMenuItem";
            this.RetrieveDataMenuItem.Size = new System.Drawing.Size(152, 22);
            this.RetrieveDataMenuItem.Text = "Retrieve Data";
            this.RetrieveDataMenuItem.Click += new System.EventHandler(this.RetrieveDataMenuItem_Click);
            // 
            // ExportToExcelItemMenu
            // 
            this.ExportToExcelItemMenu.Image = global::PavilionKyrpton.Properties.Resources.xlsx_file_format_extension__1_;
            this.ExportToExcelItemMenu.Name = "ExportToExcelItemMenu";
            this.ExportToExcelItemMenu.Size = new System.Drawing.Size(152, 22);
            this.ExportToExcelItemMenu.Text = "Export to Excel";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.locationsDropDown,
            this.HubDropDown,
            this.ServiceTypeDropDown});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1257, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // locationsDropDown
            // 
            this.locationsDropDown.Name = "locationsDropDown";
            this.locationsDropDown.Size = new System.Drawing.Size(121, 25);
            // 
            // HubDropDown
            // 
            this.HubDropDown.Name = "HubDropDown";
            this.HubDropDown.Size = new System.Drawing.Size(121, 25);
            // 
            // ServiceTypeDropDown
            // 
            this.ServiceTypeDropDown.Name = "ServiceTypeDropDown";
            this.ServiceTypeDropDown.Size = new System.Drawing.Size(121, 25);
            // 
            // splitter1
            // 
            this.splitter1.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 25);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1257, 10);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // ContractList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1257, 544);
            this.Controls.Add(this.kryptonDataGridView1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ContractList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ContractList";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kryptonDataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ExportToExcelItemMenu;
        private System.Windows.Forms.ToolStripMenuItem RetrieveDataMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStripComboBox locationsDropDown;
        private System.Windows.Forms.ToolStripComboBox HubDropDown;
        private System.Windows.Forms.ToolStripComboBox ServiceTypeDropDown;
    }
}