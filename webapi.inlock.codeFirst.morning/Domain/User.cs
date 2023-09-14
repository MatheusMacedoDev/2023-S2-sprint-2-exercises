using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.codeFirst.morning.Domain
{
    [Table("Users")]
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();


        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O e-mail do usuário é obrigatório!")]
        public string? Email { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "A senha do usuário é obrigatória!")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "A senha deve possuir de oito a cem caracteres")]
        public string? Password { get; set; }

        // Foreign key

        [Required(ErrorMessage = "O tipo de usuário é obrigatório!")]
        public Guid UserTypeId { get; set; }

        [ForeignKey("UserTypeId")]
        public UserType? UserType { get; set; }
    }
}
