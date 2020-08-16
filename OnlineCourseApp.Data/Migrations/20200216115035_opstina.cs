using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineCourseApp.Data.Migrations
{
    public partial class opstina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Opstina",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opis = table.Column<string>(maxLength: 50, nullable: false),
                    RegijaID = table.Column<int>(nullable: false),
                    PostanskiBroj = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opstina", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Opstina_Regija_RegijaID",
                        column: x => x.RegijaID,
                        principalTable: "Regija",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Opstina_RegijaID",
                table: "Opstina",
                column: "RegijaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Opstina");
        }
    }
}
