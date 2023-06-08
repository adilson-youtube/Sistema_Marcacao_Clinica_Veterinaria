using Sistema_Marcacao_Clinica_Veterinaria.Models;

namespace Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces
{
    public interface IExameRepository
    {
        Task<List<Exame>> ListarExames();
        Task<Exame> Adicionar(Exame exame);
        Task<Exame> BuscarPorId(int id);
        Task<Exame> Actualizar(Exame exame, int id);
        Task<bool> Apagar(int id);

    }
}
