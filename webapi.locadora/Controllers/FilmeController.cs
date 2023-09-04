using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.locadora.Domains;
using webapi.locadora.Repositories;

namespace webapi.locadora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
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

        /// <summary>
        /// É o endpoint que permite deletar um filme
        /// </summary>
        /// <param name="id">Id do filme a ser deletado</param>
        /// <returns>Resposta ao usuário</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _filmeRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        /// <summary>
        /// É o endpoint que permite atualizar um filme através do id passado pela url
        /// </summary>
        /// <param name="id">Id do filme</param>
        /// <param name="filmeAtualizado">Objeto com dados atualizados</param>
        /// <returns>Resposta ao usuário</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateByIdUrl(int id, FilmeDomain filmeAtualizado)
        {
            try
            {
                FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);

                if (filmeBuscado != null)
                {
                    try
                    {
                        _filmeRepository.AtualizarIdUrl(id, filmeAtualizado);

                        return NoContent();
                    }
                    catch (Exception err)
                    {
                        return BadRequest();
                    }

                }
                
                return NotFound("O filme a ser atualizado não existe.");
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        /// <summary>
        /// É o endpoint que faz a atualização de um filme através dos dados passados no corpo da requisição
        /// </summary>
        /// <param name="filmeAtualizado">Objeto do filme com dados atualizados</param>
        /// <returns>Resposta ao usuário</returns>
        [HttpPut]
        public IActionResult UpdateByIdBody(FilmeDomain filmeAtualizado)
        {
            try
            {
                FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(filmeAtualizado.IdFilme);

                if (filmeBuscado != null)
                {
                    try
                    {
                        _filmeRepository.AtualizarPeloCorpo(filmeAtualizado);

                        return NoContent();
                    }
                    catch (Exception err)
                    {
                        return BadRequest();
                    }
                }

                return NotFound("O filme a ser atualizado não existe.");
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
