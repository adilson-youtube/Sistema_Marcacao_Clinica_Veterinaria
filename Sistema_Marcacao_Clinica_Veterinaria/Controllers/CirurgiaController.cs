using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Services;
using Sistema_Marcacao_Clinica_Veterinaria.Services.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CirurgiaController : ControllerBase
    {
        private readonly ICirurgiaService _cirurgiaService;

        public CirurgiaController(ICirurgiaService cirurgiaService)
        {
            _cirurgiaService = cirurgiaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cirurgia>>> ListarCirurgias()
        {
            List<Cirurgia> cirurgias = await _cirurgiaService.ListarCirurgias();
            return Ok(cirurgias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cirurgia>> BuscarPorId(int id)
        {
            return await _cirurgiaService.BuscarPorId(id);
        }

        [HttpPost]
        public async Task<ActionResult<Cirurgia>> Cadastrar([FromBody] Cirurgia cirurgiaRequeste)
        {
            return await _cirurgiaService.Adicionar(cirurgiaRequeste);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Cirurgia>> Actualizar([FromBody] Cirurgia cirurgiaRequeste, int id)
        {
            return await _cirurgiaService.Actualizar(cirurgiaRequeste, id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            return await _cirurgiaService.Apagar(id);
        }


    }
}
