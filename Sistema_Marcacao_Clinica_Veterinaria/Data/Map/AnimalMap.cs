using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sistema_Marcacao_Clinica_Veterinaria.Models;

namespace Sistema_Marcacao_Clinica_Veterinaria.Data.Map
{
    public class AnimalMap : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome);
            builder.Property(p => p.Sexo);
            builder.Property(p => p.DataNascimento);
            builder.HasOne(p => p.Proprietario).WithMany(p => p.Animais).HasForeignKey("ProprietarioId");
            builder.HasOne(p => p.Especie).WithMany(p => p.Animais).HasForeignKey("EpecieId");
            builder.HasMany(p => p.Marcacoes).WithOne(p => p.Animal).HasForeignKey("AnimalId");
        }
    }
}
