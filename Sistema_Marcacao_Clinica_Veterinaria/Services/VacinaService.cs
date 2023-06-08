using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces;
using Sistema_Marcacao_Clinica_Veterinaria.Services.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Services
{
    public class VacinaService : IVacinaService
    {
        private readonly IVacinaRepository _vacinaRepository;

        public VacinaService(IVacinaRepository vacinaRepository) 
        {
            _vacinaRepository = vacinaRepository;
        }

        public async Task<List<Vacina>> ListarVacinas()
        {
            return await _vacinaRepository.ListarVacinas();
        }

        public async Task<Vacina> BuscarPorId(int id)
        {
            return await _vacinaRepository.BuscarPorId(id);
        }

        public async Task<Vacina> Adicionar(Vacina vacina)
        {
            return await _vacinaRepository.Adicionar(vacina);
        }

        public async Task<Vacina> Actualizar(Vacina vacina, int id)
        {
            return await _vacinaRepository.Actualizar(vacina, id);
        }

        public async Task<bool> Apagar(int id)
        {
            return await _vacinaRepository.Apagar(id);
        }
    }
}
