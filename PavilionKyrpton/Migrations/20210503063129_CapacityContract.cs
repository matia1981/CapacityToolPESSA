using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PavilionKyrpton.Migrations
{
    public partial class CapacityContract : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CapacityContracts",
                columns: table => new
                {
                    CapacityContractId = table.Column<string>(type: "TEXT", nullable: false),
                    Network = table.Column<string>(type: "TEXT", nullable: true),
                    InfrastructureType = table.Column<string>(type: "TEXT", nullable: true),
                    Infrastructure = table.Column<string>(type: "TEXT", nullable: true),
                    ServiceType = table.Column<string>(type: "TEXT", nullable: true),
                    BegTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Quantity = table.Column<decimal>(type: "TEXT", nullable: false),
                    Buy_Sell = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<string>(type: "TEXT", nullable: true),
                    TradeDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    QuantityUnit = table.Column<string>(type: "TEXT", nullable: true),
                    PriceUnit = table.Column<string>(type: "TEXT", nullable: true),
                    Currency = table.Column<string>(type: "TEXT", nullable: true),
                    TimeZone = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapacityContracts", x => x.CapacityContractId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CapacityContracts");
        }
    }
}
