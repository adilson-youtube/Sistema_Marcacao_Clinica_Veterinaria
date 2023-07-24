using Microsoft.EntityFrameworkCore;
using Sistema_Marcacao_Clinica_Veterinaria.Data;
using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Repositories
{
    public class CirurgiaRepository : ICirurgiaRepository
    {
        private readonly MarcacaoClinicaVeterinariaDBContext _dbContext;

        public CirurgiaRepository(MarcacaoClinicaVeterinariaDBContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<List<Cirurgia>> ListarCirurgias()
        {
            return await _dbContext.Cirurgias.ToListAsync();
        }

        public async Task<Cirurgia> BuscarPorId(int Id)
        {
            return await _dbContext.Cirurgias.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Cirurgia> Adicionar(Cirurgia Cirurgia)
        {
            await _dbContext.Cirurgias.AddAsync(Cirurgia);
            _dbContext.SaveChangesAsync();
            return Cirurgia;
        }

        public async Task<Cirurgia> Actualizar(Cirurgia Cirurgia, int Id)
        {
            Cirurgia CirurgiaPorId = await BuscarPorId(Id);
            if (CirurgiaPorId == null)
            {
                throw new Exception($"Cirurgia com o id {Id} não foi encontrado na BD");
            }

            //CirurgiaPorId.tipoCirurgia = Cirurgia.tipoCirurgia;
            CirurgiaPorId.Descricao = Cirurgia.Descricao;

            CirurgiaPorId.Data = Cirurgia.Data;
            CirurgiaPorId.Preco = Cirurgia.Preco;
            CirurgiaPorId.TipoPagamento = Cirurgia.TipoPagamento;
            //cirurgiaPorId.marcacoes = cirurgiaPorId.marcacoes;

            _dbContext.Cirurgias.Update(CirurgiaPorId);
            _dbContext.SaveChanges();
            return CirurgiaPorId;
        }

        public async Task<bool> Apagar(int Id)
        {
            Cirurgia CirurgiaPorId = await BuscarPorId(Id);
            if (CirurgiaPorId == null)
            {
                throw new Exception($"Cirurgia com o id {Id} não foi encontrado na BD");
            }

            _dbContext.Cirurgias.Remove(CirurgiaPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
