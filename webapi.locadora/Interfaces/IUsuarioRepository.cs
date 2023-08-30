using webapi.locadora.Domains;

namespace webapi.locadora.Interfaces
{
    /// <summary>
    /// Interface que define os métodos a serem implementados em o UsuarioRepository
    /// </summary>
    public interface IUsuarioRepository
    {
        /// <summary>
        /// É o método que permite a autenticação do usuário
        /// </summary>
        /// <param name="email">O e-mail do usuário</param>
        /// <param name="senha">A senha do usuário</param>
        /// <returns>Os dados do usuário em um objeto</returns>
        UsuarioDomain login(string email, string senha);
    }
}
