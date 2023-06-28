using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sistema_Marcacao_Clinica_Veterinaria.Models;

namespace Sistema_Marcacao_Clinica_Veterinaria.Data.Map
{
    public class CirurgiaMap : IEntityTypeConfiguration<Cirurgia>
    {
        public void Configure(EntityTypeBuilder<Cirurgia> builder)
        {
            //builder.HasKey(p => p.id);
            //builder.Property(p => p.tipoCirurgia);
            builder.Property(p => p.descricao);
        }
    }
}
