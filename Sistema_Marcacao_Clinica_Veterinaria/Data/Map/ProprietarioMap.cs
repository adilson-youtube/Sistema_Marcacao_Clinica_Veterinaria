using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema_Marcacao_Clinica_Veterinaria.Models;

namespace Sistema_Marcacao_Clinica_Veterinaria.Data.Map
{
    public class ProprietarioMap : IEntityTypeConfiguration<Proprietario>
    {
        public void Configure(EntityTypeBuilder<Proprietario> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome);
            builder.Property(p => p.Telefone);
            builder.Property(p => p.DataNascimento);
            builder.HasOne(p => p.Endereco).WithOne(p => p.Proprietario).HasForeignKey<Endereco>(e => e.ProprietarioId);
            //builder.HasOne(p => p.endereco).WithOne().HasForeignKey<Endereco>(e => e.proprietarioId);
            builder.HasMany(p => p.Animais).WithOne(p => p.Proprietario).HasForeignKey("ProprietarioId");
        }
    }
}
