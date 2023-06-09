using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Services;
using Sistema_Marcacao_Clinica_Veterinaria.Services.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeterinarioController : ControllerBase
    {
        private readonly IVeterinarioService _veterinarioService;

        public VeterinarioController(IVeterinarioService veterinarioService)
        {
            _veterinarioService = veterinarioService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Veterinario>>> ListarVeterinarios()
        {
            List<Veterinario> veterinarios = await _veterinarioService.ListarVeterinarios();
            return Ok(veterinarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Veterinario>> BuscarPorId(int id)
        {
            return await _veterinarioService.BuscarPorId(id);
        }

        [HttpPost]
        public async Task<ActionResult<Veterinario>> Cadastrar([FromBody] Veterinario veterinarioRequeste)
        {
            return await _veterinarioService.Adicionar(veterinarioRequeste);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Veterinario>> Actualizar([FromBody] Veterinario veterinarioRequeste, int id)
        {
            return await _veterinarioService.Actualizar(veterinarioRequeste, id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            return await _veterinarioService.Apagar(id);
        }


    }
}
