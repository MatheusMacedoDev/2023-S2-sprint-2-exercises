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
        [StringLength(256, MinimumLength = 8, ErrorMessage = "A senha deve conter no mínimo 8 caracteres e no máximo 256 caracteres")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O usuário deve possuir uma permição, seja comum ou seja administrador!")]
        public bool IsAdmin { get; set; }
    }
}
