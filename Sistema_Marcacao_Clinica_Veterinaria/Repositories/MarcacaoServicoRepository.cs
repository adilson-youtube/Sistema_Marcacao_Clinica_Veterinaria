using Microsoft.EntityFrameworkCore;
using Sistema_Marcacao_Clinica_Veterinaria.Data;
using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces;
using Sistema_Marcacao_Clinica_Veterinaria.Services;

namespace Sistema_Marcacao_Clinica_Veterinaria.Repositories
{
    public class MarcacaoServicoRepository : IMarcacaoServicoRepository
    {
        private readonly MarcacaoClinicaVeterinariaDBContext _dbContext;

        public MarcacaoServicoRepository(MarcacaoClinicaVeterinariaDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<MarcacaoServico>> ListarMarcacoesServicos()
        {
            return await _dbContext.MarcacoesServicos.ToListAsync();
        }

        public async Task<MarcacaoServico> BuscarPorId(int idMarcacao, int idServico)
        {
            return await _dbContext.MarcacoesServicos.FirstOrDefaultAsync(x => (x.MarcacaoId == idMarcacao) && (x.ServicoId == idServico));
        }

        public async Task<MarcacaoServico> Adicionar(MarcacaoServico MarcacaoServico)
        {
            await _dbContext.MarcacoesServicos.AddAsync(MarcacaoServico);
            _dbContext.SaveChanges();
            return MarcacaoServico;
        }

        public async Task<MarcacaoServico> Actualizar(MarcacaoServico MarcacaoServico, int idMarcacao, int idServico)
        {
            //_dbContext.Entry(MarcacaoServico).State = EntityState.Modified;
            MarcacaoServico MarcacaoServicoPorID = await BuscarPorId(idMarcacao, idServico);
            if (MarcacaoServicoPorID == null) 
            {
                throw new Exception($"Marcacao Servico com o id não foi encontrado na BD");
            }
            //MarcacaoServicoPorID.TipoPagamento = MarcacaoServico.TipoPagamento;
            _dbContext.Update(MarcacaoServicoPorID);
            _dbContext.SaveChanges();
            return MarcacaoServicoPorID;
        }

        public async Task<bool> Apagar(int idMarcacao, int idServico)
        {
            MarcacaoServico MarcacaoServicoPorID = await BuscarPorId(idMarcacao, idServico);
            if (MarcacaoServicoPorID == null)
            {
                throw new Exception($"Marcacao Servico com o id não foi encontrado na BD");
            }
            _dbContext.Remove(MarcacaoServicoPorID);
            await _dbContext.SaveChangesAsync();
            return true;

        }

    }
}
