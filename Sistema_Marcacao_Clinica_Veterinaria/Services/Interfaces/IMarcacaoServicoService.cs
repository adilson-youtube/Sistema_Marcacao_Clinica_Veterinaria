using Sistema_Marcacao_Clinica_Veterinaria.Models;

namespace Sistema_Marcacao_Clinica_Veterinaria.Services.Interfaces
{
    public interface IMarcacaoServicoService
    {
        Task<List<MarcacaoServico>> ListarMarcacoesServicos();
        Task<MarcacaoServico> BuscarPorId(int idMarcacao, int idServico);
        Task<MarcacaoServico> Adicionar(MarcacaoServico MarcacaoServico);
        Task<MarcacaoServico> Actualizar(MarcacaoServico MarcacaoServico, int idMarcacao, int idServico);
        Task<bool> Apagar(int idMarcacao, int idServico);
    }
}
