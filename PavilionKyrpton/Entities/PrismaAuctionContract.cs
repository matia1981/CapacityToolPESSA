using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavilionKyrpton.Entities
{
    public class PrismaAuctionFile
    {
        public int Id { get; set; }

        public int FileId { get; set; }

        public FileClass File { get; set; }

        public string Dealid { get; set; }

        public string Bidid { get; set; }

        public string AuctionId { get; set; }

        public string AuctionStatus { get; set; }

        public string Product { get; set; }

        public DateTime StartOfAuction { get; set; }

        public string TSOExit { get; set; }

        public string TSOEntry { get; set; }

        public string MarketAreaExit { get; set; }

        public string MarketAreaEntry { get; set; }

        public DateTime RunTimeStart { get; set; }

        public DateTime RunTimeEnd { get; set; }

        public string NetworkPointEntry { get; set; }

        public string NetworkPointExit { get; set; }

        public string NetworkPointEntryId { get; set; }

        public string NetworkPointExitId { get; set; }

        public string Direction { get; set; }

        public string TypeOfGas { get; set; }

        public string CapacityCategoryExit {get; set;}

        public string CapacityCategoryEntry { get; set; }

        public decimal QMarketTable_Value { get; set; }

        public string QMarketTable_Unit { get; set; }

        public decimal QCompetition_Value { get; set; }

        public string QCompetition_Unit { get; set; }

        public decimal QTotalDemandedCapacity_Value { get; set; }

        public string QTotalDemandedCapacity_Unit { get; set; }

        public decimal QMarketedCapacity_Value { get; set; }

        public string QMarketedCapacity_Unit { get; set; }

        public int NUpgradeRequests { get; set; }

        public decimal QTotalUpgradeRequests_Value { get; set; }

        public string QTotalUpgradeRequests_Unit { get; set; }

        public int NParticipantsShipperCompanies { get; set; }

        public int NConcludedContracts { get; set; }

        public decimal AuctionStartPriceExit_Value { get; set; }

        public string AuctionStartPriceExit_Unit { get; set; }

        public decimal AuctionStartPricEntry_Value { get; set; }

        public string AuctionStartPriceEntry_Unit { get; set; }

        public decimal RegulatedCapacityTariffExit_Value { get; set; }

        public string RegulatedCapacityTariffExit_Unit { get; set; }

        public decimal RegulatedCapacityTariffEntry_Value { get; set; }

        public string RegulatedCapacityTariffEntry_Unit { get; set; }

        public decimal MeasuringFeeExit_Value { get; set; }

        public string MeasuringFeeExit_Unit { get; set; }

        public decimal MeasuringFeeEntry_Value { get; set; }

        public string MeasuringFeeEntry_Unit { get; set; }



    }
}
