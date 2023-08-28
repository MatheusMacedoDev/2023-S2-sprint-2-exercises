using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.locadora.Domains;
using webapi.locadora.Repositories;

namespace webapi.locadora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private FilmeRepository _filmeRepository;

        public FilmeController()
        {
            _filmeRepository = new FilmeRepository();
        }

        /// <summary>
        /// É o endpoint que permite buscar por todos os filmes
        /// </summary>
        /// <returns>Resposta ao usuário</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<FilmeDomain> filmes = _filmeRepository.BuscarTodos();

                return Ok(filmes);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        /// <summary>
        /// É o endpoint que busca um filme através de seu id
        /// </summary>
        /// <param name="id">O id do filme buscado</param>
        /// <returns>Resposta ao usuário</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                FilmeDomain filmeEncontrado = _filmeRepository.BuscarPorId(id);

                if (filmeEncontrado == null)
                {
                    return NotFound();
                }

                return Ok(filmeEncontrado);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        /// <summary>
        /// É o endpoint que permite criar um novo filme
        /// </summary>
        /// <param name="filme">Objeto com os dados do novo filme</param>
        /// <returns>Resposta ao usuário</returns>
        [HttpPost]
        public IActionResult Registrar(FilmeDomain filme)
        {
            try
            {
                _filmeRepository.Registrar(filme);

                return StatusCode(201);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
