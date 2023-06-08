using Sistema_Marcacao_Clinica_Veterinaria.Models;

namespace Sistema_Marcacao_Clinica_Veterinaria.Services.Interfaces
{
    public interface IVacinaService
    {
        Task<List<Vacina>> ListarVacinas();
        Task<Vacina> Adicionar(Vacina vacina);
        Task<Vacina> BuscarPorId(int id);
        Task<Vacina> Actualizar(Vacina vacina, int id);
        Task<bool> Apagar(int id);
    }
}
