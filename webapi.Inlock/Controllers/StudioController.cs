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

        [HttpGet("{id}")]
        public IActionResult FindById(Guid id)
        {
            try
            {
                Studio findedStudio = _studioRepository.FindById(id);

                return Ok(findedStudio);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
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

        [HttpPost]
        public IActionResult Create(Studio newStudio)
        {
            try
            {
                _studioRepository.Create(newStudio);

                return StatusCode(201);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _studioRepository.Delete(id);

                return StatusCode(202);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Studio newStudio)
        {
            try
            {
                _studioRepository.Update(id, newStudio);

                return StatusCode(204);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateWithBody(Studio newStudio)
        {
            try
            {
                _studioRepository.UpdateWithBody(newStudio);

                return StatusCode(204);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
