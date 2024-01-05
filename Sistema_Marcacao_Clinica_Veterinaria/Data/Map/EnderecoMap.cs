using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema_Marcacao_Clinica_Veterinaria.Models;

namespace Sistema_Marcacao_Clinica_Veterinaria.Data.Map
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Rua);
            builder.Property(p => p.Bairro);
            builder.Property(p => p.Municipio);
            //builder.Property(p => p.provincia);
            //builder.Property(p => p.proprietario).IsRequired();
            //builder.HasOne(p => p.proprietario).WithOne(p => p.endereco).HasForeignKey("proprietarioId");
        }
    }
}
