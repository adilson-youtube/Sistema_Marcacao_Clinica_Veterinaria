using Microsoft.EntityFrameworkCore;
using Sistema_Marcacao_Clinica_Veterinaria.Data;
using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Repositories
{
    public class ServicoRepository : IServicoRepository
    {
        private readonly MarcacaoClinicaVeterinariaDBContext _dbContext;

        public ServicoRepository(MarcacaoClinicaVeterinariaDBContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<List<Servico>> ListarServicos()
        {
            return await _dbContext.Servicos.ToListAsync();
        }

        public async Task<Servico> BuscarPorId(int id)
        {
            return await _dbContext.Servicos.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<Servico> Adicionar(Servico servico)
        {
            await _dbContext.Servicos.AddAsync(servico);
            _dbContext.SaveChanges();
            return servico;
        }

        public async Task<List<Servico>> AdicionarLista(List<Servico> servico)
        {
            await _dbContext.Servicos.AddRangeAsync(servico);
            _dbContext.SaveChanges();
            return servico;
        }

        public async Task<Servico> Actualizar(Servico servico, int id)
        {
            Servico servicoPorId = await BuscarPorId(id);
            if (servicoPorId == null)
            {
                throw new Exception($"Servico com o id {id} não foi encontrado na BD");
            }

            servicoPorId.data = servicoPorId.data;
            servicoPorId.preco = servicoPorId.preco;
            servicoPorId.tipoPagamento = servicoPorId.tipoPagamento;
            //servicoPorId.marcacoes = servicoPorId.marcacoes;

            _dbContext.Servicos.Update(servicoPorId);
            _dbContext.SaveChanges();
            return servicoPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            Servico servicoPorId = await BuscarPorId(id);
            if (servicoPorId == null)
            {
                throw new Exception($"Servico com o id {id} não foi encontrado na BD");
            }

            _dbContext.Servicos.Remove(servicoPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
