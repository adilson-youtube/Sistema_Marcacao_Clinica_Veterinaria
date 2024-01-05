using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema_Marcacao_Clinica_Veterinaria.Models;

namespace Sistema_Marcacao_Clinica_Veterinaria.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.NomeUsuario);
            builder.Property(p => p.Senha);
            builder.Property(p => p.Role);
            builder.Property(p => p.DataCriacao);
            builder.Property(p => p.UltimoAcesso);
            builder.HasOne(p => p.Proprietario).WithOne(p => p.Usuario).HasForeignKey<Proprietario>(e => e.UsuarioId);
            //builder.HasOne(p => p.proprietario).WithOne().HasForeignKey<Proprietario>(e => e.usuarioId);
            builder.HasOne(p => p.Veterinario).WithOne(p => p.Usuario).HasForeignKey<Veterinario>(e => e.UsuarioId);
        }
    }
}
