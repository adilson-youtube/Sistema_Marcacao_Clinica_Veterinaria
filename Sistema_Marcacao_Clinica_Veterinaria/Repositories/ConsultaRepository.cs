using Microsoft.EntityFrameworkCore;
using Sistema_Marcacao_Clinica_Veterinaria.Data;
using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly MarcacaoClinicaVeterinariaDBContext _dbContext;

        public ConsultaRepository(MarcacaoClinicaVeterinariaDBContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<List<Consulta>> ListarConsultas()
        {
            return await _dbContext.Consultas.ToListAsync();
        }

        public async Task<Consulta> BuscarPorId(int Id)
        {
            return await _dbContext.Consultas.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Consulta> Adicionar(Consulta Consulta)
        {
            await _dbContext.Consultas.AddAsync(Consulta);
            _dbContext.SaveChanges();
            return Consulta;
        }

        public async Task<Consulta> Actualizar(Consulta Consulta, int id)
        {
            Consulta ConsultaPorId = await BuscarPorId(id);
            if (ConsultaPorId == null)
            {
                throw new Exception($"Consulta com o id {id} não foi encontrado na BD");
            }

            //consultaPorId.tipoConsulta = Consulta.tipoConsulta;
            ConsultaPorId.Descricao = Consulta.Descricao;

            ConsultaPorId.Data = Consulta.Data;
            ConsultaPorId.Preco = Consulta.Preco;
            ConsultaPorId.TipoPagamento = Consulta.TipoPagamento;
            //ConsultaPorId.marcacoes = Consulta.marcacoes;

            _dbContext.Consultas.Update(ConsultaPorId);
            _dbContext.SaveChanges();
            return ConsultaPorId;
        }

        public async Task<bool> Apagar(int Id)
        {
            Consulta ConsultaPorId = await BuscarPorId(Id);
            if (ConsultaPorId == null)
            {
                throw new Exception($"Consulta com o id {Id} não foi encontrado na BD");
            }

            _dbContext.Consultas.Remove(ConsultaPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}

