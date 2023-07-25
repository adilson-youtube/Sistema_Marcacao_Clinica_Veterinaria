using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sistema_Marcacao_Clinica_Veterinaria.Models;

namespace Sistema_Marcacao_Clinica_Veterinaria.Data.Map
{
    public class MarcacaoMap : IEntityTypeConfiguration<Marcacao>
    {
        public void Configure(EntityTypeBuilder<Marcacao> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.DiaSemana);
            builder.Property(p => p.DiaMes);
            builder.Property(p => p.Ano);
            //builder.HasOne(p => p.Animal).WithMany(p => p.Marcacoes).HasForeignKey("AnimalId");
            builder.HasOne(p => p.Animal).WithMany(p => p.Marcacoes).HasForeignKey(m => m.AnimalID);
            //builder.HasOne(p => p.Veterinario).WithMany(p => p.Marcacoes).HasForeignKey("VeterinarioId");
            builder.HasOne(p => p.Veterinario).WithMany(p => p.Marcacoes).HasForeignKey(m => m.VeterinarioID);
            //builder.Ignore(p => p.);
            builder.HasMany(p => p.Servicos).WithMany(p => p.Marcacoes).UsingEntity(
                "Marcacao_Servico",
                //k => k.Property(),
                l => l.HasOne(typeof(Servico)).WithMany().HasForeignKey("ServicoId").HasPrincipalKey(nameof(Servico.Id)),
                r => r.HasOne(typeof(Marcacao)).WithMany().HasForeignKey("MarcacaoId").HasPrincipalKey(nameof(Marcacao.Id)),
                j => j.HasKey("ServicoId", "MarcacaoId"));
        }
    }
}
