﻿using System;
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
            migrationBuilder.CreateTable(
                name: "Especies",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    raca = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    data = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    preco = table.Column<double>(type: "double precision", nullable: true),
                    tipoServico = table.Column<string>(type: "text", nullable: true),
                    tipoPagamento = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    usuario = table.Column<string>(type: "text", nullable: true),
                    senha = table.Column<string>(type: "text", nullable: true),
                    role = table.Column<int>(type: "integer", nullable: true),
                    dataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ultimoAcesso = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Cirurgias",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    descricao = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cirurgias", x => x.id);
                    table.ForeignKey(
                        name: "FK_Cirurgias_Servicos_id",
                        column: x => x.id,
                        principalTable: "Servicos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    descricao = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Consultas_Servicos_id",
                        column: x => x.id,
                        principalTable: "Servicos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exames",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    descricao = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exames", x => x.id);
                    table.ForeignKey(
                        name: "FK_Exames_Servicos_id",
                        column: x => x.id,
                        principalTable: "Servicos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vacinas",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    nome = table.Column<string>(type: "text", nullable: true),
                    periodo = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacinas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Vacinas_Servicos_id",
                        column: x => x.id,
                        principalTable: "Servicos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proprietarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: true),
                    telefone = table.Column<string>(type: "text", nullable: true),
                    genero = table.Column<string>(type: "text", nullable: true),
                    dataNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    usuarioId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proprietarios", x => x.id);
                    table.ForeignKey(
                        name: "FK_Proprietarios_Usuarios_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Veterinarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: true),
                    genero = table.Column<string>(type: "text", nullable: true),
                    especialidade = table.Column<string>(type: "text", nullable: true),
                    usuarioId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veterinarios", x => x.id);
                    table.ForeignKey(
                        name: "FK_Veterinarios_Usuarios_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Animais",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: true),
                    sexo = table.Column<string>(type: "text", nullable: true),
                    peso = table.Column<double>(type: "double precision", nullable: true),
                    dataNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    epecieId = table.Column<int>(type: "integer", nullable: true),
                    proprietarioId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animais", x => x.id);
                    table.ForeignKey(
                        name: "FK_Animais_Especies_epecieId",
                        column: x => x.epecieId,
                        principalTable: "Especies",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Animais_Proprietarios_proprietarioId",
                        column: x => x.proprietarioId,
                        principalTable: "Proprietarios",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rua = table.Column<string>(type: "text", nullable: true),
                    bairro = table.Column<string>(type: "text", nullable: true),
                    municipio = table.Column<string>(type: "text", nullable: true),
                    proprietarioId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Proprietarios_proprietarioId",
                        column: x => x.proprietarioId,
                        principalTable: "Proprietarios",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Marcacoes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    diaSemana = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    diaMes = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ano = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    animalId = table.Column<int>(type: "integer", nullable: true),
                    veterinarioId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcacoes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Marcacoes_Animais_animalId",
                        column: x => x.animalId,
                        principalTable: "Animais",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Marcacoes_Veterinarios_veterinarioId",
                        column: x => x.veterinarioId,
                        principalTable: "Veterinarios",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Marcacao_Servico",
                columns: table => new
                {
                    servicoId = table.Column<int>(type: "integer", nullable: false),
                    marcacaoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcacao_Servico", x => new { x.servicoId, x.marcacaoId });
                    table.ForeignKey(
                        name: "FK_Marcacao_Servico_Marcacoes_marcacaoId",
                        column: x => x.marcacaoId,
                        principalTable: "Marcacoes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Marcacao_Servico_Servicos_servicoId",
                        column: x => x.servicoId,
                        principalTable: "Servicos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animais_epecieId",
                table: "Animais",
                column: "epecieId");

            migrationBuilder.CreateIndex(
                name: "IX_Animais_proprietarioId",
                table: "Animais",
                column: "proprietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_proprietarioId",
                table: "Enderecos",
                column: "proprietarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Marcacao_Servico_marcacaoId",
                table: "Marcacao_Servico",
                column: "marcacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Marcacoes_animalId",
                table: "Marcacoes",
                column: "animalId");

            migrationBuilder.CreateIndex(
                name: "IX_Marcacoes_veterinarioId",
                table: "Marcacoes",
                column: "veterinarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Proprietarios_usuarioId",
                table: "Proprietarios",
                column: "usuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Veterinarios_usuarioId",
                table: "Veterinarios",
                column: "usuarioId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cirurgias");

            migrationBuilder.DropTable(
                name: "Consultas");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Exames");

            migrationBuilder.DropTable(
                name: "Marcacao_Servico");

            migrationBuilder.DropTable(
                name: "Vacinas");

            migrationBuilder.DropTable(
                name: "Marcacoes");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Animais");

            migrationBuilder.DropTable(
                name: "Veterinarios");

            migrationBuilder.DropTable(
                name: "Especies");

            migrationBuilder.DropTable(
                name: "Proprietarios");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
