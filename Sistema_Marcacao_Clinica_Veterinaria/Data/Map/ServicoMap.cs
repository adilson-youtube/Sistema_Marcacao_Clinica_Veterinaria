using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sistema_Marcacao_Clinica_Veterinaria.Models;

namespace Sistema_Marcacao_Clinica_Veterinaria.Data.Map
{
    public class ServicoMap : IEntityTypeConfiguration<Servico>
    {
        public void Configure(EntityTypeBuilder<Servico> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Data);
            builder.Property(p => p.Preco);
            builder.Property(p => p.TipoPagamento);


            builder.HasMany(r => r.MarcacoesServicos).WithOne(c => c.Servico).HasForeignKey(fk => fk.ServicoId);


            //builder.HasMany(p => p.marcacoes).WithMany(p => p.servicos).UsingEntity(
            //    "Marcacao_Servico",
            //    l => l.HasOne(typeof(Marcacao)).WithMany().HasForeignKey("marcacaoId").HasPrincipalKey(nameof(Marcacao.id)),
            //    r => r.HasOne(typeof(Servico)).WithMany().HasForeignKey("servicoId").HasPrincipalKey(nameof(Servico.id)),
            //    j => j.HasKey("servicoId", "marcacaoId"));
        }
    }
}
