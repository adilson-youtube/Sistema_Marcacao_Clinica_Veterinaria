using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Services;
using Sistema_Marcacao_Clinica_Veterinaria.Services.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProprietarioController : ControllerBase
    {
        private readonly IProprietarioService _proprietarioService;

        public ProprietarioController(IProprietarioService proprietarioService) 
        {
            _proprietarioService = proprietarioService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Proprietario>>> ListarProprietarios()
        {
            List<Proprietario> proprietarios = await _proprietarioService.ListarProprietarios();
            return Ok(proprietarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Proprietario>> BuscarPorId(int id)
        {
            return await _proprietarioService.BuscarPorId(id);
        }

        [HttpPost]
        public async Task<ActionResult<Proprietario>> Cadastrar([FromBody] Proprietario proprietarioRequeste)
        {
            return await _proprietarioService.Adicionar(proprietarioRequeste);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Proprietario>> Actualizar([FromBody] Proprietario proprietarioRequeste, int id)
        {
            return await _proprietarioService.Actualizar(proprietarioRequeste, id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            return await _proprietarioService.Apagar(id);
        }

    }
}
