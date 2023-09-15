using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.inlock.codeFirst.morning.Domain;
using webapi.inlock.codeFirst.morning.Interfaces;
using webapi.inlock.codeFirst.morning.Repositories;
using webapi.inlock.codeFirst.morning.ViewModels;

namespace webapi.inlock.codeFirst.morning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public LoginController()
        {
            _userRepository = new UserRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel userData)
        {
            try
            {
                // Finding the correspoding user
                User findedUser = _userRepository.FindUser(userData.Email!, userData.Password!);

                if (findedUser == null)
                {
                    return BadRequest("Os dados não correspondem a nenhum usuário.");
                }

                // Creating token

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, findedUser.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, findedUser.Email),
                    new Claim(ClaimTypes.Role, findedUser.UserTypeId.ToString())
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-chave-autenticacao-webapi-dev"));

                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(issuer: "webapi.inlock.codeFirst.morning", audience: "webapi.inlock.codeFirst.morning", claims: claims, expires: DateTime.Now.AddMinutes(5), signingCredentials: credentials);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                });
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
