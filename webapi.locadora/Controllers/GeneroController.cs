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
        /// É o endpoint que busca um gênero através de seu id
        /// </summary>
        /// <param name="id">Id do gênero buscado</param>
        /// <returns>Retorna o gênero encontrado</returns>
        [HttpGet("{id}")]
        public IActionResult ListarPeloId(int id)
        {
            try
            {
                GeneroDomain generoEncontrado = _generoRepository.BuscarPorId(id);

                if (generoEncontrado == null)
                {
                    return NotFound("Não há nenhum gênero com este id");
                }

                return Ok(generoEncontrado);
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
        [HttpDelete("{id}")]
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

        /// <summary>
        /// É o endpoint que atualiza os dados de um determinado gênero através do id fornecido pelo corpo da requisição
        /// </summary>
        /// <param name="genero">Um objeto com o novo dado de um gênero</param>
        /// <returns>Resposta ao usuário</returns>
        [HttpPut]
        public IActionResult UpdadeByIdBody(GeneroDomain genero)
        {
            try
            {
                _generoRepository.AtualizarIdCorpo(genero);

                return NoContent();
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        /// <summary>
        /// Atualiza um gênero especificado por id na url da requisição
        /// </summary>
        /// <param name="id">Id do gênero a ser atualizado</param>
        /// <param name="genero">Objeto do gênero com as novas informações</param>
        /// <returns>Resposta ao usuário</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateByIdUrl(int id, GeneroDomain genero)
        {
            try
            {
                _generoRepository.AtualizarIdUrl(id, genero);
                return StatusCode(200);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
