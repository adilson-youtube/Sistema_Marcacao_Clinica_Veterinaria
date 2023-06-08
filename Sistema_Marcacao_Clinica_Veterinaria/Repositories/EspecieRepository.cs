using Microsoft.EntityFrameworkCore;
using Sistema_Marcacao_Clinica_Veterinaria.Data;
using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Repositories
{
    public class EspecieRepository : IEspecieRepository
    {
        private readonly MarcacaoClinicaVeterinariaDBContext _dbContext;
        public EspecieRepository(MarcacaoClinicaVeterinariaDBContext _dbContext) 
        {
            _dbContext = _dbContext;
        }

        public async Task<List<Especie>> ListarEspecies()
        {
            return await _dbContext.Especies.ToListAsync();
        }

        public async Task<Especie> BuscarPorId(int id)
        {
            return await _dbContext.Especies.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<Especie> Adicionar(Especie especie)
        {
            await _dbContext.Especies.AddAsync(especie);
            _dbContext.SaveChangesAsync();
            return especie;
        }

        public async Task<Especie> Actualizar(Especie especie, int id)
        {
            Especie especiePorId = await BuscarPorId(id);
            if (especiePorId == null)
            {
                throw new Exception($"Especie com o id {id} não foi encontrado na BD");
            }

            especiePorId.raca = especiePorId.raca;
            especiePorId.animais = especiePorId.animais;

            _dbContext.Especies.Update(especiePorId);
            _dbContext.SaveChangesAsync();
            return especiePorId;
        }

        public async Task<bool> Apagar(int id)
        {
            Especie especiePorId = await BuscarPorId(id);
            if (especiePorId == null)
            {
                throw new Exception($"Especie com o id {id} não foi encontrado na BD");
            }

            _dbContext.Especies.Remove(especiePorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
