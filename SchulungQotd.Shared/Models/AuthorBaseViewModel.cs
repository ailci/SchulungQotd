using System.ComponentModel.DataAnnotations;
using SchulungQotd.Shared.Validations;

namespace SchulungQotd.Shared.Models
{
    public class AuthorBaseViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Bitte geben Sie einen Namen ein")]
        [Length(2, 100, ErrorMessage = "Name ist zu lang/kurz")]
        [DeniedValues(["administrator","admin","root","god"], ErrorMessage = "Der Name ist nicht erlaubt")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Bitte geben Sie eine Beschreibung ein")]
        [MinLength(2, ErrorMessage = "Bitte geben Sie eine Beschreibung mit mind. 2 Zeichen ein")]
        [Display(Name = "Beschreibung")]
        public string Description { get; set; } = string.Empty;

        [NoFutureDate(ErrorMessage = "Geburtsdatum liegt in der Zukunft")]
        [DataType(DataType.Date)]
        [Display(Name = "Geburtsdatum")]
        public DateOnly? BirthDate { get; set; }
    }
}