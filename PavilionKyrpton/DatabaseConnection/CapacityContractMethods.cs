using PavilionKyrpton.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavilionKyrpton.DatabaseConnection
{
    public class CapacityContractMethods : DbConnection
    {
        public void SaveCapacityContract(CapacityContract capacityContract)
        {
            var capacityContractDB = CapacityContracts.Find(capacityContract.CapacityContractId);

            if(capacityContractDB == null)
            {
                CapacityContracts.Add(capacityContract);
            }
            else
            {
                CapacityContracts.Update(capacityContract);
            }

            SaveChanges();
        }

        public IEnumerable<CapacityContract> GetCapacityContracts()
        {
            return CapacityContracts.ToList<CapacityContract>();
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
