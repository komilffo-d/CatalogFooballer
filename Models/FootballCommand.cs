using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogFooball.Models
{
    [Table("football_command")]
    public class FootballCommand
    {
        [Key]
        [Display(Name = "Идентификатор команды")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Наименование команды")]
        public string Name { get; set; }

        public List<FootballPlayer> Players { get; set; } = new();
    }
}
