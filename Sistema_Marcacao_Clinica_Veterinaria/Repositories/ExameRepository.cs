using Microsoft.EntityFrameworkCore;
using Sistema_Marcacao_Clinica_Veterinaria.Data;
using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Repositories
{
    public class ExameRepository : IExameRepository
    {
        private readonly MarcacaoClinicaVeterinariaDBContext _dbContext;

        public ExameRepository(MarcacaoClinicaVeterinariaDBContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<List<Exame>> ListarExames()
        {
            return await _dbContext.Exames.ToListAsync();
        }

        public async Task<Exame> BuscarPorId(int Id)
        {
            return await _dbContext.Exames.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Exame> Adicionar(Exame Exame)
        {
            await _dbContext.Exames.AddAsync(Exame);
            _dbContext.SaveChanges();
            return Exame;
        }

        public async Task<Exame> Actualizar(Exame Exame, int Id)
        {
            Exame ExamePorId = await BuscarPorId(Id);
            if (ExamePorId == null)
            {
                throw new Exception($"Exame com o id {Id} não foi encontrado na BD");
            }

            //ExamePorId.tipoExame = Exame.tipoExame;
            ExamePorId.Descricao = Exame.Descricao;

            ExamePorId.Data = Exame.Data;
            ExamePorId.Preco = Exame.Preco;
            ExamePorId.TipoPagamento = Exame.TipoPagamento;
            //ExamePorId.marcacoes = Exame.marcacoes;

            _dbContext.Exames.Update(ExamePorId);
            _dbContext.SaveChanges();
            return ExamePorId;
        }

        public async Task<bool> Apagar(int Id)
        {
            Exame ExamePorId = await BuscarPorId(Id);
            if (ExamePorId == null)
            {
                throw new Exception($"Exame com o id {Id} não foi encontrado na BD");
            }

            _dbContext.Exames.Remove(ExamePorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
