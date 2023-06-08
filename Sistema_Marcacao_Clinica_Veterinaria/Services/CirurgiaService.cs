using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces;
using Sistema_Marcacao_Clinica_Veterinaria.Services.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Services
{
    public class CirurgiaService : ICirurgiaService
    {
        private readonly ICirurgiaRepository _cirurgiaRepository;

        public CirurgiaService(ICirurgiaRepository cirurgiaRepository) 
        {
            _cirurgiaRepository = cirurgiaRepository;
        }

        public async Task<List<Cirurgia>> ListarCirurgias()
        {
            return await _cirurgiaRepository.ListarCirurgias();
        }

        public async Task<Cirurgia> BuscarPorId(int id)
        {
            return await _cirurgiaRepository.BuscarPorId(id);
        }

        public async Task<Cirurgia> Adicionar(Cirurgia cirurgia)
        {
            return await _cirurgiaRepository.Adicionar(cirurgia);
        }

        public async Task<Cirurgia> Actualizar(Cirurgia cirurgia, int id)
        {
            return await _cirurgiaRepository.Actualizar(cirurgia, id);
        }

        public async Task<bool> Apagar(int id)
        {
            return await _cirurgiaRepository.Apagar(id);
        }
    }
}
