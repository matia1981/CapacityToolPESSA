using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavilionKyrpton.Entities
{
    public class CapacityContract
    {
        [Key]
        public string CapacityContractId { get; set; }

        public string Network { get; set; }

        public string InfrastructureType { get; set; }

        public string Infrastructure { get; set; }

        public string ServiceType { get; set; }

        public DateTime BegTime { get; set; }

        public DateTime EndTime { get; set; }

        public decimal Quantity { get; set; }

        public string Buy_Sell { get; set; }

        public decimal Price { get; set; }

        public DateTime TradeDate { get; set; }

        public string QuantityUnit { get; set;}

        public string PriceUnit { get; set; }

        public string Currency { get; set; }

        public string TimeZone { get; set; }

    }

    public class CapacityContractFlow
    {
        public int Id { get; set; }

        public DateTime FlowDate { get; set; }

        public decimal Quantity { get; set; }

        public string Infrastructure { get; set; }

        public string ServiceType { get; set; }



    }
}
