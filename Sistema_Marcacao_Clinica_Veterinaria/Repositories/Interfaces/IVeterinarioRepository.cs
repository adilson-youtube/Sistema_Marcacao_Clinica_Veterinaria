using Sistema_Marcacao_Clinica_Veterinaria.Models;

namespace Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces
{
    public interface IVeterinarioRepository
    {
        Task<List<Veterinario>> ListarAnimais();
        Task<Veterinario> Adicionar(Veterinario veterinario);
        Task<Veterinario> BuscarPorId(int id);
        Task<Veterinario> Actualizar(Veterinario veterinario, int id);
        Task<bool> Apagar(int id);

    }
}
