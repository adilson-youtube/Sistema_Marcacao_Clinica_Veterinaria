using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces;
using Sistema_Marcacao_Clinica_Veterinaria.Services.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Services
{
    public class VeterinarioService : IVeterinarioService
    {
        private readonly IVeterinarioRepository _veterinarioRepository;

        public VeterinarioService(IVeterinarioRepository veterinarioRepository) 
        {
            _veterinarioRepository = veterinarioRepository;
        }

        public async Task<List<Veterinario>> ListarVeterinarios()
        {
            return await _veterinarioRepository.ListarVeterinarios();
        }

        async public Task<Veterinario> BuscarPorId(int id)
        {
            return await _veterinarioRepository.BuscarPorId(id);
        }

        async public Task<Veterinario> Adicionar(Veterinario veterinario)
        {
            return await _veterinarioRepository.Adicionar(veterinario);
        }

        async public Task<Veterinario> Actualizar(Veterinario veterinario, int id)
        {
            return await _veterinarioRepository.Actualizar(veterinario, id);
        }

        async public Task<bool> Apagar(int id)
        {
            return await _veterinarioRepository.Apagar(id);
        }
    }
}
