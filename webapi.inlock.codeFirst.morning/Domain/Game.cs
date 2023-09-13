using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.codeFirst.morning.Domain
{
    [Table("Games")]
    public class Game
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome do jogo é obrigatório!")]
        public string? Name { get; set; }

        [Column(TypeName = "TEXT")]
        public string? Description { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "O data de lançamento do jogo é obrigatória!")]
        public DateTime ReleaseDate { get; set; }

        [Column(TypeName = "Decimal(4, 2)")]
        [Required(ErrorMessage = "O preço do jogo é obrigatório!")]
        public float Price { get; set; }

        // Foreign key

        [Required(ErrorMessage = "O estúdio do jogo é obrigatório!")]
        public Guid IdStudio { get; set; }

        [ForeignKey("IdStudio")]
        public Studio? Studio { get; set; }
    }
}
