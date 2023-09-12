using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Inlock.Domains;
using webapi.Inlock.Interfaces;
using webapi.Inlock.Repository;

namespace webapi.Inlock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class StudioController : ControllerBase
    {
        private IStudioRepository _studioRepository;

        public StudioController()
        {
            _studioRepository = new StudioRepository();
        }

        [HttpGet]
        public IActionResult ListAll()
        {
            try
            {
                List<Studio> studios = _studioRepository.ListAll();

                return Ok(studios);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("ListAllWithGames")]
        public IActionResult ListAllWithGames()
        {
            try
            {
                List<Studio> studios = _studioRepository.ListAllWithGames();

                return Ok(studios);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
