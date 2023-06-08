using Sistema_Marcacao_Clinica_Veterinaria.Models;

namespace Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces
{
    public interface IConsultaRepository
    {
        Task<List<Consulta>> ListarConsultas();
        Task<Consulta> Adicionar(Consulta consulta);
        Task<Consulta> BuscarPorId(int id);
        Task<Consulta> Actualizar(Consulta consulta, int id);
        Task<bool> Apagar(int id);

    }
}
