﻿using CatalogFooball.Services.Enums;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CatalogFooball.Models.DTO
{
    public class FootballPlayerDTO
    {
        public string Surname { get; set; }

        public string Name { get; set; }

        public string Sex { get; set; } 

        public DateOnly? DateBirthday { get; set; } = null;

        public string Command { get; set; }

        public string Country { get; set; }

    }
}
