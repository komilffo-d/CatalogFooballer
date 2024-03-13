using CatalogFooball.Services.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace CatalogFooball.Models
{
    [Table("football_player")]
    public class FootballPlayer
    {
        [Key]
        [Display(Name = "Идентификатор футболиста")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Наименование футболиста")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Фамилия футболиста")]
        public string Surname { get; set; }

        [AllowNull]
        [Display(Name = "Пол футболиста")]
        public Sex Sex { get; set; } = Sex.OTHER;

        [AllowNull]
        [Display(Name = "Дата рождения футболиста")]
        public DateOnly? DateBirthday { get; set; } = null;

        public int CommandId { get; set; }

        public FootballCommand Command { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

       



    }
}
