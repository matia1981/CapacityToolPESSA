using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavilionKyrpton.Entities
{
    class EurorunnerContract
    {
        [Key]
        public int CapacityTrade { get; set; }

        public string Buy_sell { get; set; }

        public string Time_zoneField { get; set; }

        public string CodeField { get; set; }

        public decimal PriceField { get; set; }

        public bool PriceFieldSpecified { get; set; }

        public decimal AmountField { get; set; }

        public string NetworkField { get; set; }

        public string ShipperField { get; set; }

        public string Book_nameField { get; set; }

        public string TraderField { get; set; }

        public string Location_typeField { get; set; }

        public string LocationField { get; set; }

        public string CategoryField { get; set; }

        public string DirectionField { get; set; }

        public bool DirectionFieldSpecified { get; set; }

        public string FirmnessField { get; set; }

        public string CommentField { get; set; }
    }

    class EurorunnerCapacityContract
    {
        [Key]
        public int CapacityTrade { get; set; }

        public string Buy_sell { get; set; }

        public string Time_zoneField { get; set; }

        public string CodeField { get; set; }

        public decimal PriceField { get; set; }

        public bool PriceFieldSpecified { get; set; }

        public decimal AmountField { get; set; }

        public string NetworkField { get; set; }

        public string ShipperField { get; set; }

        public string Book_nameField { get; set; }

        public string TraderField { get; set; }

        public string Location_typeField { get; set; }

        public string LocationField { get; set; }

        public string CategoryField { get; set; }

        public string DirectionField { get; set; }

        public bool DirectionFieldSpecified { get; set; }

        public string FirmnessField { get; set; }

        public string CommentField { get; set; }
    }
}
