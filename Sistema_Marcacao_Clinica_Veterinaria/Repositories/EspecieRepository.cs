using Microsoft.EntityFrameworkCore;
using Sistema_Marcacao_Clinica_Veterinaria.Data;
using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Repositories
{
    public class EspecieRepository : IEspecieRepository
    {
        private readonly MarcacaoClinicaVeterinariaDBContext _dbContext;

        public EspecieRepository(MarcacaoClinicaVeterinariaDBContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<List<Especie>> ListarEspecies()
        {
            return await _dbContext.Especies.ToListAsync();
        }

        public async Task<Especie> BuscarPorId(int Id)
        {
            return await _dbContext.Especies.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Especie> Adicionar(Especie Especie)
        {
            await _dbContext.Especies.AddAsync(Especie);
            _dbContext.SaveChangesAsync();
            return Especie;
        }

        public async Task<Especie> Actualizar(Especie Especie, int Id)
        {
            Especie EspeciePorId = await BuscarPorId(Id);
            if (EspeciePorId == null)
            {
                throw new Exception($"Especie com o id {Id} não foi encontrado na BD");
            }

            EspeciePorId.Raca = Especie.Raca;
            EspeciePorId.Animais = Especie.Animais;

            _dbContext.Especies.Update(EspeciePorId);
            _dbContext.SaveChangesAsync();
            return EspeciePorId;
        }

        public async Task<bool> Apagar(int Id)
        {
            Especie especiePorId = await BuscarPorId(Id);
            if (especiePorId == null)
            {
                throw new Exception($"Especie com o id {Id} não foi encontrado na BD");
            }

            _dbContext.Especies.Remove(especiePorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
