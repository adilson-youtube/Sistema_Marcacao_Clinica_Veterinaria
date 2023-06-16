using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces;
using Sistema_Marcacao_Clinica_Veterinaria.Services.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<List<Usuario>> ListarUsuarios()
        {
            return await _usuarioRepository.ListarUsuarios();
        }


        public async Task<Usuario> BuscarPorId(int id)
        {
            return await _usuarioRepository.BuscarPorId(id);
        }

        public async Task<Usuario> Adicionar(Usuario usuario)
        {
            return await _usuarioRepository.Adicionar(usuario);
        }

        public async Task<Usuario> Actualizar(Usuario usuario, int id)
        {
            return await _usuarioRepository.Actualizar(usuario, id);
        }
        public async Task<bool> Apagar(int id)
        {
            return await _usuarioRepository.Apagar(id);
        }
    }
}
