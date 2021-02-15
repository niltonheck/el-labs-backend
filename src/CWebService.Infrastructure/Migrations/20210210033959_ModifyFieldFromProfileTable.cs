using Microsoft.EntityFrameworkCore.Migrations;

namespace CWebService.Infrastructure.Migrations
{
    public partial class ModifyFieldFromProfileTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReportDate",
                table: "UserProfiles",
                newName: "Birthday");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Birthday",
                table: "UserProfiles",
                newName: "ReportDate");
        }
    }
}
