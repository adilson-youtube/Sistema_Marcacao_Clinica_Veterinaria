using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces;
using Sistema_Marcacao_Clinica_Veterinaria.Services.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Services
{
    public class MarcacaoServicoService : IMarcacaoServicoService
    {
        private readonly IMarcacaoServicoRepository _marcacaoServicoRepository;

        public MarcacaoServicoService(IMarcacaoServicoRepository marcacaoServicoRepository)
        {
            _marcacaoServicoRepository = marcacaoServicoRepository;
        }

        public async Task<List<MarcacaoServico>> ListarMarcacoesServicos()
        {
            return await _marcacaoServicoRepository.ListarMarcacoesServicos();
        }

        public async Task<MarcacaoServico> BuscarPorId(int idMarcacao, int idServico)
        {
            return await _marcacaoServicoRepository.BuscarPorId(idMarcacao, idServico);
        }

        public async Task<MarcacaoServico> Adicionar(MarcacaoServico MarcacaoServico)
        {
            return await _marcacaoServicoRepository.Adicionar(MarcacaoServico);
        }

        public async Task<MarcacaoServico> Actualizar(MarcacaoServico MarcacaoServico, int idMarcacao, int idServico)
        {
            return await _marcacaoServicoRepository.Actualizar(MarcacaoServico,idMarcacao, idServico);
        }

        public async Task<bool> Apagar(int idMarcacao, int idServico)
        {
            return await _marcacaoServicoRepository.Apagar(idMarcacao,idServico);
        }

    }
}
