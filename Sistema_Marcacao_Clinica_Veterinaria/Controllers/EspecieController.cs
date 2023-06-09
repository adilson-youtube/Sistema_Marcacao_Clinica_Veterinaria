using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Services;
using Sistema_Marcacao_Clinica_Veterinaria.Services.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecieController : ControllerBase
    {
        private readonly IEspecieService _specieService;

        public EspecieController(IEspecieService specieService)
        {
            _specieService = specieService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Especie>>> ListarEspecies()
        {
            List<Especie> especies = await _specieService.ListarEspecies();
            return Ok(especies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Especie>> BuscarPorId(int id)
        {
            return await _specieService.BuscarPorId(id);
        }

        [HttpPost]
        public async Task<ActionResult<Especie>> Cadastrar([FromBody] Especie especieRequeste)
        {
            return await _specieService.Adicionar(especieRequeste);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Especie>> Actualizar([FromBody] Especie especieRequeste, int id)
        {
            return await _specieService.Actualizar(especieRequeste, id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            return await _specieService.Apagar(id);
        }


    }
}
