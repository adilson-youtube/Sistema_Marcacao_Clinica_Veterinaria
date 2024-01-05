using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces;
using Sistema_Marcacao_Clinica_Veterinaria.Services.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Services
{
    public class MarcacaoService : IMarcacaoService
    {
        private readonly IMarcacaoRepository _marcacaoRepository;
        private readonly IMarcacaoServicoRepository _marcacaoServicoRepository;

         public MarcacaoService(IMarcacaoRepository marcacaoRepository, IMarcacaoServicoRepository marcacaoServicoRepository) 
        {
            _marcacaoRepository = marcacaoRepository;
            _marcacaoServicoRepository = marcacaoServicoRepository;
        }

        public async Task<List<Marcacao>> ListarMarcacoes()
        {
            return await _marcacaoRepository.ListarMarcacoes();
        }

        public async Task<Marcacao> BuscarPorId(int id)
        {
            return await _marcacaoRepository.BuscarPorId(id);
        }

        public async Task<Marcacao> Adicionar(Marcacao marcacao)
        {
            Marcacao AuxMarcacao = await _marcacaoRepository.Adicionar(marcacao);
            foreach (var servico in AuxMarcacao.Servicos) 
            {
                await _marcacaoServicoRepository.Adicionar(new MarcacaoServico(AuxMarcacao.Id, servico.Id));
            }
            return AuxMarcacao;
        }

        public async Task<Marcacao> Actualizar(Marcacao marcacao, int id)
        {
            return await _marcacaoRepository.Actualizar(marcacao, id);
        }

        public async Task<bool> Apagar(int id)
        {
            return await _marcacaoRepository.Apagar(id);
        }
    }
}
