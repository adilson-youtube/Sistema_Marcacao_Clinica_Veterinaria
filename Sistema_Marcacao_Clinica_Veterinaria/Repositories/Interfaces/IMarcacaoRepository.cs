using Sistema_Marcacao_Clinica_Veterinaria.Models;

namespace Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces
{
    public interface IMarcacaoRepository
    {
        Task<List<Marcacao>> ListarMarcacoes();
        Task<Marcacao> Adicionar(Marcacao marcacao);
        Task<Marcacao> BuscarPorId(int id);
        Task<Marcacao> Actualizar(Marcacao marcacao, int id);
        Task<bool> Apagar(int id);

    }
}
