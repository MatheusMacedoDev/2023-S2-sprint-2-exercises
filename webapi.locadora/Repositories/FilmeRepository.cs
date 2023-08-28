using System.Data.SqlClient;
using webapi.locadora.Domains;
using webapi.locadora.Interfaces;

namespace webapi.locadora.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private string StringConexao = "Data Source = NOTE17-S14; Initial Catalog = Locadora; User Id = sa; Pwd = Senai@134";

        public void AtualizarIdUrl(int id, FilmeDomain filme)
        {
            throw new NotImplementedException();
        }

        public void AtualizarPeloCorpo(FilmeDomain filmeAtualizado)
        {
            throw new NotImplementedException();
        }

        public FilmeDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
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

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public void Registrar(FilmeDomain filme)
        {
            throw new NotImplementedException();
        }
    }
}
