using Microsoft.EntityFrameworkCore.Migrations;

namespace PavilionKyrpton.Migrations
{
    public partial class locationservices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Service",
                table: "Locations",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Service",
                table: "Locations");
        }
    }
}
