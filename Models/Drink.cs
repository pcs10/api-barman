using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Barman.Models
{
    public class Drink
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(30)")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O nome do drink precisa ter entre 3 e 50 caracteres")]
        public string Nome { get; set; }

        public decimal? Preco { get; set; }

        //public IList<string> Ingredientes { get; set; }

        public Drink(string nome)
        {
            Nome = nome;
        }
    }
}
