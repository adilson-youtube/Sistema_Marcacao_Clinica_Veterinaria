using Sistema_Marcacao_Clinica_Veterinaria.Models;

namespace Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> ListarUsuarios();
        Task<Usuario> Adicionar(Usuario usuario);
        Task<Usuario> BuscarPorId(int id);
        Task<Usuario> Actualizar(Usuario usuario, int id);
        Task<bool> Apagar(int id);

    }
}
