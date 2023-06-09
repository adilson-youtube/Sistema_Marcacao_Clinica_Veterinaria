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
        public async Task<ActionResult<List<Marcacao>>> ListarEnderecos()
        {
            List<Marcacao> enderecos = await _marcacaoService.ListarMarcacoes();
            return Ok(enderecos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Marcacao>> BuscarPorId(int id)
        {
            return await _marcacaoService.BuscarPorId(id);
        }

        [HttpPost]
        public async Task<ActionResult<Marcacao>> Cadastrar([FromBody] Marcacao enderecoRequeste)
        {
            return await _marcacaoService.Adicionar(enderecoRequeste);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Marcacao>> Actualizar([FromBody] Marcacao enderecoRequeste, int id)
        {
            return await _marcacaoService.Actualizar(enderecoRequeste, id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            return await _marcacaoService.Apagar(id);
        }


    }
}
