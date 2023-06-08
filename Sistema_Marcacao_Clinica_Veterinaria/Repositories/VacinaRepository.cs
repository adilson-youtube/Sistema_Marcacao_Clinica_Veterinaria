using Microsoft.EntityFrameworkCore;
using Sistema_Marcacao_Clinica_Veterinaria.Data;
using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Repositories
{
    public class VacinaRepository : IVacinaRepository
    {
        private readonly MarcacaoClinicaVeterinariaDBContext _dbContext;

        public VacinaRepository(MarcacaoClinicaVeterinariaDBContext _dbContext) 
        {
            _dbContext = _dbContext;
        }

        public async Task<List<Vacina>> ListarVacinas()
        {
            return await _dbContext.Vacinas.ToListAsync();
        }

        public async Task<Vacina> BuscarPorId(int id)
        {
            return await _dbContext.Vacinas.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<Vacina> Adicionar(Vacina vacina)
        {
            await _dbContext.Vacinas.AddAsync(vacina);
            _dbContext.SaveChangesAsync();
            return vacina;
        }

        public async Task<Vacina> Actualizar(Vacina vacina, int id)
        {
            Vacina vacinaPorId = await BuscarPorId(id);
            if (vacinaPorId == null)
            {
                throw new Exception($"Vacina com o id {id} não foi encontrado na BD");
            }

            vacinaPorId.nome = vacinaPorId.nome;
            vacinaPorId.periodo = vacinaPorId.periodo;
            vacinaPorId.tipoVacina = vacinaPorId.tipoVacina;

            vacinaPorId.data = vacinaPorId.data;
            vacinaPorId.preco = vacinaPorId.preco;
            vacinaPorId.tipoPagamento = vacinaPorId.tipoPagamento;
            vacinaPorId.marcacoes = vacinaPorId.marcacoes;

            _dbContext.Servicos.Update(vacinaPorId);
            _dbContext.SaveChangesAsync();
            return vacinaPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            Vacina vacinaPorId = await BuscarPorId(id);
            if (vacinaPorId == null)
            {
                throw new Exception($"Vacina com o id {id} não foi encontrado na BD");
            }

            _dbContext.Servicos.Remove(vacinaPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
