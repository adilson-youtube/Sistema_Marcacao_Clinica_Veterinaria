using Sistema_Marcacao_Clinica_Veterinaria.Models;

namespace Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces
{
    public interface ICirurgiaRepository
    {
        Task<List<Cirurgia>> ListarCirurgias();
        Task<Cirurgia> Adicionar(Cirurgia cirurgia);
        Task<Cirurgia> BuscarPorId(int id);
        Task<Cirurgia> Actualizar(Cirurgia cirurgia, int id);
        Task<bool> Apagar(int id);

    }
}
