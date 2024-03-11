using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CatalogFooball.Services.Enums
{
    public enum Sex: sbyte
    {
        /// <summary>
        /// An entity that has a male gender
        /// </summary>
        [Display(Name ="Мужской")]
        MALE = 0b_01,
        /// <summary>
        /// An entity that has a female gender
        /// </summary>
        [Display(Name="Женский")]
        FEMALE = 0b_10,
        /// <summary>
        /// An entity that is not defined with its gender
        /// </summary>
        [Display(Name ="Неопределенно")]
        OTHER = MALE | FEMALE

    }
}
