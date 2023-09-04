using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.locadora.DataTransfering;
using webapi.locadora.Domains;
using webapi.locadora.Interfaces;
using webapi.locadora.Repositories;

namespace webapi.locadora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(UsuarioTransfer dadosUsuario)
        {
            try
            {
                UsuarioDomain usuarioEncontrado = _usuarioRepository.Login(dadosUsuario.Email, dadosUsuario.Senha);

                if(usuarioEncontrado == null) { 
                    return NotFound("Os dados não correspondem a nenhum usuário.");
                }

                return Ok(usuarioEncontrado);
            }
            catch (Exception err)
            {
                return BadRequest(err);
            }
        } 
    }
}
