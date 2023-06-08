using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces;
using Sistema_Marcacao_Clinica_Veterinaria.Services.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalService(IAnimalRepository animalRepository) 
        {
            _animalRepository = animalRepository;
        }

        public async Task<List<Animal>> ListarAnimais()
        {            
            return await _animalRepository.ListarAnimais();
        }

        public async Task<Animal> BuscarPorId(int id)
        {            
            return await _animalRepository.BuscarPorId(id);
        }

        public async Task<Animal> Adicionar(Animal animal)
        {            
            return await _animalRepository.Adicionar(animal);
        }

        public async Task<Animal> Actualizar(Animal animal, int id)
        {
            return await _animalRepository.Actualizar(animal, id);
        }

        public async Task<bool> Apagar(int id)
        {
            return await _animalRepository.Apagar(id);
        }
    }
}
