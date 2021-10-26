using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PavilionKyrpton.Migrations
{
    public partial class PrismaAuction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "prismaAuctionContracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FileId = table.Column<int>(type: "INTEGER", nullable: false),
                    Dealid = table.Column<string>(type: "TEXT", nullable: true),
                    Bidid = table.Column<string>(type: "TEXT", nullable: true),
                    AuctionId = table.Column<string>(type: "TEXT", nullable: true),
                    AuctionStatus = table.Column<string>(type: "TEXT", nullable: true),
                    Product = table.Column<string>(type: "TEXT", nullable: true),
                    StartOfAuction = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TSOExit = table.Column<string>(type: "TEXT", nullable: true),
                    TSOEntry = table.Column<string>(type: "TEXT", nullable: true),
                    MarketAreaExit = table.Column<string>(type: "TEXT", nullable: true),
                    MarketAreaEntry = table.Column<string>(type: "TEXT", nullable: true),
                    RunTimeStart = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RunTimeEnd = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NetworkPointEntry = table.Column<string>(type: "TEXT", nullable: true),
                    NetworkPointExit = table.Column<string>(type: "TEXT", nullable: true),
                    NetworkPointEntryId = table.Column<string>(type: "TEXT", nullable: true),
                    NetworkPointExitId = table.Column<string>(type: "TEXT", nullable: true),
                    Direction = table.Column<string>(type: "TEXT", nullable: true),
                    TypeOfGas = table.Column<string>(type: "TEXT", nullable: true),
                    CapacityCategoryExit = table.Column<string>(type: "TEXT", nullable: true),
                    CapacityCategoryEntry = table.Column<string>(type: "TEXT", nullable: true),
                    QMarketTable_Value = table.Column<decimal>(type: "TEXT", nullable: false),
                    QMarketTable_Unit = table.Column<string>(type: "TEXT", nullable: true),
                    QCompetition_Value = table.Column<decimal>(type: "TEXT", nullable: false),
                    QCompetition_Unit = table.Column<string>(type: "TEXT", nullable: true),
                    QTotalDemandedCapacity_Value = table.Column<decimal>(type: "TEXT", nullable: false),
                    QTotalDemandedCapacity_Unit = table.Column<string>(type: "TEXT", nullable: true),
                    QMarketedCapacity_Value = table.Column<decimal>(type: "TEXT", nullable: false),
                    QMarketedCapacity_Unit = table.Column<string>(type: "TEXT", nullable: true),
                    NUpgradeRequests = table.Column<int>(type: "INTEGER", nullable: false),
                    QTotalUpgradeRequests_Value = table.Column<decimal>(type: "TEXT", nullable: false),
                    QTotalUpgradeRequests_Unit = table.Column<string>(type: "TEXT", nullable: true),
                    NParticipantsShipperCompanies = table.Column<int>(type: "INTEGER", nullable: false),
                    NConcludedContracts = table.Column<int>(type: "INTEGER", nullable: false),
                    AuctionStartPriceExit_Value = table.Column<decimal>(type: "TEXT", nullable: false),
                    AuctionStartPriceExit_Unit = table.Column<string>(type: "TEXT", nullable: true),
                    AuctionStartPricEntry_Value = table.Column<decimal>(type: "TEXT", nullable: false),
                    AuctionStartPriceEntry_Unit = table.Column<string>(type: "TEXT", nullable: true),
                    RegulatedCapacityTariffExit_Value = table.Column<decimal>(type: "TEXT", nullable: false),
                    RegulatedCapacityTariffExit_Unit = table.Column<string>(type: "TEXT", nullable: true),
                    RegulatedCapacityTariffEntry_Value = table.Column<decimal>(type: "TEXT", nullable: false),
                    RegulatedCapacityTariffEntry_Unit = table.Column<string>(type: "TEXT", nullable: true),
                    MeasuringFeeExit_Value = table.Column<decimal>(type: "TEXT", nullable: false),
                    MeasuringFeeExit_Unit = table.Column<string>(type: "TEXT", nullable: true),
                    MeasuringFeeEntry_Value = table.Column<decimal>(type: "TEXT", nullable: false),
                    MeasuringFeeEntry_Unit = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prismaAuctionContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_prismaAuctionContracts_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_prismaAuctionContracts_FileId",
                table: "prismaAuctionContracts",
                column: "FileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "prismaAuctionContracts");
        }
    }
}
