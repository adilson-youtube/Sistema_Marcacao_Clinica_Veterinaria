using Microsoft.EntityFrameworkCore;
using Sistema_Marcacao_Clinica_Veterinaria.Data;
using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Repositories
{
    public class CirurgiaRepository : ICirurgiaRepository
    {
        private readonly MarcacaoClinicaVeterinariaDBContext _dbContext;

        public CirurgiaRepository(MarcacaoClinicaVeterinariaDBContext _dbContext) 
        {
            _dbContext = _dbContext;
        }

        public async Task<List<Cirurgia>> ListarCirurgias()
        {
            return await _dbContext.Cirurgias.ToListAsync();
        }

        public async Task<Cirurgia> BuscarPorId(int id)
        {
            return await _dbContext.Cirurgias.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<Cirurgia> Adicionar(Cirurgia cirurgia)
        {
            await _dbContext.Cirurgias.AddAsync(cirurgia);
            _dbContext.SaveChangesAsync();
            return cirurgia;
        }

        public async Task<Cirurgia> Actualizar(Cirurgia cirurgia, int id)
        {
            Cirurgia cirurgiaPorId = await BuscarPorId(id);
            if (cirurgiaPorId == null)
            {
                throw new Exception($"Cirurgia com o id {id} não foi encontrado na BD");
            }

            cirurgiaPorId.tipoCirurgia = cirurgiaPorId.tipoCirurgia;
            cirurgiaPorId.descricao = cirurgiaPorId.descricao;

            cirurgiaPorId.data = cirurgiaPorId.data;
            cirurgiaPorId.preco = cirurgiaPorId.preco;
            cirurgiaPorId.tipoPagamento = cirurgiaPorId.tipoPagamento;
            cirurgiaPorId.marcacoes = cirurgiaPorId.marcacoes;

            _dbContext.Servicos.Update(cirurgiaPorId);
            _dbContext.SaveChangesAsync();
            return cirurgiaPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            Cirurgia cirurgiaPorId = await BuscarPorId(id);
            if (cirurgiaPorId == null)
            {
                throw new Exception($"Cirurgia com o id {id} não foi encontrado na BD");
            }

            _dbContext.Cirurgias.Remove(cirurgiaPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
