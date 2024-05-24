using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchulungMvc.Common.Validations;

namespace SchulungMvc.Common.ViewModels
{
    public class AuthorBaseViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Bitte geben Sie einen Namen ein!")]
        [MaxLength(50, ErrorMessage = "Der Name hat mehr als 50 Zeichen")]
        [ForbiddenInput("administrator,root,admin,god")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Beschreibung")]
        [Required(ErrorMessage = "Bitte geben Sie eine Beschreibung ein!")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Geburtsdatum")]
        [DataType(DataType.Date)]
        [NoFutureDate(ErrorMessage="Geburtsdatum liegt in der Zukunft")]
        public DateOnly? BirthDate { get; set; }
    }
}
