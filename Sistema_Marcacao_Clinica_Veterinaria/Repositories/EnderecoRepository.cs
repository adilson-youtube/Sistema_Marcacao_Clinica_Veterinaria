using Microsoft.EntityFrameworkCore;
using Sistema_Marcacao_Clinica_Veterinaria.Data;
using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly MarcacaoClinicaVeterinariaDBContext _dbContext;

        public EnderecoRepository(MarcacaoClinicaVeterinariaDBContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<List<Endereco>> ListarEnderecos()
        {
            return await _dbContext.Enderecos.ToListAsync();
        }

        public async Task<Endereco> BuscarPorId(int Id)
        {
            return await _dbContext.Enderecos.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Endereco> Adicionar(Endereco Endereco)
        {
            await _dbContext.Enderecos.AddAsync(Endereco);
            _dbContext.SaveChangesAsync();
            return Endereco;
        }

        public async Task<Endereco> Actualizar(Endereco Endereco, int Id)
        {
            Endereco EnderecoPorId = await BuscarPorId(Id);
            if(EnderecoPorId == null) 
            {
                throw new Exception($"Endereço com o id {Id} não foi encontrado na BD");
            }

            EnderecoPorId.Proprietario = Endereco.Proprietario;
            //enderecoPorId.provincia = Endereco.provincia;
            EnderecoPorId.Municipio = Endereco.Municipio;
            EnderecoPorId.Bairro = Endereco.Bairro;
            EnderecoPorId.Rua = Endereco.Rua;

            _dbContext.Enderecos.Update(EnderecoPorId);
            _dbContext.SaveChangesAsync();
            return EnderecoPorId;
        }

        public async Task<bool> Apagar(int Id)
        {
            Endereco EnderecoPorId = await BuscarPorId(Id);
            if (EnderecoPorId == null)
            {
                throw new Exception($"Endereço com o id {Id} não foi encontrado na BD");
            }

            _dbContext.Enderecos.Remove(EnderecoPorId);
            await _dbContext.SaveChangesAsync();
            return true;

        }
    }
}
