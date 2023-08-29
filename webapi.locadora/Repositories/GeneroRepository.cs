using System.Data.SqlClient;
using webapi.locadora.Domains;
using webapi.locadora.Interfaces;

namespace webapi.locadora.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        /// <summary>
        /// Connection String
        /// Data Source: Nome do servidor
        /// Initial Catalog: Nome do banco de dados
        /// Autentication:
        ///     - WIndows: Integrated Security = true
        ///     -SqlServer: User Id = sa; Psd = Senha
        /// </summary>
        private string StringConexao = "Data Source = NOTE17-S14; Initial Catalog = Locadora; User Id = sa; Pwd = Senai@134";

        /// <summary>
        /// Atualiza um gênero através do id advindo unicamente pela url
        /// </summary>
        /// <param name="id">Id do gênero</param>
        /// <param name="genero">Objeto atualizado do gênero</param>
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            using (SqlConnection connection = new SqlConnection(StringConexao)) 
            {
                string query = "UPDATE Genero SET Nome = @NovoNome WHERE IdGenero = @Id";

                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", genero.IdGenero);
                    command.Parameters.AddWithValue("@NovoNome", genero.Nome);
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Atualiza um gênero através de um id passado pela url
        /// </summary>
        /// <param name="id">Id do gênero a ser alterado</param>
        /// <param name="genero">Novo gênero com as alterações</param>
        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            using (SqlConnection connection = new SqlConnection(StringConexao))
            {
                string query = "UPDATE Genero SET Nome = @NovoNome WHERE IdGenero = @Id";

                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@NovoNome", genero.Nome);

                    command.ExecuteNonQuery();
                }
            }

        }

        /// <summary>
        /// Busca um gênero através de seu id
        /// </summary>
        /// <param name="id">Id do gênero</param>
        /// <returns>O gênero encontrado</returns>
        public GeneroDomain BuscarPorId(int id)
        {
            GeneroDomain generoEncontrado = null;

            using (SqlConnection connection = new SqlConnection(StringConexao))
            {
                string query = "SELECT IdGenero, Nome from Genero WHERE IdGenero = @Id";

                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    SqlDataReader sqlDataReader = command.ExecuteReader();

                    if (sqlDataReader.Read())
                    {
                        generoEncontrado = new GeneroDomain()
                        {
                            IdGenero = Convert.ToInt32(sqlDataReader["IdGenero"]),
                            Nome = sqlDataReader["Nome"].ToString()
                        };
                    }
                }
            }

            return generoEncontrado;
        }

        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <param name="novoGenero">Um objeto de gênero</param>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            using (SqlConnection connection = new SqlConnection(StringConexao))
            {
                string query = $"INSERT INTO Genero VALUES (@Nome)";

                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nome", novoGenero.Nome);
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deleta um gênero por seu id
        /// </summary>
        /// <param name="id">O id do gênero a ser deletado</param>
        public void Deletar(int id)
        {
            using (SqlConnection connection = new SqlConnection(StringConexao))
            {
                string query = $"DELETE FROM Genero WHERE IdGenero = @Id";

                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Uma lista de gêneros</returns>
        public List<GeneroDomain> ListarTodos()
        {
            List<GeneroDomain> list = new List<GeneroDomain>();

            // O using é o responsável por iniciar e finalizar um processo assim que uma ação pretendida for finalizada
            using (SqlConnection connection = new SqlConnection(StringConexao))
            {
                // Declara a instrução SQL a ser executada
                string query = "SELECT IdGenero, Nome FROM Genero";

                // Abre a conexão
                connection.Open();
               
                // O comando SQL a ser executado
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // Executa a query e armazena os dados no Data Reader
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain()
                        {
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                            Nome = rdr["Nome"].ToString()
                        };

                        list.Add(genero);
                    }
                }
            }

            return list;
        }
    }
}
