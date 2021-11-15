using ExcelDataReader;
using PavilionKyrpton.ApplicationMethods;
using PavilionKyrpton.DatabaseConnection;
using PavilionKyrpton.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PavilionKyrpton.ExcelLoaders
{
    public class EnagasExcelLoader
    {                                   
        public FileClass loadEnagasFile()
        {
            
            const string SHEET_NAME = "Contratos y adendas";
            //const int INIT_ROW = 9;

            FileClass _enagasFile = new FileClass();

            var dialog = new OpenFileDialog();

            //dialog.Filter = "*.xlsx";
            dialog.Title = "Select Enagas file";

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                string contractID = "";

                try
                {
                    var inputFile = new FileInfo(dialog.FileName);

                    _enagasFile.FileName = dialog.FileName;
                    _enagasFile.LoadResult = "OK";
                    _enagasFile.FileType = "ENAGAS";
                    _enagasFile.LoadTime = System.DateTime.Now;
                    _enagasFile.Records = 0;

                    DbConnection dbConnection = new DbConnection();

                    using (var stream = File.Open(dialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                UseColumnDataType = true,
                                ConfigureDataTable = (data) => new ExcelDataTableConfiguration()
                                {
                                    UseHeaderRow = false
                                }
                            });
                            DataTableCollection table = result.Tables;
                            DataTable resultTable = table[SHEET_NAME];



                            foreach(DataRow itemRow in resultTable.Rows)
                            {
                                try
                                {
                                    EnagasFile eFile = new EnagasFile();
                                    
                                    if(itemRow[24].ToString() == "Baja")
                                    {
                                        var deleteValue = dbConnection
                                                            .CapacityContracts
                                                            .Where(x => x.CapacityContractId.Equals(itemRow[0].ToString())).FirstOrDefault();

                                        if (deleteValue != null)
                                        {
                                            CapacityContractMethods deleteMethods = new CapacityContractMethods();
                                            deleteMethods.DeleteCapacityContract(deleteValue);
                                        }                                        

                                    }
                                        


                                    eFile.File = _enagasFile;
                                    contractID = itemRow[0].ToString();

                                    eFile.CodigoContrato = itemRow[0].ToString();
                                    eFile.CodigoAdenda = itemRow[1].ToString();
                                    eFile.FechaFormalizacion = Convert.ToDateTime(itemRow[2]);
                                    eFile.Origen = itemRow[3].ToString();
                                    eFile.NumeroSolicitud = itemRow[4].ToString();
                                    eFile.Comercializador = itemRow[5].ToString();
                                    eFile.Servicio = itemRow[6].ToString();
                                    eFile.MateriaPrima = itemRow[7].ToString();

                                    eFile.NaturalezaCapacidad = itemRow[8].ToString();
                                    eFile.Coordinacion = itemRow[9].ToString();
                                    eFile.SentidoFlujo = itemRow[10].ToString();
                                    eFile.Operador = itemRow[11].ToString();
                                    eFile.TipoInfrastructura = itemRow[12].ToString();
                                    eFile.Infrastructura = itemRow[13].ToString();

                                    eFile.TipoDuracion = itemRow[14].ToString();
                                    eFile.InicioContracto = Convert.ToDateTime(itemRow[15]);
                                    eFile.FinContracto = Convert.ToDateTime(itemRow[16]);

                                    eFile.Duracion_horas = Convert.ToInt16(itemRow[17]);
                                    eFile.QTotalContratada_Volume = Convert.ToDecimal(itemRow[18]);
                                    eFile.QTotalContratada_Units = itemRow[19].ToString();
                                    eFile.QFirmeContratada_Volume = Convert.ToDecimal(itemRow[20]);
                                    eFile.QFirmeContratada_Units = itemRow[21].ToString();
                                    //eFile.QIntContratada_Volume = Convert.ToDecimal(itemRow[22]);
                                    //eFile.QFirmeContratada_Units = itemRow[23].ToString();

                                    eFile.Estado = itemRow[24].ToString();
                                    //Pendiente fecha baja
                                    eFile.ContratoOrigen = itemRow[26].ToString();
                                    eFile.Transaccion = itemRow[27].ToString();

                                    eFile.CodigoSubasta = itemRow[28].ToString();
                                    eFile.IdOfertaTransaccion = itemRow[29].ToString();
                                    //eFile.Prima_Value = Convert.ToDecimal(itemRow[30]);
                                    eFile.Prima_Units = itemRow[31].ToString();

                                    //eFile.Prima_Value = Convert.ToDecimal(itemRow[32]);
                                    eFile.Prima_Units = itemRow[33].ToString();

                                    var existValue = dbConnection.EnagasFiles.Where(x => x.CodigoContrato.Equals(eFile.CodigoContrato)).Any();

                                    if(existValue)
                                    {
                                        dbConnection.EnagasFiles.Update(eFile);
                                    }
                                    else
                                    {
                                        dbConnection.EnagasFiles.Add(eFile);
                                    }

                                    _enagasFile.Records += 1;
                                    dbConnection.SaveChanges();

                                    //Add the contract to the database
                                    CapacityContract capacityContract = new CapacityContract()
                                    {
                                        CapacityContractId = eFile.CodigoContrato,
                                        Network = "PVB",
                                        InfrastructureType = eFile.TipoInfrastructura,
                                        Infrastructure = eFile.Infrastructura,
                                        ServiceType = eFile.Servicio,
                                        BegTime = eFile.InicioContracto,
                                        EndTime = eFile.FinContracto,
                                        Quantity = Math.Abs(eFile.QFirmeContratada_Volume),
                                        Buy_Sell = eFile.QFirmeContratada_Volume >= 0 ? "BUY" : "SELL",
                                        //Price = eFile.Precio_Value,
                                        TradeDate = eFile.FechaFormalizacion,
                                        QuantityUnit = eFile.QTotalContratada_Units,
                                        PriceUnit = eFile.Precio_Units,
                                        Currency = "EUR",
                                        TimeZone = "CET"
                                    };

                                    CapacityContractMethods capacityContractMethods = new CapacityContractMethods();
                                    capacityContractMethods.SaveCapacityContract(capacityContract);
                                }
                                catch(Exception ex)
                                {
                                    if(ConfigurationManager.AppSettings["eurorunnerfolder"] == "DEBUG")
                                    {
                                        LoggingClass.WriteLog(contractID, "******************", "loadEnagasFile");
                                        LoggingClass.WriteLog(ex.Message, "ERROR", "loadEnagasFile");
                                        LoggingClass.WriteLog(contractID, "******************", "loadEnagasFile");
                                    }

                                    
                                }
                            }

                            dbConnection.SaveChanges();
                        }
                    }


                    

                    SaveFileToDataBase(_enagasFile);
                }
                catch(Exception ex) 
                {
                    LoggingClass.WriteLog(ex.ToString(), "ERROR", "loadEnagasFile");
                }
            }

            return _enagasFile;
        }

        public void SaveFileToDataBase(FileClass file)
        {
            DbConnection dbConnection = new DbConnection();
            
            dbConnection.Files.Add(file);
            dbConnection.SaveChanges();
        }

        public IEnumerable<FileClass> RetrieveFilesFromDatabase()
        {
            DbConnection dbConnection = new DbConnection();

            return dbConnection
                    .Files
                    .ToList();
        }

        public DataTable RetrieveDetailsFromFile(int Id)
        {
            EnagasFile eFile = new EnagasFile();
            DbConnection dbConnection = new DbConnection();

            var dt = eFile.GenerateTableWithColumns();
            var rowsPerId = dbConnection.EnagasFiles.Where(x => x.FileId.Equals(Id)).ToList();

            foreach(var item in rowsPerId)
            {
                var row = dt.NewRow();

                row["Id"] = item.Id;
                row["CodigoContrato"] = item.CodigoContrato;
                row["FileId"] = item.FileId;
                row["CodigoAdenda"] = item.CodigoAdenda;
                row["FechaFormalizacion"] = item.FechaFormalizacion;
                row["Origen"] = item.Origen;
                row["NumeroSolicitud"] = item.NumeroSolicitud;
                row["Comercializador"] = item.Comercializador;
                row["Servicio"] = item.Servicio;
                row["MateriaPrima"] = item.MateriaPrima;
                row["NaturalezaCapacidad"] = item.NaturalezaCapacidad;
                row["Coordinacion"] = item.Coordinacion;
                row["SentidoFlujo"] = item.SentidoFlujo;
                row["Operador"] = item.Operador;
                row["TipoInfrastructura"] = item.TipoInfrastructura;
                row["Infrastructura"] = item.Infrastructura;
                row["TipoDuracion"] = item.TipoDuracion;
                row["InicioContracto"] = item.InicioContracto;
                row["FinContracto"] = item.FinContracto;
                row["Duracion_horas"] = item.Duracion_horas;
                row["QTotalContratada_Volume"] = item.QTotalContratada_Volume;
                row["QTotalContratada_Units"] = item.QTotalContratada_Units;
                row["QFirmeContratada_Volume"] = item.QFirmeContratada_Volume;
                row["QFirmeContratada_Units"] = item.QFirmeContratada_Units;
                row["QIntContratada_Volume"] = item.QIntContratada_Volume;
                row["QIntContratada_Units"] = item.QIntContratada_Units;
                row["Estado"] = item.Estado;
                row["FechaBaja"] = item.FechaBaja;
                row["TipoPeaje"] = item.TipoPeaje;
                row["ContratoOrigen"] = item.ContratoOrigen;
                row["Transaccion"] = item.Transaccion;
                row["CodigoSubasta"] = item.CodigoSubasta;
                row["IdOfertaTransaccion"] = item.IdOfertaTransaccion;
                row["Prima_Value"] = item.Prima_Value;
                row["Prima_Units"] = item.Prima_Units;
                row["Precio_Value"] = item.Precio_Value;
                row["Precio_Units"] = item.Precio_Units;

                dt.Rows.Add(row);
            }
            
            dt.AcceptChanges();
    
            return dt;
        }

        public IEnumerable<FileClass> RetrieveFilesFromDatabaseByType(string type)
        {
            DbConnection dbConnection = new DbConnection();

            return dbConnection
                    .Files
                    .Where( x=> x.FileType.Equals(type))
                    .ToList();
        }

        public void DeleteFileFromDataBase(int Id)
        {
            DbConnection dbConnection = new DbConnection();

            var itemToDelete = dbConnection.Files.Where(x => x.Id.Equals(Id)).FirstOrDefault();

            if (itemToDelete != null)
            {

                dbConnection.Files.Remove(itemToDelete);
                dbConnection.SaveChanges();
            }

            return;
        }
    }
}
