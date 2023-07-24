using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sistema_Marcacao_Clinica_Veterinaria.Models;

namespace Sistema_Marcacao_Clinica_Veterinaria.Data.Map
{
    public class VeterinarioMap : IEntityTypeConfiguration<Veterinario>
    {
        public void Configure(EntityTypeBuilder<Veterinario> builder)
        {
            //builder.HasKey(p => p.id);
            builder.Property(p => p.Nome);
            builder.Property(p => p.Especialidade);
            builder.HasMany(p => p.Marcacoes).WithOne(p => p.Veterinario).HasForeignKey("VeterinarioId");
        }
    }
}
