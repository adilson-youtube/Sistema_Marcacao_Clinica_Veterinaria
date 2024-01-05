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

        public async Task<Servico> BuscarPorId(int Id)
        {
            return await _dbContext.Servicos.FirstOrDefaultAsync(x => x.Id == Id);
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

        public async Task<Servico> Actualizar(Servico Servico, int id)
        {
            Servico ServicoPorId = await BuscarPorId(id);
            if (ServicoPorId == null)
            {
                throw new Exception($"Servico com o id {id} não foi encontrado na BD");
            }

            ServicoPorId.Data = Servico.Data;
            ServicoPorId.Preco = Servico.Preco;
            ServicoPorId.TipoPagamento = Servico.TipoPagamento;
            //servicoPorId.marcacoes = Servico.marcacoes;

            _dbContext.Servicos.Update(ServicoPorId);
            _dbContext.SaveChanges();
            return ServicoPorId;
        }

        public async Task<bool> Apagar(int Id)
        {
            Servico ServicoPorId = await BuscarPorId(Id);
            if (ServicoPorId == null)
            {
                throw new Exception($"Servico com o id {Id} não foi encontrado na BD");
            }

            _dbContext.Servicos.Remove(ServicoPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
