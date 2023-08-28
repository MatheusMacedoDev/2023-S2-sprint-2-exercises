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
    }
}
