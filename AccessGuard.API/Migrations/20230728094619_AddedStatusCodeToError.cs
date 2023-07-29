using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessGuard_API.Migrations
{
    public partial class AddedStatusCodeToError : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HttpStatusCode",
                table: "Errors",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HttpStatusCode",
                table: "Errors");
        }
    }
}
