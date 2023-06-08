using Microsoft.EntityFrameworkCore;
using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces;
using Sistema_Marcacao_Clinica_Veterinaria.Services.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository) 
        {
            _enderecoRepository = enderecoRepository;
        }

        public async Task<List<Endereco>> ListarEnderecos()
        {
            return await _enderecoRepository.ListarEnderecos();
        }

        public async Task<Endereco> BuscarPorId(int id)
        {
            return await _enderecoRepository.BuscarPorId(id);
        }

        public async Task<Endereco> Adicionar(Endereco endereco)
        {
            return await _enderecoRepository.Adicionar(endereco);
        }

        public async Task<Endereco> Actualizar(Endereco endereco, int id)
        {
            return await _enderecoRepository.Actualizar(endereco, id);
        }

        public async Task<bool> Apagar(int id)
        {
            return await _enderecoRepository.Apagar(id);
        }
    }
}
