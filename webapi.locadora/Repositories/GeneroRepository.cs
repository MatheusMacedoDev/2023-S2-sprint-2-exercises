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

        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
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
                string query = $"DELETE FROM Genero WHERE IdGenero = {id}";

                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
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
