using Microsoft.EntityFrameworkCore;
using Sistema_Marcacao_Clinica_Veterinaria.Data;
using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Repositories
{
    public class MarcacaoRepository : IMarcacaoRepository
    {
        private readonly MarcacaoClinicaVeterinariaDBContext _dbContext;

        public MarcacaoRepository(MarcacaoClinicaVeterinariaDBContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<List<Marcacao>> ListarMarcacoes()
        {
            return await _dbContext.Marcacoes.ToListAsync();
        }

        public async Task<Marcacao> BuscarPorId(int id)
        {
            return await _dbContext.Marcacoes.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<Marcacao> Adicionar(Marcacao marcacao)
        {
            await _dbContext.Marcacoes.AddAsync(marcacao);
            _dbContext.SaveChangesAsync();
            return marcacao;
        }

        public async Task<Marcacao> Actualizar(Marcacao marcacao, int id)
        {
            Marcacao marcacaoPorId = await BuscarPorId(id);
            if (marcacaoPorId == null)
            {
                throw new Exception($"Especie com o id {id} não foi encontrado na BD");
            }

            marcacaoPorId.diaSemana = marcacaoPorId.diaSemana;
            marcacaoPorId.diaMes = marcacaoPorId.diaMes;
            marcacaoPorId.ano = marcacaoPorId.ano;
            marcacaoPorId.animal = marcacaoPorId.animal;
            marcacaoPorId.veterinario = marcacaoPorId.veterinario;
            marcacaoPorId.servicos = marcacaoPorId.servicos;

            _dbContext.Marcacoes.Update(marcacaoPorId);
            _dbContext.SaveChangesAsync();
            return marcacaoPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            Marcacao marcacaoPorId = await BuscarPorId(id);
            if (marcacaoPorId == null)
            {
                throw new Exception($"Marcacao com o id {id} não foi encontrado na BD");
            }

            _dbContext.Marcacoes.Remove(marcacaoPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
