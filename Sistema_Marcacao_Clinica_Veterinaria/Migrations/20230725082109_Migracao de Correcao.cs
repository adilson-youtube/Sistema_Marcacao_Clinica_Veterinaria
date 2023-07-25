using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Marcacao_Clinica_Veterinaria.Migrations
{
    /// <inheritdoc />
    public partial class MigracaodeCorrecao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marcacoes_Animais_AnimalIDId",
                table: "Marcacoes");

            migrationBuilder.DropIndex(
                name: "IX_Marcacoes_AnimalIDId",
                table: "Marcacoes");

            migrationBuilder.DropColumn(
                name: "AnimalIDId",
                table: "Marcacoes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnimalIDId",
                table: "Marcacoes",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Marcacoes_AnimalIDId",
                table: "Marcacoes",
                column: "AnimalIDId");

            migrationBuilder.AddForeignKey(
                name: "FK_Marcacoes_Animais_AnimalIDId",
                table: "Marcacoes",
                column: "AnimalIDId",
                principalTable: "Animais",
                principalColumn: "Id");
        }
    }
}
