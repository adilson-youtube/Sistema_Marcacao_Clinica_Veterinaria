using Microsoft.EntityFrameworkCore;
using Sistema_Marcacao_Clinica_Veterinaria.Data;
using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly MarcacaoClinicaVeterinariaDBContext _dbContext;

        public EnderecoRepository(MarcacaoClinicaVeterinariaDBContext _dbContext) 
        {
            _dbContext = _dbContext;
        }

        public async Task<List<Endereco>> ListarEnderecos()
        {
            return await _dbContext.Enderecos.ToListAsync();
        }

        public async Task<Endereco> BuscarPorId(int id)
        {
            return await _dbContext.Enderecos.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<Endereco> Adicionar(Endereco endereco)
        {
            await _dbContext.Enderecos.AddAsync(endereco);
            _dbContext.SaveChangesAsync();
            return endereco;
        }

        public async Task<Endereco> Actualizar(Endereco endereco, int id)
        {
            Endereco enderecoPorId = await BuscarPorId(id);
            if(enderecoPorId == null) 
            {
                throw new Exception($"Endereço com o id {id} não foi encontrado na BD");
            }

            enderecoPorId.proprietario = endereco.proprietario;
            enderecoPorId.provincia = endereco.provincia;
            enderecoPorId.municipio = endereco.municipio;
            enderecoPorId.bairro = endereco.bairro;
            enderecoPorId.rua = endereco.rua;

            _dbContext.Enderecos.Update(enderecoPorId);
            _dbContext.SaveChangesAsync();
            return enderecoPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            Endereco enderecoPorId = await BuscarPorId(id);
            if (enderecoPorId == null)
            {
                throw new Exception($"Endereço com o id {id} não foi encontrado na BD");
            }

            _dbContext.Enderecos.Remove(enderecoPorId);
            await _dbContext.SaveChangesAsync();
            return true;

        }
    }
}
