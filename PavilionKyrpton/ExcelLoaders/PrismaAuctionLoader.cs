using ExcelDataReader;
using PavilionKyrpton.ApplicationMethods;
using PavilionKyrpton.DatabaseConnection;
using PavilionKyrpton.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PavilionKyrpton.ExcelLoaders
{
    public class PrismaAuctionLoader
    {
        public FileClass LoadPrismaActionFile()
        {
            const string SHEET_NAME = "Auction Report";

            FileClass _File = new FileClass();

            var dialog = new OpenFileDialog();
            dialog.Title = "Select Prisma Auction file";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var inputFile = new FileInfo(dialog.FileName);

                    _File.FileName = dialog.FileName;
                    _File.LoadResult = "OK";
                    _File.FileType = "PRISMA_AUCTION";
                    _File.LoadTime = System.DateTime.Now;
                    _File.Records = 0;

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

                            foreach (DataRow itemRow in resultTable.Rows)
                            {
                                try
                                {
                                    PrismaAuctionFile eFile = new PrismaAuctionFile();
                                    eFile.File = _File;
                                    eFile.Dealid = itemRow[0].ToString();

                                    eFile.StartOfAuction = System.DateTime.Today; // Convert.ToDateTime(itemRow[5]);

                                    eFile.RunTimeStart = Convert.ToDateTime(itemRow[10]);
                                    eFile.RunTimeEnd = Convert.ToDateTime(itemRow[11]);

                                    eFile.TSOEntry = "PENDING";
                                    eFile.QTotalDemandedCapacity_Unit = "PENDING";
                                    eFile.QTotalDemandedCapacity_Value = 100000;

                                    var existValue = dbConnection.prismaAuctionContracts.Where(x => x.Dealid.Equals(eFile.Dealid)).FirstOrDefault();

                                    if (existValue != null)
                                    {
                                        dbConnection.prismaAuctionContracts.Update(eFile);
                                    }
                                    else
                                    {
                                        dbConnection.prismaAuctionContracts.Add(eFile);
                                    }

                                    _File.Records += 1;

                                    //Add the contract to the database
                                    CapacityContract capacityContract = new CapacityContract()
                                    {
                                        CapacityContractId = eFile.Dealid,
                                        Network = eFile.TSOEntry,
                                        InfrastructureType = eFile.TSOEntry,
                                        Infrastructure = eFile.TSOEntry,
                                        ServiceType = eFile.TSOEntry,
                                        BegTime = eFile.RunTimeStart,
                                        EndTime = eFile.RunTimeStart,
                                        Quantity = eFile.QTotalDemandedCapacity_Value,
                                        Buy_Sell = "BUY",
                                        //Price = eFile.Precio_Value,
                                        TradeDate = eFile.StartOfAuction,
                                        QuantityUnit = eFile.QTotalDemandedCapacity_Unit,
                                        PriceUnit = eFile.QTotalDemandedCapacity_Unit,
                                        Currency = "EUR",
                                        TimeZone = "CET"
                                    };

                                    CapacityContractMethods capacityContractMethods = new CapacityContractMethods();
                                    capacityContractMethods.SaveCapacityContract(capacityContract);

                                }
                                catch (Exception ex)
                                {
                                    LoggingClass.WriteLog(ex.ToString(), "ERROR", "loadPrismaAuctionFile");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    LoggingClass.WriteLog(ex.ToString(), "ERROR", "loadPrismaAuctionFile");
                }
            }

            return _File;
        }

        public IEnumerable<FileClass> RetrieveFilesFromDatabase()
        {
            DbConnection dbConnection = new DbConnection();

            return dbConnection
                    .Files
                    .ToList();
        }

        public IEnumerable<FileClass> RetrieveFilesFromDatabaseByType(string type)
        {
            DbConnection dbConnection = new DbConnection();

            return dbConnection
                    .Files
                    .Where(x => x.FileType.Equals(type))
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
