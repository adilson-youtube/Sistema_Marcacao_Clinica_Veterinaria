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
            builder.Property(p => p.nome);
            builder.Property(p => p.especialidade);
            builder.HasMany(p => p.marcacoes).WithOne(p => p.veterinario).HasForeignKey("veterinarioId");
        }
    }
}
