using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webapi.inlock.codeFirst.morning.ViewModels
{
    public class LoginViewModel
    {
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O e-mail do usuário é obrigatório!")]
        public string? Email { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "A senha do usuário é obrigatória!")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "A senha deve possuir de oito a cem caracteres")]
        public string? Password { get; set; }
    }
}
