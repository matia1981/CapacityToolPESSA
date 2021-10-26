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


       public void GenerateXMLFile(int fileID)
        {
            var fileRows = _db.EnagasFiles
                            .Where(x => x.FileId == fileID)
                            .AsEnumerable<EnagasFile>();

            eurorunnerDataSet dInput = new eurorunnerDataSet();


            foreach (var row in fileRows)
            {
                var newRow = dInput.capacity_trade.Newcapacity_tradeRow();
                newRow.amount = row.QTotalContratada_Volume;
                newRow.unit = row.QTotalContratada_Units.Substring(0, 3);
                newRow.amount_type = "D";

                newRow.buy_sell = "B";
                //newRow.book_name = "prueba";
                newRow.category = "T";
                newRow.code = row.CodigoContrato;
                
                newRow.direction = FlowDirectionGenerationByRow(row);
                
                newRow.firmness = "F";
                newRow.location = row.Infrastructura;
                newRow.location_type = "F";
                newRow.network = "PVB";
                //newRow.price = 10;
                newRow.shipper = row.Comercializador;
                newRow.start_dts = row.InicioContracto;
                newRow.end_dts = row.FinContracto;

                newRow.temperature = "25";
                newRow.time_zone = "CET";

                dInput.capacity_trade.Rows.Add(newRow);

            }



            dInput.WriteXml(ConfigurationManager.AppSettings["eurorunnerfolder"] + @"\prueba.xml");



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
