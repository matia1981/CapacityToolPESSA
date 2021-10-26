using PavilionKyrpton.DatabaseConnection;
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
    public partial class ContractList : Form
    {
        public ContractList()
        {
            InitializeComponent();
        }
        
        private void RetrieveDataMenuItem_Click(object sender, EventArgs e)
        {
            CapacityContractMethods contractMethods = new CapacityContractMethods();
            var result = contractMethods.GetCapacityContracts();

            this.kryptonDataGridView1.DataSource = result;



        }
    }
}
