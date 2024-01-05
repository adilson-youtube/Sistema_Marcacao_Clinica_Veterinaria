using Microsoft.EntityFrameworkCore;
using Sistema_Marcacao_Clinica_Veterinaria.Data;
using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Repositories
{
    public class VacinaRepository : IVacinaRepository
    {
        private readonly MarcacaoClinicaVeterinariaDBContext _dbContext;

        public VacinaRepository(MarcacaoClinicaVeterinariaDBContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<List<Vacina>> ListarVacinas()
        {
            return await _dbContext.Vacinas.ToListAsync();
        }

        public async Task<Vacina> BuscarPorId(int Id)
        {
            return await _dbContext.Vacinas.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Vacina> Adicionar(Vacina Vacina)
        {
            await _dbContext.Vacinas.AddAsync(Vacina);
            _dbContext.SaveChanges();
            return Vacina;
        }

        public async Task<Vacina> Actualizar(Vacina Vacina, int id)
        {
            Vacina VacinaPorId = await BuscarPorId(id);
            if (VacinaPorId == null)
            {
                throw new Exception($"Vacina com o id {id} não foi encontrado na BD");
            }

            VacinaPorId.Nome = Vacina.Nome;
            VacinaPorId.Periodo = Vacina.Periodo;
            //VacinaPorId.tipoVacina = Vacina.tipoVacina;

            VacinaPorId.Data = Vacina.Data;
            VacinaPorId.Preco = Vacina.Preco;
            VacinaPorId.TipoPagamento = Vacina.TipoPagamento;
            //VacinaPorId.Marcacoes = Vacina.Marcacoes;

            _dbContext.Vacinas.Update(VacinaPorId);
            _dbContext.SaveChanges();
            return VacinaPorId;
        }

        public async Task<bool> Apagar(int Id)
        {
            Vacina VacinaPorId = await BuscarPorId(Id);
            if (VacinaPorId == null)
            {
                throw new Exception($"Vacina com o id {Id} não foi encontrado na BD");
            }

            _dbContext.Vacinas.Remove(VacinaPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
