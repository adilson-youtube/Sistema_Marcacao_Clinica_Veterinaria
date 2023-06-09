using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Services;
using Sistema_Marcacao_Clinica_Veterinaria.Services.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalService _animalService;

        public AnimalController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Animal>>> ListarAnimais()
        {
            List<Animal> animais = await _animalService.ListarAnimais();
            return Ok(animais);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Animal>> BuscarPorId(int id)
        {
            return await _animalService.BuscarPorId(id);
        }

        [HttpPost]
        public async Task<ActionResult<Animal>> Cadastrar([FromBody] Animal animalRequeste)
        {
            return await _animalService.Adicionar(animalRequeste);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Animal>> Actualizar([FromBody] Animal animalRequeste, int id)
        {
            return await _animalService.Actualizar(animalRequeste, id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            return await _animalService.Apagar(id);
        }


    }
}
