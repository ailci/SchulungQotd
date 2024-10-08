using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SchulungQotd.Service.Models
{
    public class AuthorCreateViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Bitte geben Sie einen Namen ein!")]
        [MaxLength(100, ErrorMessage = "Der Name ist zu lang")]
        public string Name { get; set; } = String.Empty;

        [Required(ErrorMessage = "Bitte geben Sie eine Beschreibung ein!")]
        public string Description { get; set; } = string.Empty;
        public DateOnly? BirthDate { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
