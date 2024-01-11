using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sistema_Marcacao_Clinica_Veterinaria.Enums;
using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Services;
using Sistema_Marcacao_Clinica_Veterinaria.Services.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IAuthenticate _authenticateService;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IAuthenticate authenticateService, IUsuarioService usuarioService)
        {
            _authenticateService = authenticateService;
            _usuarioService = usuarioService;
        }

        [HttpGet("listarUsuarios")]
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
        [Authorize]
        public async Task<ActionResult<UserToken>> Cadastrar([FromBody] Usuario usuarioRequeste)
        {
            if (usuarioRequeste == null) { return BadRequest("Dados inválidos"); }

            var emailExiste = await _authenticateService.UserExists(usuarioRequeste.Email);

            if (emailExiste) { return BadRequest("este email já possui um cadastro!"); }

            var usuario = await _usuarioService.Adicionar(usuarioRequeste);

            if (usuario == null) { return BadRequest("Ocorreu um erro ao cadastrar!"); }

            var token = _authenticateService.GenerateToken(usuario.Id, usuario.Email);

            return new UserToken { Token = token };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserToken>> Login([FromBody] Usuario usuarioRequeste)
        {
            if (usuarioRequeste == null) { return BadRequest("Dados inválidos"); }

            var emailExiste = await _authenticateService.UserExists(usuarioRequeste.Email);

            if (!emailExiste) { return BadRequest("Usuário não existe."); }

            var result = await _authenticateService.AuthenticateAsync(usuarioRequeste.Email, usuarioRequeste.Senha);

            if (!result) { return Unauthorized("Usuário ou senha inválido."); }

            var usuario = await _authenticateService.GetUserByEmail(usuarioRequeste.Email);

            var token = _authenticateService.GenerateToken(usuario.Id, usuario.Email);

            return new UserToken { Token = token };
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> Actualizar([FromBody] Usuario usuarioRequeste, int id)
        {
            return await _usuarioService.Actualizar(usuarioRequeste, id);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            var usuarioId = int.Parse(User.FindFirst("id").Value);
            var usuario = await _usuarioService.BuscarPorId(usuarioId);

            if (!(usuario.Role.Value == Role.Administrador))
            {
                return Unauthorized("Você não tem permissão para excluir clientes.");
            }

            return await _usuarioService.Apagar(id);
        }


    }
}
