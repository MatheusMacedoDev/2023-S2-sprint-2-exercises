using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace webapi.inlock.codeFirst.morning.Domain
{
    [Table("Studios")]
    public class Studio
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome do estúdio é obrigatório!")]
        public string? Name { get; set; }

        public List<Game>? Games { get; set; }
    }
}
