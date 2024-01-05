using Microsoft.EntityFrameworkCore;
using Sistema_Marcacao_Clinica_Veterinaria.Data;
using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly MarcacaoClinicaVeterinariaDBContext _dbContext;

        public AnimalRepository(MarcacaoClinicaVeterinariaDBContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<List<Animal>> ListarAnimais()
        {
            return await _dbContext.Animais.Include(p => p.Proprietario).ToListAsync();
        }

        public async Task<Animal> BuscarPorId(int Id)
        {
            return await _dbContext.Animais.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Animal> Adicionar(Animal Animal)
        {
            await _dbContext.Animais.AddAsync(Animal);
            _dbContext.SaveChangesAsync();
            return Animal;
        }

        public async Task<Animal> Actualizar(Animal Animal, int Id)
        {
            Animal AnimalPorId = await BuscarPorId(Id);
            if (AnimalPorId == null)
            {
                throw new Exception($"Animal com o id {Id} não foi encontrado na BD");
            }

            AnimalPorId.Proprietario = Animal.Proprietario;
            AnimalPorId.Nome = Animal.Nome;
            AnimalPorId.Sexo = Animal.Sexo;
            AnimalPorId.DataNascimento = Animal.DataNascimento;
            AnimalPorId.Especie = Animal.Especie;
            AnimalPorId.Marcacoes = Animal.Marcacoes;

            _dbContext.Animais.Update(AnimalPorId);
            _dbContext.SaveChangesAsync();
            return AnimalPorId;
        }

        public async Task<bool> Apagar(int Id)
        {
            Animal AnimalPorId = await BuscarPorId(Id);
            if (AnimalPorId == null)
            {
                throw new Exception($"Animal com o id {Id} não foi encontrado na BD");
            }

            _dbContext.Animais.Remove(AnimalPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
