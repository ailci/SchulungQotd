using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchulungQotd.Shared.Models
{
    public class QuoteOfTheDayViewModel
    {
        public Guid Id { get; set; }
        public string QuoteText { get; set; } = string.Empty;
        public string AuthorName { get; set; } = string.Empty;
        public string AuthorDescription { get; set; } = string.Empty;
        public DateOnly? AuthorBirthDate { get; set; }
        public byte[]? AuthorPhoto { get; set; }
        public string? AuthorPhotoMimeType { get; set; }
    }
}
