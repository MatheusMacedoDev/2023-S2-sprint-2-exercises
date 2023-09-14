namespace webapi.inlock.codeFirst.morning.Utils
{
    public static class Cryptography
    {
        /// <summary>
        /// Gera um hash a partir de uma senha
        /// </summary>
        /// <param name="password">A senha a ser encriptada</param>
        /// <returns>A senha encriptada</returns>
        public static string GetHashByPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        /// <summary>
        /// Verifica se a senha informada é igual ao hash dentro do banco de dados
        /// </summary>
        /// <param name="password">Senha informada</param>
        /// <param name="databasePasswordHash">Hash da senha no banco de dados</param>
        /// <returns></returns>
        public static bool IsEqualHashes(string password, string databasePasswordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, databasePasswordHash);
        }
    }
}
