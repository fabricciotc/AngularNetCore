using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularDemo.Migrations
{
    public partial class Names : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fullname",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastNames",
                table: "AspNetUsers",
                maxLength: 40,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastNames",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Fullname",
                table: "AspNetUsers",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");
        }
    }
}
