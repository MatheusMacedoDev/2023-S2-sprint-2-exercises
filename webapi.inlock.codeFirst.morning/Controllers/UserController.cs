using Microsoft.AspNetCore.Mvc;
using webapi.inlock.codeFirst.morning.Domain;
using webapi.inlock.codeFirst.morning.Interfaces;
using webapi.inlock.codeFirst.morning.Repositories;

namespace webapi.inlock.codeFirst.morning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;

        public UserController()
        {
            _userRepository = new UserRepository();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            try
            {
                _userRepository.Register(user);

                return StatusCode(201);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
