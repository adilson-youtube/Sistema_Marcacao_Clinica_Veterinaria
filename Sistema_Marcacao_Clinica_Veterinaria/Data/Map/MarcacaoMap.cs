using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sistema_Marcacao_Clinica_Veterinaria.Models;

namespace Sistema_Marcacao_Clinica_Veterinaria.Data.Map
{
    public class MarcacaoMap : IEntityTypeConfiguration<Marcacao>
    {
        public void Configure(EntityTypeBuilder<Marcacao> builder)
        {
            builder.HasKey(p => p.id);
            builder.Property(p => p.diaSemana).IsRequired();
            builder.Property(p => p.diaMes).IsRequired();
            builder.Property(p => p.ano).IsRequired();
            builder.HasOne(p => p.animal).WithMany(p => p.marcacoes).HasForeignKey("animalId");
            builder.HasOne(p => p.veterinario).WithMany(p => p.marcacoes).HasForeignKey("veterinarioId");
            builder.HasMany(p => p.servicos).WithMany(p => p.marcacoes).UsingEntity(
                "Marcacao_Servico",
                //k => k.Property(),
                l => l.HasOne(typeof(Servico)).WithMany().HasForeignKey("servicoId").HasPrincipalKey(nameof(Servico.id)),
                r => r.HasOne(typeof(Marcacao)).WithMany().HasForeignKey("marcacaoId").HasPrincipalKey(nameof(Marcacao.id)),
                j => j.HasKey("servicoId", "marcacaoId"));
        }
    }
}
