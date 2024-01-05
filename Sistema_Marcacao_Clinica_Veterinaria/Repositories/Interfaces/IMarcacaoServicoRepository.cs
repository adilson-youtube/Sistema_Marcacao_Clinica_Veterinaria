using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Services;

namespace Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces
{
    public interface IMarcacaoServicoRepository
    {
        Task<List<MarcacaoServico>> ListarMarcacoesServicos();
        Task<MarcacaoServico> BuscarPorId(int idMarcacao, int idServico);
        Task<MarcacaoServico> Adicionar(MarcacaoServico MarcacaoServico);
        Task<MarcacaoServico> Actualizar(MarcacaoServico MarcacaoServico, int idMarcacao, int idServico);
        Task<bool> Apagar(int idMarcacao, int idServico);

    }
}
