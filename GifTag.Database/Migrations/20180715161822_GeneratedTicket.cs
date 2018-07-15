using Microsoft.EntityFrameworkCore.Migrations;

namespace GifTag.Database.Migrations
{
    public partial class GeneratedTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GeneratedTicket",
                table: "Tickets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GeneratedTicket",
                table: "Tickets");
        }
    }
}
