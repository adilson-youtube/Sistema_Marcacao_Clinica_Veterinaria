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
            dbContext = _dbContext;
        }

        public async Task<List<Usuario>> ListarUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<Usuario> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<Usuario> Adicionar(Usuario usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            _dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> Actualizar(Usuario usuario, int id)
        {
            Usuario usuarioPorId = await BuscarPorId(id);
            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario com o id {id} não foi encontrado na BD");
            }

            usuarioPorId.usuario = usuarioPorId.usuario;
            usuarioPorId.senha = usuarioPorId.senha;
            usuarioPorId.dataCriacao = usuarioPorId.dataCriacao;
            usuarioPorId.ultimoAcesso = usuarioPorId.ultimoAcesso;

            _dbContext.Usuarios.Update(usuarioPorId);
            _dbContext.SaveChangesAsync();
            return usuarioPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            Usuario usuarioPorId = await BuscarPorId(id);
            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario com o id {id} não foi encontrado na BD");
            }

            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
