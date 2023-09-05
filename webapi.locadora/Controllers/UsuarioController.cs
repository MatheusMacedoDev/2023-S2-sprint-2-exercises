using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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

                // Token generation

                // Setting claims of Payload
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioEncontrado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuarioEncontrado.Email),
                    new Claim(ClaimTypes.Role, usuarioEncontrado.IsAdmin.ToString()),
                    new Claim("Personalized claim", "Personalized value")
                };

                // Setting the access key
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("locadora-chave-autenticacao-webapi-dev"));

                // Setting token creadentials
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // Generating token
                var token = new JwtSecurityToken(issuer: "webapi.locadora", audience: "webapi.locadora", claims: claims, expires: DateTime.Now.AddMinutes(5), signingCredentials: credentials);

                return Ok(new {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception err)
            {
                return BadRequest(err);
            }
        } 
    }
}
