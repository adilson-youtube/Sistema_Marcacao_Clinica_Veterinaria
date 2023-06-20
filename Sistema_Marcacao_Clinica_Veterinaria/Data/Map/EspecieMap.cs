using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sistema_Marcacao_Clinica_Veterinaria.Models;

namespace Sistema_Marcacao_Clinica_Veterinaria.Data.Map
{
    public class EspecieMap : IEntityTypeConfiguration<Especie>
    {
        public void Configure(EntityTypeBuilder<Especie> builder)
        {
            builder.HasKey(p => p.id);
            builder.Property(p => p.raca);
            builder.HasMany(p => p.animais).WithOne(p => p.especie).HasForeignKey("epecieId");
        }
    }
}
