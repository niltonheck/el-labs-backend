using Microsoft.EntityFrameworkCore.Migrations;

namespace CWebService.Infrastructure.Migrations
{
    public partial class AddNumberOfHoursRental : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfHours",
                table: "Bookings",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfHours",
                table: "Bookings");

            migrationBuilder.AddColumn<double>(
                name: "TotalAmount",
                table: "Bookings",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
