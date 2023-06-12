using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema_Marcacao_Clinica_Veterinaria.Models;

namespace Sistema_Marcacao_Clinica_Veterinaria.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(p => p.id);
            builder.Property(p => p.usuario).IsRequired();
            builder.Property(p => p.senha).IsRequired();
            builder.Property(p => p.role).IsRequired();
            builder.Property(p => p.dataCriacao).IsRequired();
            builder.Property(p => p.ultimoAcesso).IsRequired();
        }
    }
}
