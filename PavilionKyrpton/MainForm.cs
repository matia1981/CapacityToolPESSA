using PavilionKyrpton.ApplicationMethods;
using PavilionKyrpton.DatabaseConnection;
using PavilionKyrpton.Entities;
using PavilionKyrpton.ExcelLoaders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PavilionKyrpton
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void RetrieveDataButton_Click(object sender, System.EventArgs e)
        {
            var viewSelected = ViewMethods.viewSelected;

            switch (viewSelected)
            {
                case "users":
                    this.kryptonDataGridView1.DataSource = UserMethods.RetrieveUsers();
                    break;
                case "enagasload":
                    EnagasExcelLoader eLoader = new EnagasExcelLoader();
                    this.kryptonDataGridView1.DataSource = eLoader.RetrieveFilesFromDatabaseByType("ENAGAS");
                    break;
                case "prismaauction":
                    PrismaAuctionLoader pLoader = new PrismaAuctionLoader();
                    this.kryptonDataGridView1.DataSource = pLoader.RetrieveFilesFromDatabaseByType("PRISMA_AUCTION");
                    break;
                case "locations":
                    this.kryptonDataGridView1.DataSource = MasterDataMethods.getLocations();
                    break;

            }
        }

        private void UpdateDataButton_Click(object sender, System.EventArgs e)
        {
            var viewSelected = ViewMethods.viewSelected;

            switch (viewSelected)
            {
                case "users":
                    UserMethods.UpdateUser((DataTable)this.kryptonDataGridView1.DataSource);
                    break;
                case "locations":
                    MasterDataMethods.addLocation((DataTable)this.kryptonDataGridView1.DataSource);
                    break;
            }
        }

        private void DeleteDataButton_Click(object sender, System.EventArgs e)
        {
            var viewSelected = ViewMethods.viewSelected;

            switch (viewSelected)
            {
                case "enagasload":
                    var itemId = Convert.ToInt32(this.kryptonDataGridView1.SelectedRows[0].Cells["Id"].Value);
                    EnagasExcelLoader eLoader = new EnagasExcelLoader();
                    eLoader.DeleteFileFromDataBase(itemId);
                    this.kryptonDataGridView1.DataSource = eLoader.RetrieveFilesFromDatabaseByType("ENAGAS");
                    break;
                case "prismaauction":
                    var fileId = Convert.ToInt32(this.kryptonDataGridView1.SelectedRows[0].Cells["Id"].Value);
                    PrismaAuctionLoader pLoader = new PrismaAuctionLoader();
                    pLoader.DeleteFileFromDataBase(fileId);
                    this.kryptonDataGridView1.DataSource = pLoader.RetrieveFilesFromDatabaseByType("PRISMA_AUCTION");
                    break;
                case "users":
                    var userID = Convert.ToInt32(this.kryptonDataGridView1.SelectedRows[0].Cells["Id"].Value);
                    UserMethods.DeleteUser(userID);
                    break;
                case "locations":
                    var locationID = Convert.ToInt32(this.kryptonDataGridView1.SelectedRows[0].Cells["Id"].Value);
                    MasterDataMethods.deleteLocation(locationID);
                    break;
            }
        }

        private void UsersMenu_Click(object sender, System.EventArgs e)
        {
            ViewMethods.viewSelected = "users";
            this.navigatorText.Text = "Administration >> Users";
        }

        private void GetDataFromEnagasButton_Click(object sender, System.EventArgs e)
        {
            ViewMethods.viewSelected = "enagasload";
            this.navigatorText.Text = "Load Data >> Enagas";
        }

        private void LoadFile_Click(object sender, System.EventArgs e)
        {
            var viewSelected = ViewMethods.viewSelected;

            switch (viewSelected)
            {
                case "enagasload":
                    try
                    {
                        var file = LoadFileMethods.loadFile(viewSelected);

                        MessageBox.Show("File loaded!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        EnagasExcelLoader eLoader = new EnagasExcelLoader();
                        this.kryptonDataGridView1.DataSource = eLoader.RetrieveFilesFromDatabaseByType("ENAGAS");
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Error loading file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LoggingClass.WriteLog(ex.ToString(), "ERROR", "LoadFile_Click" + "_" + viewSelected);
                    }

                    //AddFileLoaded(file);
                    break;
                case "prismaauction":
                    try
                    {
                        var file = LoadFileMethods.loadFile(viewSelected);

                        MessageBox.Show("File loaded!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        PrismaAuctionLoader pLoader = new PrismaAuctionLoader();
                        this.kryptonDataGridView1.DataSource = pLoader.RetrieveFilesFromDatabaseByType("PRISMA_AUCTION");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LoggingClass.WriteLog(ex.ToString(), "ERROR", "LoadFile_Click" + "_" + viewSelected);
                    }
                    break;
            }
        }
        
        private void DetailsMenu_Click(object sender, EventArgs e)
        {
            var viewSelected = ViewMethods.viewSelected;

            switch (viewSelected)
            {
                case "enagasload":
                    var itemId = Convert.ToInt32(this.kryptonDataGridView1.SelectedRows[0].Cells["Id"].Value);
                    EnagasExcelLoader eLoader = new EnagasExcelLoader();
                    var datatable = eLoader.RetrieveDetailsFromFile(itemId);
                    FileDetailForm fDetail = new FileDetailForm();
                    fDetail.FileDetailGrid.DataSource = datatable;
                    fDetail.Visible = true;
                    fDetail.Activate();
                    
                    break;
                case "users":
                    var userID = Convert.ToInt32(this.kryptonDataGridView1.SelectedRows[0].Cells["Id"].Value);
                    UserMethods.DeleteUser(userID);
                    break;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem10_Click(object sender, System.EventArgs e)
        {
            var aboutForm = new AboutForm();
            aboutForm.Visible = true;
            aboutForm.Activate();
        }

        private void kryptonContextMenu1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void generateXMLMenuItem_Click(object sender, EventArgs e)
        {
            var viewSelected = ViewMethods.viewSelected;

            switch (viewSelected)
            {
                case "enagasload":
                    var itemId = Convert.ToInt32(this.kryptonDataGridView1.SelectedRows[0].Cells["Id"].Value);
                    MessageBox.Show("Generating XML file", "Info", MessageBoxButtons.OK);

                    EurorunnerMethods eurorunnerMethods = new EurorunnerMethods(new DbConnection());
                    eurorunnerMethods.GenerateXMLFile(itemId);

                    break;
                case "users":

                    break;
            }
        }

        private void capacityContractsMenu_Click(object sender, EventArgs e)
        {
            ContractList cListForm = new ContractList();
            cListForm.Visible = true;
            cListForm.Activate();
        }

        private void capacitybydayMenu_Click(object sender, EventArgs e)
        {
            ContractsBalanceForm cFlowForm = new ContractsBalanceForm();
            cFlowForm.Visible = true;
            cFlowForm.Activate();
        }

        private void PointsMenu_Click(object sender, EventArgs e)
        {
            ViewMethods.viewSelected = "locations";
            this.navigatorText.Text = "Master Data >> Points";
        }

        private void addRowButton_Click(object sender, EventArgs e)
        {
            //var viewSelected = ViewMethods.viewSelected;

            //switch (viewSelected)
            //{
            //    case "locations":
            //        var ds = (List<Location>) this.kryptonDataGridView1.DataSource;
            //        ds.Add(new Entities.Location());
            //        this.kryptonDataGridView1.DataSource = ds;
            //        break;
            //}
            ////var dt = (DataTable)this.kryptonDataGridView1.DataSource;
            ////var row = dt.NewRow();

            ////dt.Rows.Add(row);
        }

        private void prisma1_menu_Click(object sender, EventArgs e)
        {
            ViewMethods.viewSelected = "prismaauction";
            this.navigatorText.Text = "Load Data >> Prisma Auction";
        }
    }
}
