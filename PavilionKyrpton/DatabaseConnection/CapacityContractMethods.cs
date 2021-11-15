using Microsoft.EntityFrameworkCore;
using PavilionKyrpton.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavilionKyrpton.DatabaseConnection
{
    public class CapacityContractMethods : DbConnection
    {
        

        public void SaveCapacityContract(CapacityContract capacityContract)
        {
            var capacityContractDB = this.CapacityContracts
                                    .AsNoTracking()
                                    .Where(x => x.CapacityContractId == capacityContract.CapacityContractId)
                                    .FirstOrDefault();


            if(capacityContractDB == null)
            {
                this.CapacityContracts.Add(capacityContract);
            }
            else
            {
                this.CapacityContracts.Update(capacityContract);
            }

            this.SaveChanges();            
        }

        public DataTable GetCapacityContracts()
        {
            var data = CapacityContracts.ToList<CapacityContract>();
            var dt = new DataTable();
                        
            dt.Columns.Add("CapacityContractId", typeof(string));
            dt.Columns.Add("Network", typeof(string));
            dt.Columns.Add("InfrastructureType", typeof(string));
            dt.Columns.Add("Infrastructure", typeof(string));
            dt.Columns.Add("ServiceType", typeof(string));
            dt.Columns.Add("BegTime", typeof(DateTime));
            dt.Columns.Add("EndTime", typeof(DateTime));
            dt.Columns.Add("Quantity", typeof(decimal));
            dt.Columns.Add("Buy_Sell", typeof(string));
            dt.Columns.Add("Price", typeof(decimal));
            dt.Columns.Add("TradeDate", typeof(DateTime));
            dt.Columns.Add("QuantityUnit", typeof(string));
            dt.Columns.Add("PriceUnit", typeof(string));
            dt.Columns.Add("Currency", typeof(string));
            dt.Columns.Add("TimeZone", typeof(string));

            foreach (var item in data)
            {
                var newRow = dt.NewRow();
                
                newRow["CapacityContractId"] = item.CapacityContractId;
                newRow["Network"] = item.Network;
                newRow["InfrastructureType"] = item.InfrastructureType;
                newRow["Infrastructure"] = item.Infrastructure;
                newRow["ServiceType"] = item.ServiceType;
                newRow["BegTime"] = item.BegTime;
                newRow["EndTime"] = item.EndTime;
                newRow["Quantity"] = Math.Abs(item.Quantity);
                newRow["Buy_Sell"] = item.Buy_Sell;
                newRow["Price"] = item.Price;
                newRow["TradeDate"] = item.TradeDate;
                newRow["QuantityUnit"] = item.QuantityUnit;
                newRow["PriceUnit"] = item.PriceUnit;
                newRow["Currency"] = item.Currency;
                newRow["TimeZone"] = item.TimeZone;
         
                dt.Rows.Add(newRow);
            }

            return dt;
        }

        public void DeleteCapacityContract(CapacityContract capacityContract)
        {

            var capacityContractDB = CapacityContracts.Find(capacityContract.CapacityContractId);

            if (capacityContractDB != null)
            {
                CapacityContracts.Remove(capacityContract);
                SaveChanges();
            }
        }

        public IEnumerable<CapacityContractFlow> GetCapacityContractsByPeriod(DateTime begtime, DateTime endtime)
        {
            List<CapacityContractFlow> vFlows = new List<CapacityContractFlow>();            

            for(DateTime vPeriod = begtime; vPeriod <= endtime; vPeriod = vPeriod.AddDays(1))
            {
                var resultPerDay = from nReg in CapacityContracts.AsEnumerable()
                                   where nReg.BegTime <= vPeriod && vPeriod <= nReg.EndTime
                                   group nReg by new
                                   {
                                       Infastructure = nReg.Infrastructure,
                                       TipoInfrastructura = nReg.InfrastructureType,
                                       Service = nReg.ServiceType,
                                       Hub = nReg.Network,
                                       Begtime = nReg.BegTime

                                   } into balanceGroup
                                   select new
                                   {
                                       quantity = balanceGroup.Sum(x => x.Quantity),
                                       infrastructure = balanceGroup.Key.Infastructure,
                                       tipoinfrastructura = balanceGroup.Key.TipoInfrastructura,
                                       service = balanceGroup.Key.Service,
                                       hub = balanceGroup.Key.Hub
                                   };


                foreach(var item in resultPerDay)
                {
                    vFlows.Add(new CapacityContractFlow()
                    {
                        FlowDate = vPeriod,
                        Quantity = item.quantity,
                        Infrastructure = item.infrastructure,
                        ServiceType = item.service
                    });
                }     
            }


            return vFlows;
        }

        public IEnumerable<CapacityContract> GetCapactyByDate_Infra_Service(DateTime vPeriod, string Infrastructure, string Service)
        {
            return CapacityContracts
                    .Where(x =>
                       x.Infrastructure == Infrastructure &&
                       x.ServiceType == Service &&
                       x.BegTime <= vPeriod &&
                       vPeriod <= x.EndTime)
                    .ToList<CapacityContract>();
        }
    }
}
