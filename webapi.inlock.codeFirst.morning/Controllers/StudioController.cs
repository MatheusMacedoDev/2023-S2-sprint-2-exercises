using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.inlock.codeFirst.morning.Domain;
using webapi.inlock.codeFirst.morning.Interfaces;
using webapi.inlock.codeFirst.morning.Repositories;

namespace webapi.inlock.codeFirst.morning.Controllers
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

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Studio findedStudio = _studioRepository.GetById(id);

                return Ok(findedStudio);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(Studio studio)
        {
            try
            {
                _studioRepository.Create(studio);

                return StatusCode(201);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(Studio studioData)
        {
            try
            {
                _studioRepository.Update(studioData);

                return NoContent();
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

                return NoContent();
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
