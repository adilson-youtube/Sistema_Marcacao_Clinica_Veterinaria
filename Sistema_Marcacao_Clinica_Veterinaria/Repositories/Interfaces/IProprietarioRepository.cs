using Sistema_Marcacao_Clinica_Veterinaria.Models;

namespace Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces
{
    public interface IProprietarioRepository
    {
        Task<List<Proprietario>> ListarProprietarios();
        Task<Proprietario> Adicionar(Proprietario proprietario);
        Task<Proprietario> BuscarPorId(int id);
        Task<Proprietario> Actualizar(Proprietario proprietario, int id);
        Task<bool> Apagar(int id);

    }
}
