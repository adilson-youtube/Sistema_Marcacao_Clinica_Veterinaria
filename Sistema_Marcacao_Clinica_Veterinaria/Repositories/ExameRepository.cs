using Microsoft.EntityFrameworkCore;
using Sistema_Marcacao_Clinica_Veterinaria.Data;
using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Repositories
{
    public class ExameRepository : IExameRepository
    {
        private readonly MarcacaoClinicaVeterinariaDBContext _dbContext;

        public ExameRepository(MarcacaoClinicaVeterinariaDBContext _dbContext) 
        {
            _dbContext = _dbContext;
        }

        public async Task<List<Exame>> ListarExames()
        {
            return await _dbContext.Exames.ToListAsync();
        }

        public async Task<Exame> BuscarPorId(int id)
        {
            return await _dbContext.Exames.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<Exame> Adicionar(Exame exame)
        {
            await _dbContext.Exames.AddAsync(exame);
            _dbContext.SaveChangesAsync();
            return exame;
        }

        public async Task<Exame> Actualizar(Exame exame, int id)
        {
            Exame examePorId = await BuscarPorId(id);
            if (examePorId == null)
            {
                throw new Exception($"Exame com o id {id} não foi encontrado na BD");
            }

            examePorId.tipoExame = examePorId.tipoExame;
            examePorId.descricao = examePorId.descricao;

            examePorId.data = examePorId.data;
            examePorId.preco = examePorId.preco;
            examePorId.tipoPagamento = examePorId.tipoPagamento;
            examePorId.marcacoes = examePorId.marcacoes;

            _dbContext.Exames.Update(examePorId);
            _dbContext.SaveChangesAsync();
            return examePorId;
        }

        public async Task<bool> Apagar(int id)
        {
            Exame examePorId = await BuscarPorId(id);
            if (examePorId == null)
            {
                throw new Exception($"Exame com o id {id} não foi encontrado na BD");
            }

            _dbContext.Exames.Remove(examePorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
