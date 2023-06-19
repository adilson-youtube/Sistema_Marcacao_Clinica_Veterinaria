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
            builder.Property(p => p.usuario);
            builder.Property(p => p.senha);
            builder.Property(p => p.role);
            builder.Property(p => p.dataCriacao);
            builder.Property(p => p.ultimoAcesso);
            builder.HasOne(p => p.proprietario).WithOne(p => p.usuario).HasForeignKey<Proprietario>(e => e.usuarioId);
            builder.HasOne(p => p.veterinario).WithOne(p => p.usuario).HasForeignKey<Veterinario>(e => e.usuarioId);
        }
    }
}
