using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchulungMvc.Common.ViewModels
{
    public class AuthorBaseViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Beschreibung")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Geburtsdatum")]
        public DateOnly? BirthDate { get; set; }
    }
}
