using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces;
using Sistema_Marcacao_Clinica_Veterinaria.Services.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Services
{
    public class EspecieService : IEspecieService
    {
        private readonly IEspecieRepository _especieRepository;

        public EspecieService(IEspecieRepository especieRepository) 
        {
            _especieRepository = especieRepository;
        }

        public async Task<List<Especie>> ListarEspecies()
        {
            return await _especieRepository.ListarEspecies();
        }

        public async Task<Especie> BuscarPorId(int id)
        {
            return await _especieRepository.BuscarPorId(id);
        }

        public async Task<Especie> Adicionar(Especie especie)
        {
            return await _especieRepository.Adicionar(especie);
        }

        public async Task<Especie> Actualizar(Especie especie, int id)
        {
            return await _especieRepository.Actualizar(especie, id);
        }

        public async Task<bool> Apagar(int id)
        {
            return await _especieRepository.Apagar(id);
        }
    }
}
