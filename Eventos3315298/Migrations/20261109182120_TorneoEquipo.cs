using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eventos3315298.Migrations
{
    /// <inheritdoc />
    public partial class TorneoEquipo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TorneoEquipo",
                columns: table => new
                {
                    EquiposEquipoId = table.Column<int>(type: "int", nullable: false),
                    TorneosTorneoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TorneoEquipo", x => new { x.EquiposEquipoId, x.TorneosTorneoId });
                    table.ForeignKey(
                        name: "FK_TorneoEquipo_Equipos_EquiposEquipoId",
                        column: x => x.EquiposEquipoId,
                        principalTable: "Equipos",
                        principalColumn: "EquipoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TorneoEquipo_Torneos_TorneosTorneoId",
                        column: x => x.TorneosTorneoId,
                        principalTable: "Torneos",
                        principalColumn: "TorneoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TorneoEquipo_TorneosTorneoId",
                table: "TorneoEquipo",
                column: "TorneosTorneoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TorneoEquipo");
        }
    }
}
