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

            foreach (var row in items)
            {
                var rowDB = _db.EnagasFiles
                            .Where(x => x.CodigoContrato == row)
                            .FirstOrDefault();

                var location = _db.Locations
                                .Where(x => x.EnagasLocation == rowDB.Infrastructura)
                                .FirstOrDefault();


                var newRow = dInput.capacity_trade.Newcapacity_tradeRow();

                newRow.amount =      rowDB.QTotalContratada_Volume;
                newRow.unit =        rowDB.QTotalContratada_Units.Substring(0, 3);
                newRow.amount_type = "D";

                newRow.buy_sell    = "B";                
                newRow.category = "T";
                newRow.code = rowDB.CodigoContrato;

                newRow.direction = FlowDirectionGenerationByRow(rowDB);

                newRow.firmness = "F";
                newRow.location = location.EurorunnerLocation;
                newRow.location_type = location.Location_Type;
                newRow.network = location.Network;
                
                newRow.shipper = rowDB.Comercializador;
                newRow.start_dts = rowDB.InicioContracto;
                newRow.end_dts = rowDB.FinContracto;

                newRow.temperature = location.Temperature;
                newRow.time_zone = location.Timezone;

                dInput.capacity_trade.Rows.Add(newRow);
            }

            var fileName = System.DateTime.Now.ToFileTime();
            dInput.WriteXml(ConfigurationManager.AppSettings["eurorunnerfolder"] + @"\" + fileName + ".xml");
        }


        private void GenerateXMLFileForEnagasFormat(string id)
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
