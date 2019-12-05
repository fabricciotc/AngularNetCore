using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularDemo.Migrations
{
    public partial class Direcciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Direccione",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Calle = table.Column<string>(nullable: true),
                    Provincia = table.Column<string>(nullable: true),
                    PersonaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direccione", x => x.id);
                    table.ForeignKey(
                        name: "FK_Direccione_Personas_PersonaID",
                        column: x => x.PersonaID,
                        principalTable: "Personas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Direccione_PersonaID",
                table: "Direccione",
                column: "PersonaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Direccione");
        }
    }
}
