using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.locadora.Domains;
using webapi.locadora.Interfaces;
using webapi.locadora.Repositories;

namespace webapi.locadora.Controllers
{
    // Domain / API / ControllerName
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class GeneroController : ControllerBase
    {
        private IGeneroRepository _generoRepository;

        /// <summary>
        /// É o contrutor padrão da classe GeneroController
        /// </summary>
        public GeneroController()
        {
            _generoRepository = new GeneroRepository();
        }


        /// <summary>
        /// É o endpoint que vai acionar o método de listar todos dentro do repositório
        /// </summary>
        /// <returns>A resposta da requisição</returns>
        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                List<GeneroDomain> list = _generoRepository.ListarTodos();

                return Ok(list);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
            
        }

        /// <summary>
        /// É o endpoint do cadastro de gêneros
        /// </summary>
        /// <param name="genero">Objeto do domínio do gênero</param>
        /// <returns>Resposta ao usuário</returns>
        [HttpPost]
        public IActionResult Cadastrar(GeneroDomain genero)
        {
            try
            {
                _generoRepository.Cadastrar(genero);

                return StatusCode(201);
            } 
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        /// <summary>
        /// É o endpoint que deleta um gênero a partir do seu id
        /// </summary>
        /// <param name="id">O id do gênero a ser deletado</param>
        /// <returns>A resposta da requisição</returns>
        [HttpDelete]
        public IActionResult Deletar(int id)
        {
            try
            {
                _generoRepository.Deletar(id);

                return StatusCode(200);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
