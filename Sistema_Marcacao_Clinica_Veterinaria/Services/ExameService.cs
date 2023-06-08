using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces;
using Sistema_Marcacao_Clinica_Veterinaria.Services.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Services
{
    public class ExameService : IExameService
    {
        private readonly IExameRepository _exameRepository;

        public ExameService(IExameRepository exameRepository) 
        {
            _exameRepository = exameRepository;
        }

        public async Task<List<Exame>> ListarExames()
        {
            return await _exameRepository.ListarExames();
        }

        public async Task<Exame> BuscarPorId(int id)
        {
            return await _exameRepository.BuscarPorId(id);
        }

        public async Task<Exame> Adicionar(Exame exame)
        {
            return await _exameRepository.Adicionar(exame);
        }

        public async Task<Exame> Actualizar(Exame exame, int id)
        {
            return await _exameRepository.Actualizar(exame, id);
        }

        public async Task<bool> Apagar(int id)
        {
            return await _exameRepository.Apagar(id);
        }
    }
}
