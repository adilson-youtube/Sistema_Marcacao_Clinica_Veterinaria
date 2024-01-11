using Microsoft.EntityFrameworkCore;
using Sistema_Marcacao_Clinica_Veterinaria.Data;
using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly MarcacaoClinicaVeterinariaDBContext _dbContext;

        public UsuarioRepository(MarcacaoClinicaVeterinariaDBContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<List<Usuario>> ListarUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<Usuario> BuscarPorId(int Id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Usuario> Adicionar(Usuario Usuario)
        {
            await _dbContext.Usuarios.AddAsync(Usuario);
            _dbContext.SaveChangesAsync();
            return Usuario;
        }

        public async Task<Usuario> Actualizar(Usuario Usuario, int Id)
        {
            Usuario UsuarioPorId = await BuscarPorId(Id);
            if (UsuarioPorId == null)
            {
                throw new Exception($"Usuario com o id {Id} não foi encontrado na BD");
            }

            UsuarioPorId.NomeUsuario = Usuario.NomeUsuario;
            UsuarioPorId.Email = Usuario.Email;
            UsuarioPorId.Senha = Usuario.Senha;
            UsuarioPorId.DataCriacao = Usuario.DataCriacao;
            UsuarioPorId.UltimoAcesso = Usuario.UltimoAcesso;

            _dbContext.Usuarios.Update(UsuarioPorId);
            _dbContext.SaveChangesAsync();
            return UsuarioPorId;
        }

        public async Task<bool> Apagar(int Id)
        {
            Usuario UsuarioPorId = await BuscarPorId(Id);
            if (UsuarioPorId == null)
            {
                throw new Exception($"Usuario com o id {Id} não foi encontrado na BD");
            }

            _dbContext.Usuarios.Remove(UsuarioPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
