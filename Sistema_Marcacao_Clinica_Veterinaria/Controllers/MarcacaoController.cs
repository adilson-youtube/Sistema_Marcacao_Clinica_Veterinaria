using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Services;
using Sistema_Marcacao_Clinica_Veterinaria.Services.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcacaoController : ControllerBase
    {
        private readonly IMarcacaoService _marcacaoService;

        public MarcacaoController(IMarcacaoService marcacaoService)
        {
            _marcacaoService = marcacaoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Marcacao>>> ListarMarcacoes()
        {
            List<Marcacao> marcacoes = await _marcacaoService.ListarMarcacoes();
            return Ok(marcacoes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Marcacao>> BuscarPorId(int id)
        {
            return await _marcacaoService.BuscarPorId(id);
        }

        [HttpPost]
        public async Task<ActionResult<Marcacao>> Cadastrar([FromBody] Marcacao marcacaoRequeste)
        {
            return await _marcacaoService.Adicionar(marcacaoRequeste);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Marcacao>> Actualizar([FromBody] Marcacao marcacaoRequeste, int id)
        {
            return await _marcacaoService.Actualizar(marcacaoRequeste, id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            return await _marcacaoService.Apagar(id);
        }


    }
}
