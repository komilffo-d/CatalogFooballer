using CatalogFooball.Services.Enums;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CatalogFooball.Models.DTO
{
    public class FootballPlayerDTO
    {


        public string Name { get; set; }

        public Sex Sex { get; set; } = Sex.OTHER;

        public DateOnly? DateBirthday { get; set; } = null;

        public string Command { get; set; }

        public string Country { get; set; }

    }
}
