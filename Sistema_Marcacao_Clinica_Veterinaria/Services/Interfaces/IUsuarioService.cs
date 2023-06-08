using Sistema_Marcacao_Clinica_Veterinaria.Models;

namespace Sistema_Marcacao_Clinica_Veterinaria.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<List<Usuario>> ListarAnimais();
        Task<Usuario> Adicionar(Usuario usuario);
        Task<Usuario> BuscarPorId(int id);
        Task<Usuario> Actualizar(Usuario usuario, int id);
        Task<bool> Apagar(int id);
    }
}
