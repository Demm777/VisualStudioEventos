using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eventos3315298.Migrations
{
    /// <inheritdoc />
    public partial class actualizaIndex1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Torneos_Municipios_MunicipioId",
                table: "Torneos");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Torneos",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Categoria",
                table: "Torneos",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Torneos_Nombre",
                table: "Torneos",
                column: "Nombre",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Torneos_Municipios_MunicipioId",
                table: "Torneos",
                column: "MunicipioId",
                principalTable: "Municipios",
                principalColumn: "MunicipioId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Torneos_Municipios_MunicipioId",
                table: "Torneos");

            migrationBuilder.DropIndex(
                name: "IX_Torneos_Nombre",
                table: "Torneos");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Torneos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Categoria",
                table: "Torneos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddForeignKey(
                name: "FK_Torneos_Municipios_MunicipioId",
                table: "Torneos",
                column: "MunicipioId",
                principalTable: "Municipios",
                principalColumn: "MunicipioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
