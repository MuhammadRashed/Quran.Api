using Microsoft.EntityFrameworkCore.Migrations;

namespace Quran.Data.Migrations
{
    public partial class AddIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PageIndex",
                table: "Pages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PartIndex",
                table: "Parts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PageIndex",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "PartIndex",
                table: "Parts");
        }
    }
}
