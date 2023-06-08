using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Services.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService) 
        {
            _enderecoService = enderecoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Endereco>>> ListarEnderecos() 
        {
            List<Endereco> enderecos = await _enderecoService.ListarEnderecos();
            return Ok(enderecos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Endereco>> BuscarPorId(int id)
        {
            return await _enderecoService.BuscarPorId(id);
        }

        [HttpPost]
        public async Task<ActionResult<Endereco>> Cadastrar([FromBody] Endereco enderecoRequeste) 
        {
            return await _enderecoService.Adicionar(enderecoRequeste);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Endereco>> Actualizar([FromBody] Endereco enderecoRequeste, int id)
        {
            return await _enderecoService.Actualizar(enderecoRequeste, id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            return await _enderecoService.Apagar(id);
        }

    }
}
