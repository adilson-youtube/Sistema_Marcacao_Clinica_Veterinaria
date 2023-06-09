﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema_Marcacao_Clinica_Veterinaria.Models;

namespace Sistema_Marcacao_Clinica_Veterinaria.Data.Map
{
    public class ProprietarioMap : IEntityTypeConfiguration<Proprietario>
    {
        public void Configure(EntityTypeBuilder<Proprietario> builder)
        {
            builder.HasKey(p => p.id);
            builder.Property(p => p.nome).IsRequired();
            builder.Property(p => p.telefone).IsRequired();
            builder.Property(p => p.dataNascimento).IsRequired();
            builder.HasOne(p => p.endereco).WithOne(p => p.proprietario).HasForeignKey<Endereco>();
            builder.HasMany(p => p.animais).WithOne(p => p.proprietario).HasForeignKey("proprietarioId");
        }
    }
}