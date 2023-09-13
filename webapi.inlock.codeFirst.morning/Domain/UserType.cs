using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.codeFirst.morning.Domain
{
    [Table("UserTypes")]
    public class UserType
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome do tipo de usuário é obrigatório!")]
        public string? Title { get; set; }
    }
}
