using Microsoft.EntityFrameworkCore.Migrations;

namespace Quran.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Juzs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Juzs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Surahs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurahIndex = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    TitleAr = table.Column<string>(nullable: true),
                    Pages = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surahs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JuzId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pages_Juzs_JuzId",
                        column: x => x.JuzId,
                        principalTable: "Juzs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ayas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AyaIndex = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    SurahId = table.Column<int>(nullable: false),
                    JuzId = table.Column<int>(nullable: true),
                    PageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ayas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ayas_Juzs_JuzId",
                        column: x => x.JuzId,
                        principalTable: "Juzs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ayas_Pages_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ayas_Surahs_SurahId",
                        column: x => x.SurahId,
                        principalTable: "Surahs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ayas_JuzId",
                table: "Ayas",
                column: "JuzId");

            migrationBuilder.CreateIndex(
                name: "IX_Ayas_PageId",
                table: "Ayas",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_Ayas_SurahId",
                table: "Ayas",
                column: "SurahId");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_JuzId",
                table: "Pages",
                column: "JuzId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ayas");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "Surahs");

            migrationBuilder.DropTable(
                name: "Juzs");
        }
    }
}
