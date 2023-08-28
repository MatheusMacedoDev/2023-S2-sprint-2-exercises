using webapi.locadora.Domains;

namespace webapi.locadora.Interfaces
{
    public interface IFilmeRepository
    {
        /// <summary>
        /// Registra um novo filme
        /// </summary>
        /// <param name="filme">Filme a ser registrado</param>
        void Registrar(FilmeDomain filme);

        /// <summary>
        /// Busca por todos os filmes
        /// </summary>
        /// <returns>Lista de filmes</returns>
        List<FilmeDomain> BuscarTodos();

        /// <summary>
        /// Busca um filme por id
        /// </summary>
        /// <param name="id">Id do filme a ser buscado</param>
        /// <returns>Um objecto que representa a entidade filme</returns>
        FilmeDomain BuscarPorId(int id);

        /// <summary>
        /// Atualiza o filme passando o id pelo corpo
        /// </summary>
        /// <param name="filmeAtualizado">O objeto do filme já atualizado</param>
        void AtualizarPeloCorpo(FilmeDomain filmeAtualizado);

        /// <summary>
        /// Atualiza um filme através do id advindo unicamente pela url
        /// </summary>
        /// <param name="id">Id do filme</param>
        /// <param name="genero">Objeto atualizado do filme</param>
        void AtualizarIdUrl(int id, FilmeDomain filme);

        /// <summary>
        /// Deleta um filme por seu id
        /// </summary>
        /// <param name="id">O id do filme a ser deletado</param>
        void Deletar(int id);
    }
}
