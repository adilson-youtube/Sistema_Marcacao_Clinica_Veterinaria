using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Services;
using Sistema_Marcacao_Clinica_Veterinaria.Services.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacinaController : ControllerBase
    {
        private readonly IVacinaService _vacinaService;

        public VacinaController(IVacinaService vacinaService)
        {
            _vacinaService = vacinaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Vacina>>> ListarVacinas()
        {
            List<Vacina> vacinas = await _vacinaService.ListarVacinas();
            return Ok(vacinas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vacina>> BuscarPorId(int id)
        {
            return await _vacinaService.BuscarPorId(id);
        }

        [HttpPost]
        public async Task<ActionResult<Vacina>> Cadastrar([FromBody] Vacina vacinaRequeste)
        {
            return await _vacinaService.Adicionar(vacinaRequeste);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Vacina>> Actualizar([FromBody] Vacina vacinaRequeste, int id)
        {
            return await _vacinaService.Actualizar(vacinaRequeste, id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            return await _vacinaService.Apagar(id);
        }


    }
}
