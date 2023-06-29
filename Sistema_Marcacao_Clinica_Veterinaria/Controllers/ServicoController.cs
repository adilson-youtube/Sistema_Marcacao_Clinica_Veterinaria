using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Services;
using Sistema_Marcacao_Clinica_Veterinaria.Services.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        private readonly IServicoService _servicoService;

        public ServicoController(IServicoService servicoService)
        {
            _servicoService = servicoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Servico>>> ListarServicos()
        {
            List<Servico> servicos = await _servicoService.ListarServicos();
            return Ok(servicos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Servico>> BuscarPorId(int id)
        {
            return await _servicoService.BuscarPorId(id);
        }

        [HttpPost]
        public async Task<ActionResult<Object>> Cadastrar([FromBody] Object servicoRequeste)
        {
            return await _servicoService.Adicionar(servicoRequeste as Servico);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Servico>> Actualizar([FromBody] Servico servicoRequeste, int id)
        {
            return await _servicoService.Actualizar(servicoRequeste, id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            return await _servicoService.Apagar(id);
        }


    }
}
