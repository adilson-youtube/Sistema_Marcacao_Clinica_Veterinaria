using Sistema_Marcacao_Clinica_Veterinaria.Models;

namespace Sistema_Marcacao_Clinica_Veterinaria.Services.Interfaces
{
    public interface IEnderecoService
    {
        Task<List<Endereco>> ListarEnderecos();
        Task<Endereco> Adicionar(Endereco endereco);
        Task<Endereco> BuscarPorId(int id);
        Task<Endereco> Actualizar(Endereco endereco, int id);
        Task<bool> Apagar(int id);
    }
}
