using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Services;
using Sistema_Marcacao_Clinica_Veterinaria.Services.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaService _consultaService;

        public ConsultaController(IConsultaService consultaService)
        {
            _consultaService = consultaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Consulta>>> ListarConsultas()
        {
            List<Consulta> consultas = await _consultaService.ListarConsultas();
            return Ok(consultas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Consulta>> BuscarPorId(int id)
        {
            return await _consultaService.BuscarPorId(id);
        }

        [HttpPost]
        public async Task<ActionResult<Consulta>> Cadastrar([FromBody] Consulta consultaRequeste)
        {
            return await _consultaService.Adicionar(consultaRequeste);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Consulta>> Actualizar([FromBody] Consulta consultaRequeste, int id)
        {
            return await _consultaService.Actualizar(consultaRequeste, id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            return await _consultaService.Apagar(id);
        }


    }
}
