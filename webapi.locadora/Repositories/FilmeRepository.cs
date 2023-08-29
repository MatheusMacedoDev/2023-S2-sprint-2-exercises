using System.Data.SqlClient;
using webapi.locadora.Domains;
using webapi.locadora.Interfaces;

namespace webapi.locadora.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private string StringConexao = "Data Source = NOTE17-S14; Initial Catalog = Locadora; User Id = sa; Pwd = Senai@134";

        /// <summary>
        /// Atualiza um filme através do id advindo unicamente pela url
        /// </summary>
        /// <param name="id">Id do filme</param>
        /// <param name="genero">Objeto atualizado do filme</param>
        public void AtualizarIdUrl(int id, FilmeDomain filme)
        {
            using (SqlConnection connection = new SqlConnection(StringConexao))
            {
                string query = "UPDATE Filme SET IdGenero = @NovoIdGenero, Titulo = @NovoTitulo WHERE IdFilme = @Id";

                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NovoIdGenero", filme.IdGenero);
                    command.Parameters.AddWithValue("@NovoTitulo", filme.Titulo);
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Atualiza o filme passando o id pelo corpo
        /// </summary>
        /// <param name="filmeAtualizado">O objeto do filme já atualizado</param>
        public void AtualizarPeloCorpo(FilmeDomain filmeAtualizado)
        {
            using (SqlConnection connection = new SqlConnection(StringConexao))
            {
                string query = "UPDATE Filme SET IdGenero = @NovoIdGenero, Titulo = @NovoTitulo WHERE IdFilme = @Id";

                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NovoIdGenero", filmeAtualizado.IdGenero);
                    command.Parameters.AddWithValue("@NovoTitulo", filmeAtualizado.Titulo);
                    command.Parameters.AddWithValue("@Id", filmeAtualizado.IdFilme);

                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Busca um filme por id
        /// </summary>
        /// <param name="id">Id do filme a ser buscado</param>
        /// <returns>Um objecto que representa a entidade filme</returns>
        public FilmeDomain BuscarPorId(int id)
        {

            using (SqlConnection connection = new SqlConnection(StringConexao))
            {
                string query = "SELECT IdFilme, IdGenero, Titulo FROM Filme WHERE IdFilme = @Id";

                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    
                    SqlDataReader reader= command.ExecuteReader();

                    if (reader.Read())
                    {
                        FilmeDomain filme = new FilmeDomain()
                        {
                            IdFilme = Convert.ToInt32(reader["IdFilme"]),
                            IdGenero = Convert.ToInt32(reader["IdGenero"]),
                            Titulo = reader["Titulo"].ToString()
                        };

                        return filme;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Busca por todos os filmes
        /// </summary>
        /// <returns>Lista de filmes</returns>
        public List<FilmeDomain> BuscarTodos()
        {
            List<FilmeDomain> filmes = new List<FilmeDomain>();

            using (SqlConnection connection = new SqlConnection(StringConexao))
            {
                string query = "SELECT IdFilme, IdGenero, Titulo FROM Filme";

                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        FilmeDomain filme = new FilmeDomain()
                        {
                            IdFilme = Convert.ToInt32(reader["IdFilme"]),
                            IdGenero = Convert.ToInt32(reader["IdGenero"]),
                            Titulo = reader["Titulo"].ToString()
                        };

                        filmes.Add(filme);
                    }
                }
            }

            return filmes;
        }

        /// <summary>
        /// Deleta um filme por seu id
        /// </summary>
        /// <param name="id">O id do filme a ser deletado</param>
        public void Deletar(int id)
        {
            using (SqlConnection connection = new SqlConnection(StringConexao))
            {
                string query = "DELETE Filme WHERE IdFilme = @Id";

                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Registra um novo filme
        /// </summary>
        /// <param name="filme">Filme a ser registrado</param>
        public void Registrar(FilmeDomain filme)
        {
            using (SqlConnection connection = new SqlConnection(StringConexao))
            {
                string query = "INSERT INTO Filme VALUES (@IdGenero, @Titulo)";

                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdGenero", filme.IdGenero);
                    command.Parameters.AddWithValue("@Titulo", filme.Titulo);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
