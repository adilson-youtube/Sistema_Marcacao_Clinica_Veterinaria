using Sistema_Marcacao_Clinica_Veterinaria.Models;
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

        public Task<Veterinario> Actualizar(Veterinario veterinario, int id)
        {
            throw new NotImplementedException();
        }

        public Task<Veterinario> Adicionar(Veterinario veterinario)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Apagar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Veterinario> BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Veterinario>> ListarAnimais()
        {
            throw new NotImplementedException();
        }
    }
}
