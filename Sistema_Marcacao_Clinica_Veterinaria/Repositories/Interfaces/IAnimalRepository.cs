using Sistema_Marcacao_Clinica_Veterinaria.Models;

namespace Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces
{
    public interface IAnimalRepository
    {
        Task<List<Animal>> ListarAnimais();
        Task<Animal> Adicionar(Animal animal);
        Task<Animal> BuscarPorId(int id);
        Task<Animal> Actualizar(Animal animal, int id);
        Task<bool> Apagar(int id);

    }
}
