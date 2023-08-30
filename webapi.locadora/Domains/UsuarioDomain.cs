using System.ComponentModel.DataAnnotations;

namespace webapi.locadora.Domains
{
    /// <summary>
    /// Classe que representa a entidade Usuario
    /// </summary>
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O usuário deve possuir nome!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O usuário deve possuir e-mail!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O usuário deve possuir senha!")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O usuário deve possuir uma permição, seja comum ou seja administrador!")]
        public bool IsAdmin { get; set; }
    }
}
