using Microsoft.EntityFrameworkCore;
using Sistema_Marcacao_Clinica_Veterinaria.Data;
using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly MarcacaoClinicaVeterinariaDBContext _dbContext;
        public AnimalRepository() 
        {
            _dbContext = _dbContext;
        }

        public async Task<List<Animal>> ListarAnimais()
        {
            return await _dbContext.Animais.ToListAsync();
        }

        public async Task<Animal> BuscarPorId(int id)
        {
            return await _dbContext.Animais.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<Animal> Adicionar(Animal animal)
        {
            await _dbContext.Animais.AddAsync(animal);
            _dbContext.SaveChangesAsync();
            return animal;
        }

        public async Task<Animal> Actualizar(Animal animal, int id)
        {
            Animal animalPorId = await BuscarPorId(id);
            if (animalPorId == null)
            {
                throw new Exception($"Animal com o id {id} não foi encontrado na BD");
            }

            animalPorId.proprietario = animalPorId.proprietario;
            animalPorId.nome = animalPorId.nome;
            animalPorId.sexo = animalPorId.sexo;
            animalPorId.dataNascimento = animalPorId.dataNascimento;
            animalPorId.especie = animalPorId.especie;
            animalPorId.marcacoes = animalPorId.marcacoes;

            _dbContext.Animais.Update(animalPorId);
            _dbContext.SaveChangesAsync();
            return animalPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            Animal animalPorId = await BuscarPorId(id);
            if (animalPorId == null)
            {
                throw new Exception($"Animal com o id {id} não foi encontrado na BD");
            }

            _dbContext.Animais.Remove(animalPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
