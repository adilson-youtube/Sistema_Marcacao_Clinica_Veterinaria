using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sistema_Marcacao_Clinica_Veterinaria.Models;

namespace Sistema_Marcacao_Clinica_Veterinaria.Data.Map
{
    public class AnimalMap : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.HasKey(p => p.id);
            builder.Property(p => p.nome);
            builder.Property(p => p.sexo);
            builder.Property(p => p.dataNascimento);
            builder.HasOne(p => p.proprietario).WithMany(p => p.animais).HasForeignKey("proprietarioId");
            builder.HasOne(p => p.especie).WithMany(p => p.animais).HasForeignKey("epecieId");
            builder.HasMany(p => p.marcacoes).WithOne(p => p.animal).HasForeignKey("animalId");
        }
    }
}
