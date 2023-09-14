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
    public class GameController : ControllerBase
    {
        private IGameRepository _gameRepository;

        public GameController()
        {
            _gameRepository = new GameRepository();
        }

        [HttpGet]
        public IActionResult ListAll()
        {
            try
            {
                List<Game> games = _gameRepository.ListAll();

                return Ok(games);
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
                Game findedGame = _gameRepository.GetById(id);

                return Ok(findedGame);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(Game game)
        {
            try
            {
                _gameRepository.Create(game);

                return StatusCode(201);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(Game gameData)
        {
            try
            {
                _gameRepository.Update(gameData);

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
                _gameRepository.Delete(id);

                return NoContent();
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
