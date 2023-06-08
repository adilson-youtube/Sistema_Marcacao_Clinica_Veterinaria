using Sistema_Marcacao_Clinica_Veterinaria.Models;

namespace Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces
{
    public interface IVacinaRepository
    {
        Task<List<Vacina>> ListarVacinas();
        Task<Vacina> Adicionar(Vacina vacina);
        Task<Vacina> BuscarPorId(int id);
        Task<Vacina> Actualizar(Vacina vacina, int id);
        Task<bool> Apagar(int id);

    }
}
