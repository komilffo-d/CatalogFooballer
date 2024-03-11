using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogFooball.Models
{
    [Table("country")]
    public class Country
    {
        [Key]
        [Display(Name = "Идентификатор страны")]
        public int Id { get; set; }

        [Required]
        [Display(Name ="Наименование страны")]
        public string Name { get; set; }

        public List<FootballPlayer> Players { get; set; } = new();
    }
}
