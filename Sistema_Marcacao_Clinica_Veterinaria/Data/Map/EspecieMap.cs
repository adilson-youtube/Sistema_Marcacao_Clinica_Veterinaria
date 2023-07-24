using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sistema_Marcacao_Clinica_Veterinaria.Models;

namespace Sistema_Marcacao_Clinica_Veterinaria.Data.Map
{
    public class EspecieMap : IEntityTypeConfiguration<Especie>
    {
        public void Configure(EntityTypeBuilder<Especie> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Raca);
            builder.HasMany(p => p.Animais).WithOne(p => p.Especie).HasForeignKey("EpecieId");
        }
    }
}
