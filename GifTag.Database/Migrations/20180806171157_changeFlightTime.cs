using Microsoft.EntityFrameworkCore.Migrations;

namespace GifTag.Database.Migrations
{
    public partial class changeFlightTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BoardingTime",
                table: "Tickets",
                newName: "FlightTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FlightTime",
                table: "Tickets",
                newName: "BoardingTime");
        }
    }
}
