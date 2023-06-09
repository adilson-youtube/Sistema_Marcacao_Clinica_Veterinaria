﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<Vacina> BuscarPorId(int id)
        {
            return await _dbContext.Vacinas.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<Vacina> Adicionar(Vacina vacina)
        {
            await _dbContext.Vacinas.AddAsync(vacina);
            _dbContext.SaveChanges();
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
            //vacinaPorId.tipoVacina = vacinaPorId.tipoVacina;

            vacinaPorId.data = vacinaPorId.data;
            vacinaPorId.preco = vacinaPorId.preco;
            vacinaPorId.tipoPagamento = vacinaPorId.tipoPagamento;
            //vacinaPorId.marcacoes = vacinaPorId.marcacoes;

            _dbContext.Vacinas.Update(vacinaPorId);
            _dbContext.SaveChanges();
            return vacinaPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            Vacina vacinaPorId = await BuscarPorId(id);
            if (vacinaPorId == null)
            {
                throw new Exception($"Vacina com o id {id} não foi encontrado na BD");
            }

            _dbContext.Vacinas.Remove(vacinaPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
