using Microsoft.EntityFrameworkCore.Migrations;

namespace PavilionKyrpton.Migrations
{
    public partial class Infrastructura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Infrastructura",
                table: "EnagasFiles",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Infrastructura",
                table: "EnagasFiles");
        }
    }
}
