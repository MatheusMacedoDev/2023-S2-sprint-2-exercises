using System.ComponentModel.DataAnnotations;

namespace webapi.locadora.DataTransfering
{
    public class UsuarioTransfer
    {
        [Required(ErrorMessage = "O e-mail não foi inserido!")]
        public string Email { get; set; }


        [Required(ErrorMessage = "A senha não foi inserida!")]
        public string Senha { get; set; }
    }
}
