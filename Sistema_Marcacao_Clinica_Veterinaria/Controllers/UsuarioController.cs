using Microsoft.AspNetCore.Mvc;
using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Services;
using Sistema_Marcacao_Clinica_Veterinaria.Services.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("/listarUsuarios")]
        public async Task<ActionResult<List<Usuario>>> ListarUsuarios()
        {
            List<Usuario> usuarios = await _usuarioService.ListarUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> BuscarPorId(int id)
        {
            return await _usuarioService.BuscarPorId(id);
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> Cadastrar([FromBody] Usuario usuarioRequeste)
        {
            return await _usuarioService.Adicionar(usuarioRequeste);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> Actualizar([FromBody] Usuario usuarioRequeste, int id)
        {
            return await _usuarioService.Actualizar(usuarioRequeste, id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            return await _usuarioService.Apagar(id);
        }


    }
}
