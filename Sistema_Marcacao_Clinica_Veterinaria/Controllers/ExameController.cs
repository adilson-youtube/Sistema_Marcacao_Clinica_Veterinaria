using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Services;
using Sistema_Marcacao_Clinica_Veterinaria.Services.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExameController : ControllerBase
    {
        private readonly IExameService _exameService;

        public ExameController(IExameService exameService) 
        {
            _exameService = exameService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Exame>>> ListarExames()
        {
            List<Exame> exames = await _exameService.ListarExames();
            return Ok(exames);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Exame>> BuscarPorId(int id)
        {
            return await _exameService.BuscarPorId(id);
        }

        [HttpPost]
        public async Task<ActionResult<Exame>> Cadastrar([FromBody] Exame exameRequeste)
        {
            return await _exameService.Adicionar(exameRequeste);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Exame>> Actualizar([FromBody] Exame exameRequeste, int id)
        {
            return await _exameService.Actualizar(exameRequeste, id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            return await _exameService.Apagar(id);
        }


    }
}
