using Microsoft.EntityFrameworkCore.Migrations;

namespace CWebService.Infrastructure.Migrations
{
    public partial class RemoveFieldFromProfileTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserProfiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "UserProfiles",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
