using Microsoft.EntityFrameworkCore.Migrations;

namespace ProiectMDS.Migrations
{
    public partial class Migratie2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "numberOfPersons",
                table: "Reservations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "apartmentName",
                table: "Apartments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "numberOfPersons",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "apartmentName",
                table: "Apartments");
        }
    }
}
