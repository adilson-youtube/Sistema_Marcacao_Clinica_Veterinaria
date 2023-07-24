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

        public async Task<Marcacao> BuscarPorId(int Id)
        {
            return await _dbContext.Marcacoes.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Marcacao> Adicionar(Marcacao Marcacao)
        {
            await _dbContext.Marcacoes.AddAsync(Marcacao);
            _dbContext.SaveChanges();
            return Marcacao;
        }

        public async Task<Marcacao> Actualizar(Marcacao Marcacao, int Id)
        {
            Marcacao MarcacaoPorId = await BuscarPorId(Id);
            if (MarcacaoPorId == null)
            {
                throw new Exception($"Especie com o id {Id} não foi encontrado na BD");
            }

            MarcacaoPorId.DiaSemana = Marcacao.DiaSemana;
            MarcacaoPorId.DiaMes = Marcacao.DiaMes;
            MarcacaoPorId.Ano = Marcacao.Ano;
            MarcacaoPorId.Animal = Marcacao.Animal;
            MarcacaoPorId.Veterinario = Marcacao.Veterinario;
            //marcacaoPorId.servicos = marcacaoPorId.servicos;

            _dbContext.Marcacoes.Update(MarcacaoPorId);
            _dbContext.SaveChanges();
            return MarcacaoPorId;
        }

        public async Task<bool> Apagar(int Id)
        {
            Marcacao MarcacaoPorId = await BuscarPorId(Id);
            if (MarcacaoPorId == null)
            {
                throw new Exception($"Marcacao com o id {Id} não foi encontrado na BD");
            }

            _dbContext.Marcacoes.Remove(MarcacaoPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
