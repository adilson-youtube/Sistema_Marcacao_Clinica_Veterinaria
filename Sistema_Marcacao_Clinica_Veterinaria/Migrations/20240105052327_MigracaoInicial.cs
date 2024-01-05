using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Sistema_Marcacao_Clinica_Veterinaria.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marcacoes_Animais_AnimalId",
                table: "Marcacoes");

            migrationBuilder.DropIndex(
                name: "IX_Marcacoes_AnimalId",
                table: "Marcacoes");

            migrationBuilder.AddColumn<int>(
                name: "AnimalID",
                table: "Marcacoes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VeterinarioID",
                table: "Marcacoes",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MarcacoesServicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MarcacaoId = table.Column<int>(type: "integer", nullable: false),
                    ServicoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcacoesServicos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Marcacoes_AnimalID",
                table: "Marcacoes",
                column: "AnimalID");

            migrationBuilder.AddForeignKey(
                name: "FK_Marcacoes_Animais_AnimalID",
                table: "Marcacoes",
                column: "AnimalID",
                principalTable: "Animais",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marcacoes_Animais_AnimalID",
                table: "Marcacoes");

            migrationBuilder.DropTable(
                name: "MarcacoesServicos");

            migrationBuilder.DropIndex(
                name: "IX_Marcacoes_AnimalID",
                table: "Marcacoes");

            migrationBuilder.DropColumn(
                name: "AnimalID",
                table: "Marcacoes");

            migrationBuilder.DropColumn(
                name: "VeterinarioID",
                table: "Marcacoes");

            migrationBuilder.CreateIndex(
                name: "IX_Marcacoes_AnimalId",
                table: "Marcacoes",
                column: "AnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Marcacoes_Animais_AnimalId",
                table: "Marcacoes",
                column: "AnimalId",
                principalTable: "Animais",
                principalColumn: "Id");
        }
    }
}
