using SchulungQotd.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchulungQotd.Service.Models
{
    public class AuthorViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = string.Empty;
        public DateOnly? BirthDate { get; set; }
        public List<QuoteViewModel> Quotes { get; set; } = new();
        public byte[]? Photo { get; set; }
        public string? PhotoMimeType { get; set; }
    }
}
