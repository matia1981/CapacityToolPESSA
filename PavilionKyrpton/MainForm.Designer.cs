
using PavilionKyrpton.ApplicationMethods;
using PavilionKyrpton.DatabaseConnection;
using System.Data;

namespace PavilionKyrpton
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.capacityMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.capacityContractsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.capacitybydayMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.enagasMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.masterDataMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PointsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ServiceTypeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.adminMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.dataBaseMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.getDataButton = new System.Windows.Forms.ToolStripButton();
            this.updateDataButton = new System.Windows.Forms.ToolStripButton();
            this.addRowButton = new System.Windows.Forms.ToolStripButton();
            this.deleteButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.loadFileButton = new System.Windows.Forms.ToolStripButton();
            this.generateXML = new System.Windows.Forms.ToolStripButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.detailsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteItemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.generateXMLMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseSource = new System.Windows.Forms.BindingSource(this.components);
            this.navigatorText = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonDataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.databaseSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.capacityMenu,
            this.loadMenu,
            this.masterDataMenu,
            this.adminMenu,
            this.HelpMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1287, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // capacityMenu
            // 
            this.capacityMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.capacityContractsMenu,
            this.capacitybydayMenu});
            this.capacityMenu.Name = "capacityMenu";
            this.capacityMenu.Size = new System.Drawing.Size(65, 20);
            this.capacityMenu.Text = "Capacity";
            // 
            // capacityContractsMenu
            // 
            this.capacityContractsMenu.Name = "capacityContractsMenu";
            this.capacityContractsMenu.Size = new System.Drawing.Size(174, 22);
            this.capacityContractsMenu.Text = "Capacity Contracts";
            this.capacityContractsMenu.Click += new System.EventHandler(this.capacityContractsMenu_Click);
            // 
            // capacitybydayMenu
            // 
            this.capacitybydayMenu.Name = "capacitybydayMenu";
            this.capacitybydayMenu.Size = new System.Drawing.Size(174, 22);
            this.capacitybydayMenu.Text = "Capacity Balance";
            this.capacitybydayMenu.Click += new System.EventHandler(this.capacitybydayMenu_Click);
            // 
            // loadMenu
            // 
            this.loadMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enagasMenu});
            this.loadMenu.Name = "loadMenu";
            this.loadMenu.Size = new System.Drawing.Size(72, 20);
            this.loadMenu.Text = "Load Data";
            // 
            // enagasMenu
            // 
            this.enagasMenu.Name = "enagasMenu";
            this.enagasMenu.Size = new System.Drawing.Size(111, 22);
            this.enagasMenu.Text = "Enagas";
            this.enagasMenu.Click += new System.EventHandler(this.GetDataFromEnagasButton_Click);
            // 
            // masterDataMenu
            // 
            this.masterDataMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PointsMenu,
            this.ServiceTypeMenu});
            this.masterDataMenu.Name = "masterDataMenu";
            this.masterDataMenu.Size = new System.Drawing.Size(82, 20);
            this.masterDataMenu.Text = "Master Data";
            // 
            // PointsMenu
            // 
            this.PointsMenu.Name = "PointsMenu";
            this.PointsMenu.Size = new System.Drawing.Size(107, 22);
            this.PointsMenu.Text = "Points";
            this.PointsMenu.Click += new System.EventHandler(this.PointsMenu_Click);
            // 
            // ServiceTypeMenu
            // 
            this.ServiceTypeMenu.Name = "ServiceTypeMenu";
            this.ServiceTypeMenu.Size = new System.Drawing.Size(107, 22);
            this.ServiceTypeMenu.Text = "Types";
            // 
            // adminMenu
            // 
            this.adminMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataBaseMenu});
            this.adminMenu.Name = "adminMenu";
            this.adminMenu.Size = new System.Drawing.Size(98, 20);
            this.adminMenu.Text = "Administration";
            // 
            // dataBaseMenu
            // 
            this.dataBaseMenu.Name = "dataBaseMenu";
            this.dataBaseMenu.Size = new System.Drawing.Size(180, 22);
            this.dataBaseMenu.Text = "Database";
            // 
            // HelpMenu
            // 
            this.HelpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem9,
            this.toolStripMenuItem10});
            this.HelpMenu.Name = "HelpMenu";
            this.HelpMenu.Size = new System.Drawing.Size(44, 20);
            this.HelpMenu.Text = "Help";
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(107, 22);
            this.toolStripMenuItem9.Text = "Help";
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(107, 22);
            this.toolStripMenuItem10.Text = "About";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.ToolStripMenuItem10_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getDataButton,
            this.updateDataButton,
            this.addRowButton,
            this.deleteButton,
            this.toolStripSeparator1,
            this.loadFileButton,
            this.generateXML});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1287, 39);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // getDataButton
            // 
            this.getDataButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("getDataButton.BackgroundImage")));
            this.getDataButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.getDataButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.getDataButton.Image = ((System.Drawing.Image)(resources.GetObject("getDataButton.Image")));
            this.getDataButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.getDataButton.Name = "getDataButton";
            this.getDataButton.Size = new System.Drawing.Size(36, 36);
            this.getDataButton.Text = "Get Data";
            this.getDataButton.Click += new System.EventHandler(this.RetrieveDataButton_Click);
            // 
            // updateDataButton
            // 
            this.updateDataButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.updateDataButton.Image = ((System.Drawing.Image)(resources.GetObject("updateDataButton.Image")));
            this.updateDataButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.updateDataButton.Name = "updateDataButton";
            this.updateDataButton.Size = new System.Drawing.Size(36, 36);
            this.updateDataButton.Text = "Save Data";
            this.updateDataButton.Click += new System.EventHandler(this.UpdateDataButton_Click);
            // 
            // addRowButton
            // 
            this.addRowButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addRowButton.Image = ((System.Drawing.Image)(resources.GetObject("addRowButton.Image")));
            this.addRowButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addRowButton.Name = "addRowButton";
            this.addRowButton.Size = new System.Drawing.Size(36, 36);
            this.addRowButton.Text = "Add Row";
            this.addRowButton.Click += new System.EventHandler(this.addRowButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteButton.Image")));
            this.deleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(36, 36);
            this.deleteButton.Text = "Delete";
            this.deleteButton.Click += new System.EventHandler(this.DeleteDataButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // loadFileButton
            // 
            this.loadFileButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("loadFileButton.BackgroundImage")));
            this.loadFileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.loadFileButton.Image = ((System.Drawing.Image)(resources.GetObject("loadFileButton.Image")));
            this.loadFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loadFileButton.Name = "loadFileButton";
            this.loadFileButton.Size = new System.Drawing.Size(36, 36);
            this.loadFileButton.Text = "Load File";
            this.loadFileButton.Click += new System.EventHandler(this.LoadFile_Click);
            // 
            // generateXML
            // 
            this.generateXML.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.generateXML.Image = ((System.Drawing.Image)(resources.GetObject("generateXML.Image")));
            this.generateXML.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.generateXML.Name = "generateXML";
            this.generateXML.Size = new System.Drawing.Size(36, 36);
            this.generateXML.Text = "Export File";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder");
            this.imageList1.Images.SetKeyName(1, "admin");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detailsMenuItem,
            this.deleteItemMenu,
            this.generateXMLMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 70);
            // 
            // detailsMenuItem
            // 
            this.detailsMenuItem.Image = global::PavilionKyrpton.Properties.Resources.preview;
            this.detailsMenuItem.Name = "detailsMenuItem";
            this.detailsMenuItem.Size = new System.Drawing.Size(148, 22);
            this.detailsMenuItem.Text = "See Details";
            this.detailsMenuItem.Click += new System.EventHandler(this.DetailsMenu_Click);
            // 
            // deleteItemMenu
            // 
            this.deleteItemMenu.Image = global::PavilionKyrpton.Properties.Resources.close__2_;
            this.deleteItemMenu.Name = "deleteItemMenu";
            this.deleteItemMenu.Size = new System.Drawing.Size(148, 22);
            this.deleteItemMenu.Text = "Delete Item";
            // 
            // generateXMLMenuItem
            // 
            this.generateXMLMenuItem.Image = global::PavilionKyrpton.Properties.Resources.xml_file_format_symbol;
            this.generateXMLMenuItem.Name = "generateXMLMenuItem";
            this.generateXMLMenuItem.Size = new System.Drawing.Size(148, 22);
            this.generateXMLMenuItem.Text = "Generate XML";
            this.generateXMLMenuItem.Click += new System.EventHandler(this.generateXMLMenuItem_Click);
            // 
            // navigatorText
            // 
            this.navigatorText.Location = new System.Drawing.Point(758, 34);
            this.navigatorText.Name = "navigatorText";
            this.navigatorText.Size = new System.Drawing.Size(517, 23);
            this.navigatorText.TabIndex = 4;
            this.navigatorText.Text = "No view selected";
            // 
            // kryptonDataGridView1
            // 
            this.kryptonDataGridView1.AllowUserToOrderColumns = true;
            this.kryptonDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kryptonDataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.kryptonDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonDataGridView1.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Sheet;
            this.kryptonDataGridView1.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet;
            this.kryptonDataGridView1.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.kryptonDataGridView1.GridStyles.StyleDataCells = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.kryptonDataGridView1.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.kryptonDataGridView1.Location = new System.Drawing.Point(0, 63);
            this.kryptonDataGridView1.Name = "kryptonDataGridView1";
            this.kryptonDataGridView1.RowTemplate.Height = 25;
            this.kryptonDataGridView1.Size = new System.Drawing.Size(1287, 591);
            this.kryptonDataGridView1.TabIndex = 3;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 63);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1287, 3);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1287, 654);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.kryptonDataGridView1);
            this.Controls.Add(this.navigatorText);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Capacity Import";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.databaseSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       


        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loadMenu;
        private System.Windows.Forms.ToolStripMenuItem enagasMenu;
        private System.Windows.Forms.ToolStripMenuItem masterDataMenu;
        private System.Windows.Forms.ToolStripMenuItem adminMenu;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton getDataButton;
        private System.Windows.Forms.ToolStripButton updateDataButton;
        private System.Windows.Forms.ToolStripButton loadFileButton;
        private System.Windows.Forms.ToolStripMenuItem capacityMenu;
        private System.Windows.Forms.ToolStripMenuItem capacityContractsMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem PointsMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem HelpMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem dataBaseMenu;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.BindingSource databaseSource;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox navigatorText;
        private System.Windows.Forms.ToolStripButton deleteButton;
        private System.Windows.Forms.ToolStripButton generateXML;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem capacitybydayMenu;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem detailsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteItemMenu;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kryptonDataGridView1;
        private System.Windows.Forms.ToolStripMenuItem generateXMLMenuItem;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStripMenuItem ServiceTypeMenu;
        private System.Windows.Forms.ToolStripButton addRowButton;
    }
}

