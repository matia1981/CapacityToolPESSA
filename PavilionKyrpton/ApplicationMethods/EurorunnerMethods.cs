using PavilionKyrpton.DatabaseConnection;
using PavilionKyrpton.Entities;
using PavilionKyrpton.ExcelLoaders;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavilionKyrpton.ApplicationMethods
{
    public class EurorunnerMethods
    {
        private readonly DbConnection _db;

        public EurorunnerMethods(DbConnection db)
        {
            this._db = db;
        }


       public void GenerateXMLFile(List<string> items)
        {
            eurorunnerDataSet dInput = new eurorunnerDataSet();
            eurorunner_contract_details dOutput = new eurorunner_contract_details();

            foreach (var row in items)
            {
                var rowDB = _db.EnagasFiles
                            .Where(x => x.CodigoContrato == row)
                            .FirstOrDefault();

                var existMapping = _db.Locations
                                .Where(x => x.EnagasLocation == rowDB.Infrastructura && x.Service == rowDB.Servicio)
                                .Any();

                if (!existMapping)
                    continue;


                var location = _db.Locations
                                .Where(x => x.EnagasLocation == rowDB.Infrastructura && x.Service == rowDB.Servicio)
                                .FirstOrDefault();

                switch(location.EurorunnerFormat)
                {
                    case "CAPACITY":

                        var newRow = dInput.capacity_trade.Newcapacity_tradeRow();

                        newRow.amount =         Math.Abs(rowDB.QTotalContratada_Volume);
                        newRow.unit =           rowDB.QTotalContratada_Units.Substring(0, 3);
                        newRow.amount_type =    "D";

                        newRow.buy_sell =       rowDB.QTotalContratada_Volume > 0 ? "B" : "S";
                        newRow.category =       "T";
                        newRow.code =           rowDB.CodigoContrato;

                        newRow.direction = location.Direction;// FlowDirectionGenerationByRow(rowDB);

                        newRow.firmness =       "F";
                        newRow.location = location.EurorunnerLocation;
                        newRow.location_type = location.Location_Type;
                        newRow.network = location.Network;

                        newRow.shipper = rowDB.Comercializador;
                        newRow.start_dts = rowDB.InicioContracto;
                        newRow.end_dts = rowDB.FinContracto;

                        newRow.temperature = location.Temperature;
                        newRow.time_zone = location.Timezone;

                        dInput.capacity_trade.Rows.Add(newRow);
                        break;

                    case "CONTRACT_CAPACITY":
                        var newCapacityRow = dOutput.contract_capacity_trade.Newcontract_capacity_tradeRow();

                        newCapacityRow.amount = Math.Abs(rowDB.QTotalContratada_Volume);
                        newCapacityRow.unit = rowDB.QTotalContratada_Units.Substring(0, 3);
                        newCapacityRow.amount_type = "D";

                        newCapacityRow.code = rowDB.CodigoContrato;
                        newCapacityRow.contract = rowDB.CodigoContrato;

                        newCapacityRow.location_type = location.Location_Type;
                        newCapacityRow.location = location.EurorunnerLocation;
                        newCapacityRow.injection_withdrawal = location.Injection_Withdrawal;
                        newCapacityRow.temperature = location.Temperature;
                        newCapacityRow.time_zone = location.Timezone;
                        
                        newCapacityRow.start_dts = rowDB.InicioContracto;
                        newCapacityRow.end_dts = rowDB.FinContracto;
                        newCapacityRow.buy_sell = rowDB.QTotalContratada_Volume > 0 ? "B" : "S";

                        dOutput.contract_capacity_trade.Rows.Add(newCapacityRow);

                        break;
                }              
            }

            var fileName = System.DateTime.Now.ToFileTime();
            dInput.WriteXml(ConfigurationManager.AppSettings["eurorunnerfolder"] + @"\" + fileName  +"capacity" + ".xml");
            dOutput.WriteXml(ConfigurationManager.AppSettings["eurorunnerfolder"] + @"\" + fileName + "capacity_deals" + ".xml");
        }


        private void GenerateXMLFileForCapacityContracts(List<string> items)
        {
           
        }

        private string FlowDirectionGenerationByRow(EnagasFile row)
        {
            var servicio = row.Servicio;
            var infrastructura = row.Infrastructura;
            var flow = "N";

            switch(servicio)
            {
                case "Descarga de buques":
                case "Almacenamiento GNL en Planta":
                    return "N";
                    
                case "Extracción AASS":
                    return "X";
            }




            return flow;

        }



    }
}
