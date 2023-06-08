using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces;
using Sistema_Marcacao_Clinica_Veterinaria.Services.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Services
{
    public class ConsultaService : IConsultaService
    {
        private readonly IConsultaRepository _consultaRepository;

        public ConsultaService(IConsultaRepository consultaRepository) 
        {
            _consultaRepository = consultaRepository;
        }

        public async Task<List<Consulta>> ListarConsultas()
        {
            return await _consultaRepository.ListarConsultas();
        }

        public async Task<Consulta> BuscarPorId(int id)
        {
            return await _consultaRepository.BuscarPorId(id);
        }

        public async Task<Consulta> Adicionar(Consulta consulta)
        {
            return await _consultaRepository.Adicionar(consulta);
        }

        public async Task<Consulta> Actualizar(Consulta consulta, int id)
        {
            return await _consultaRepository.Actualizar(consulta, id);
        }

        public async Task<bool> Apagar(int id)
        {
            return await _consultaRepository.Apagar(id);
        }
    }
}
