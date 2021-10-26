using PavilionKyrpton.DatabaseConnection;
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
    public partial class ContractsBalanceForm : Form
    {
        public ContractsBalanceForm()
        {
            InitializeComponent();
        }

        private void ContractsBalanceForm_Load(object sender, EventArgs e)
        {
            this.kryptonDateTimePicker1.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            this.kryptonDateTimePicker2.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1).AddDays(-1);
        }

        private void retrieveDataMenu_Click(object sender, EventArgs e)
        {
            CapacityContractMethods capacityContractMethods = new CapacityContractMethods();
            var capacityQuery = capacityContractMethods.GetCapacityContractsByPeriod(this.kryptonDateTimePicker1.Value, this.kryptonDateTimePicker2.Value);

            var listInfrastructure = capacityQuery.Select(x => x.Infrastructure).Distinct();
            var listServices = capacityQuery.Select(x => x.ServiceType).Distinct();

            DataTable dt = new DataTable();
            dt.Columns.Add("flowdate", typeof(DateTime));
            
            foreach(var vInfrastructure in listInfrastructure)
            {
                foreach(var vService in listServices)
                {
                    var existValue = capacityQuery.AsEnumerable().Select(x => x.Infrastructure == vInfrastructure && x.ServiceType == vService).Any();

                    if (!existValue)
                        continue;

                    dt.Columns.Add(string.Format("{0}_{1}", vInfrastructure, vService), typeof(decimal));
                }
            }

            for(DateTime vPeriod = this.kryptonDateTimePicker1.Value; vPeriod <= this.kryptonDateTimePicker2.Value; vPeriod = vPeriod.AddDays(1))
            {
                var newRow = dt.NewRow();
                newRow["flowdate"] = vPeriod;

                foreach (var vInfrastructure in listInfrastructure)
                {
                    foreach (var vService in listServices)
                    {
                        var existValue = capacityQuery.AsEnumerable().Select(x => x.Infrastructure == vInfrastructure && x.ServiceType == vService).Any();

                        if (!existValue)
                            continue;

                        var quantity = capacityQuery.AsEnumerable()
                                        .Where(x => x.Infrastructure == vInfrastructure && x.ServiceType == vService && x.FlowDate == vPeriod)
                                        .Sum(x => x.Quantity);

                        newRow[string.Format("{0}_{1}", vInfrastructure, vService)] = quantity;
                    }
                }

                dt.Rows.Add(newRow);
            }

            this.kryptonDataGridView1.DataSource = dt;


        }

        private void kryptonOutlookGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkDetailsItem_Click(object sender, EventArgs e)
        {
            //if (!this.kryptonDataGridView1.AreAllCellsSelected(false))
            //    return;

            var selectedCells = this.kryptonDataGridView1.SelectedCells;

            foreach(DataGridViewTextBoxCell vCell in selectedCells)
            {

                try
                {
                    var header = vCell.DataGridView.Columns[vCell.ColumnIndex].Name.Split('_');
                    var day = Convert.ToDateTime(vCell.DataGridView.Rows[vCell.RowIndex].Cells[0].Value);

                    var infrastructure = header[0];
                    var servicetype = header[1];

                    CapacityContractMethods capacityContractMethods = new CapacityContractMethods();
                    FileDetailForm fileDetailForm = new FileDetailForm();

                    fileDetailForm.FileDetailGrid.DataSource = capacityContractMethods.GetCapactyByDate_Infra_Service(day, infrastructure, servicetype);
                    fileDetailForm.Visible = true;
                    fileDetailForm.Activate();
                }
                catch { }

            }


        }
    }
}
