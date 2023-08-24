using webapi.locadora.Domains;

namespace webapi.locadora.Interfaces
{
    /// <summary>
    /// Interface que define os métodos a serem definidos para o GeneroRepository
    /// </summary>
    public interface IGeneroRepository
    {
        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <param name="novoGenero">Um objeto de gênero</param>
        void Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Uma lista de gêneros</returns>
        List<GeneroDomain> ListarTodos();

        /// <summary>
        /// Atualiza um gênero através do id advindo do corpo da requisição
        /// </summary>
        /// <param name="genero">Um objeto de gênero para atualizar</param>
        void AtualizarIdCorpo(GeneroDomain genero);

        /// <summary>
        /// Atualiza um gênero através do id advindo unicamente pela url
        /// </summary>
        /// <param name="id">Id do gênero</param>
        /// <param name="genero">Objeto atualizado do gênero</param>
        void AtualizarIdUrl(int id, GeneroDomain genero);

        /// <summary>
        /// Deleta um gênero por seu id
        /// </summary>
        /// <param name="id">O id do gênero a ser deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Busca um gênero através do seu id
        /// </summary>
        /// <param name="id">Id do gênero procurado</param>
        /// <returns>O próprio</returns>
        GeneroDomain BuscarPorId(int id);
    }
}
