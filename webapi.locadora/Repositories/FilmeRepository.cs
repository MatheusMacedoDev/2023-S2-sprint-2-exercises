﻿using System.Data.SqlClient;
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

        public void Deletar(int id)
        {
            throw new NotImplementedException();
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
