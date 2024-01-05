using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sistema_Marcacao_Clinica_Veterinaria.Models;

namespace Sistema_Marcacao_Clinica_Veterinaria.Data.Map
{
    public class VacinaMap : IEntityTypeConfiguration<Vacina>
    {
        public void Configure(EntityTypeBuilder<Vacina> builder)
        {
            //builder.HasKey(p => p.id);
            builder.Property(p => p.Nome);
            builder.Property(p => p.Periodo);
            //builder.Property(p => p.tipoVacina);
        }
    }
}
