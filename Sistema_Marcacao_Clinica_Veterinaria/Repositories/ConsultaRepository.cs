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

        public async Task<Consulta> BuscarPorId(int id)
        {
            return await _dbContext.Consultas.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<Consulta> Adicionar(Consulta consulta)
        {
            await _dbContext.Consultas.AddAsync(consulta);
            _dbContext.SaveChangesAsync();
            return consulta;
        }

        public async Task<Consulta> Actualizar(Consulta consulta, int id)
        {
            Consulta consultaPorId = await BuscarPorId(id);
            if (consultaPorId == null)
            {
                throw new Exception($"Consulta com o id {id} não foi encontrado na BD");
            }

            //consultaPorId.tipoConsulta = consultaPorId.tipoConsulta;
            consultaPorId.descricao = consultaPorId.descricao;

            consultaPorId.data = consultaPorId.data;
            consultaPorId.preco = consultaPorId.preco;
            consultaPorId.tipoPagamento = consultaPorId.tipoPagamento;
            consultaPorId.marcacoes = consultaPorId.marcacoes;

            _dbContext.Consultas.Update(consultaPorId);
            _dbContext.SaveChangesAsync();
            return consultaPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            Consulta consultaPorId = await BuscarPorId(id);
            if (consultaPorId == null)
            {
                throw new Exception($"Consulta com o id {id} não foi encontrado na BD");
            }

            _dbContext.Consultas.Remove(consultaPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}

