using Sistema_Marcacao_Clinica_Veterinaria.Models;

namespace Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces
{
    public interface IEspecieRepository
    {
        Task<List<Especie>> ListarEspecies();
        Task<Especie> Adicionar(Especie especie);
        Task<Especie> BuscarPorId(int id);
        Task<Especie> Actualizar(Especie especie, int id);
        Task<bool> Apagar(int id);

    }
}
