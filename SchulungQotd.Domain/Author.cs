using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchulungQotd.Domain
{
    public class Author : BaseEntity
    {
        [Required(ErrorMessage = "Bitte geben Sie einen Namen ein")]
        [StringLength(100)]
        public required string Name { get; set; }
        public required string Description { get; set; }
        public DateOnly? BirthDate { get; set; }
        public IList<Quote> Quotes { get; set; } = new List<Quote>();
        public byte[]? Photo { get; set; }
        public string? PhotoMimeType { get; set; }
    }
}
