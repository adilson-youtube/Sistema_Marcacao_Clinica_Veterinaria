using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces;
using Sistema_Marcacao_Clinica_Veterinaria.Services.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Services
{
    public class ServicoService : IServicoService
    {
        private readonly IServicoRepository _servicoRepository;

        public ServicoService(IServicoRepository servicoRepository) 
        {
            _servicoRepository = servicoRepository;
        }

        public async Task<List<Servico>> ListarServicos()
        {
            return await _servicoRepository.ListarServicos();
        }

        public async Task<Servico> BuscarPorId(int id)
        {
            return await _servicoRepository.BuscarPorId(id);
        }

        public async Task<Servico> Adicionar(Servico servico)
        {
            return await _servicoRepository.Adicionar(servico);
        }

        public async Task<List<Servico>> AdicionarLista(List<Servico> servico)
        {
            return await _servicoRepository.AdicionarLista(servico);
        }

        public async Task<Servico> Actualizar(Servico servico, int id)
        {
            return await _servicoRepository.Actualizar(servico, id);
        }

        public async Task<bool> Apagar(int id)
        {
            return await _servicoRepository.Apagar(id);
        }
    }
}
