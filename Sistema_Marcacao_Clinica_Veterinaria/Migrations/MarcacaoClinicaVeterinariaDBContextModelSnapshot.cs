﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Sistema_Marcacao_Clinica_Veterinaria.Data;

#nullable disable

namespace Sistema_Marcacao_Clinica_Veterinaria.Migrations
{
    [DbContext(typeof(MarcacaoClinicaVeterinariaDBContext))]
    partial class MarcacaoClinicaVeterinariaDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.HasSequence("ServicoSequence");

            modelBuilder.Entity("Marcacao_Servico", b =>
                {
                    b.Property<int>("servicoId")
                        .HasColumnType("integer");

                    b.Property<int>("marcacaoId")
                        .HasColumnType("integer");

                    b.HasKey("servicoId", "marcacaoId");

                    b.HasIndex("marcacaoId");

                    b.ToTable("Marcacao_Servico");
                });

            modelBuilder.Entity("Sistema_Marcacao_Clinica_Veterinaria.Models.Animal", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<DateTime?>("dataNascimento")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("epecieId")
                        .HasColumnType("integer");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("proprietarioId")
                        .HasColumnType("integer");

                    b.Property<string>("sexo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("epecieId");

                    b.HasIndex("proprietarioId");

                    b.ToTable("Animais");
                });

            modelBuilder.Entity("Sistema_Marcacao_Clinica_Veterinaria.Models.Endereco", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("bairro")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("municipio")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("proprietarioId")
                        .HasColumnType("integer");

                    b.Property<string>("provincia")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("rua")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("proprietarioId")
                        .IsUnique();

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("Sistema_Marcacao_Clinica_Veterinaria.Models.Especie", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("raca")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Especies");
                });

            modelBuilder.Entity("Sistema_Marcacao_Clinica_Veterinaria.Models.Marcacao", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int>("animalId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ano")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("diaMes")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("diaSemana")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("veterinarioId")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("animalId");

                    b.HasIndex("veterinarioId");

                    b.ToTable("Marcacoes");
                });

            modelBuilder.Entity("Sistema_Marcacao_Clinica_Veterinaria.Models.Proprietario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<DateTime?>("dataNascimento")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("telefone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("usuarioId")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("usuarioId")
                        .IsUnique();

                    b.ToTable("Proprietarios");
                });

            modelBuilder.Entity("Sistema_Marcacao_Clinica_Veterinaria.Models.Servico", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValueSql("nextval('\"ServicoSequence\"')");

                    NpgsqlPropertyBuilderExtensions.UseSequence(b.Property<int>("id"));

                    b.Property<DateTime?>("data")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("preco")
                        .HasColumnType("double precision");

                    b.Property<int>("tipoPagamento")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("Sistema_Marcacao_Clinica_Veterinaria.Models.Usuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<DateTime?>("dataCriacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("role")
                        .HasColumnType("integer");

                    b.Property<string>("senha")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ultimoAcesso")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("usuario")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Sistema_Marcacao_Clinica_Veterinaria.Models.Veterinario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("especialidade")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("usuarioId")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("usuarioId")
                        .IsUnique();

                    b.ToTable("Veterinarios");
                });

            modelBuilder.Entity("Sistema_Marcacao_Clinica_Veterinaria.Models.Cirurgia", b =>
                {
                    b.HasBaseType("Sistema_Marcacao_Clinica_Veterinaria.Models.Servico");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("tipoCirurgia")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToTable("Cirurgias");
                });

            modelBuilder.Entity("Sistema_Marcacao_Clinica_Veterinaria.Models.Consulta", b =>
                {
                    b.HasBaseType("Sistema_Marcacao_Clinica_Veterinaria.Models.Servico");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("tipoConsulta")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToTable("Consultas");
                });

            modelBuilder.Entity("Sistema_Marcacao_Clinica_Veterinaria.Models.Exame", b =>
                {
                    b.HasBaseType("Sistema_Marcacao_Clinica_Veterinaria.Models.Servico");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("tipoExame")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToTable("Exames");
                });

            modelBuilder.Entity("Sistema_Marcacao_Clinica_Veterinaria.Models.Vacina", b =>
                {
                    b.HasBaseType("Sistema_Marcacao_Clinica_Veterinaria.Models.Servico");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("periodo")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<string>("tipoVacina")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToTable("Vacinas");
                });

            modelBuilder.Entity("Marcacao_Servico", b =>
                {
                    b.HasOne("Sistema_Marcacao_Clinica_Veterinaria.Models.Marcacao", null)
                        .WithMany()
                        .HasForeignKey("marcacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sistema_Marcacao_Clinica_Veterinaria.Models.Servico", null)
                        .WithMany()
                        .HasForeignKey("servicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sistema_Marcacao_Clinica_Veterinaria.Models.Animal", b =>
                {
                    b.HasOne("Sistema_Marcacao_Clinica_Veterinaria.Models.Especie", "especie")
                        .WithMany("animais")
                        .HasForeignKey("epecieId");

                    b.HasOne("Sistema_Marcacao_Clinica_Veterinaria.Models.Proprietario", "proprietario")
                        .WithMany("animais")
                        .HasForeignKey("proprietarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("especie");

                    b.Navigation("proprietario");
                });

            modelBuilder.Entity("Sistema_Marcacao_Clinica_Veterinaria.Models.Endereco", b =>
                {
                    b.HasOne("Sistema_Marcacao_Clinica_Veterinaria.Models.Proprietario", "proprietario")
                        .WithOne("endereco")
                        .HasForeignKey("Sistema_Marcacao_Clinica_Veterinaria.Models.Endereco", "proprietarioId");

                    b.Navigation("proprietario");
                });

            modelBuilder.Entity("Sistema_Marcacao_Clinica_Veterinaria.Models.Marcacao", b =>
                {
                    b.HasOne("Sistema_Marcacao_Clinica_Veterinaria.Models.Animal", "animal")
                        .WithMany("marcacoes")
                        .HasForeignKey("animalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sistema_Marcacao_Clinica_Veterinaria.Models.Veterinario", "veterinario")
                        .WithMany("marcacoes")
                        .HasForeignKey("veterinarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("animal");

                    b.Navigation("veterinario");
                });

            modelBuilder.Entity("Sistema_Marcacao_Clinica_Veterinaria.Models.Proprietario", b =>
                {
                    b.HasOne("Sistema_Marcacao_Clinica_Veterinaria.Models.Usuario", "usuario")
                        .WithOne("proprietario")
                        .HasForeignKey("Sistema_Marcacao_Clinica_Veterinaria.Models.Proprietario", "usuarioId");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("Sistema_Marcacao_Clinica_Veterinaria.Models.Veterinario", b =>
                {
                    b.HasOne("Sistema_Marcacao_Clinica_Veterinaria.Models.Usuario", "usuario")
                        .WithOne("veterinario")
                        .HasForeignKey("Sistema_Marcacao_Clinica_Veterinaria.Models.Veterinario", "usuarioId");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("Sistema_Marcacao_Clinica_Veterinaria.Models.Animal", b =>
                {
                    b.Navigation("marcacoes");
                });

            modelBuilder.Entity("Sistema_Marcacao_Clinica_Veterinaria.Models.Especie", b =>
                {
                    b.Navigation("animais");
                });

            modelBuilder.Entity("Sistema_Marcacao_Clinica_Veterinaria.Models.Proprietario", b =>
                {
                    b.Navigation("animais");

                    b.Navigation("endereco");
                });

            modelBuilder.Entity("Sistema_Marcacao_Clinica_Veterinaria.Models.Usuario", b =>
                {
                    b.Navigation("proprietario");

                    b.Navigation("veterinario");
                });

            modelBuilder.Entity("Sistema_Marcacao_Clinica_Veterinaria.Models.Veterinario", b =>
                {
                    b.Navigation("marcacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
