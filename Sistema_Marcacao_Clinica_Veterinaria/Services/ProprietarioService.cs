using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces;
using Sistema_Marcacao_Clinica_Veterinaria.Services.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Services
{
    public class ProprietarioService : IProprietarioService
    {
        private readonly IProprietarioRepository _proprietarioRepository;

        public ProprietarioService(IProprietarioRepository proprietarioRepository)
        {
            _proprietarioRepository = proprietarioRepository;
        }

        public async Task<List<Proprietario>> ListarProprietarios()
        {
            return await _proprietarioRepository.ListarProprietarios();
        }

        public async Task<Proprietario> BuscarPorId(int id)
        {
            return await _proprietarioRepository.BuscarPorId(id);
        }

        public async Task<Proprietario> Adicionar(Proprietario proprietario)
        {
            return await _proprietarioRepository.Adicionar(proprietario);
        }

        public async Task<Proprietario> Actualizar(Proprietario proprietario, int id)
        {
            return await _proprietarioRepository.Actualizar(proprietario, id);
        }

        public async Task<bool> Apagar(int id)
        {
            return await _proprietarioRepository.Apagar(id);
        }
    }
}
