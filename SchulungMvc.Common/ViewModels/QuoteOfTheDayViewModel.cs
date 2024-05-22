using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchulungMvc.Common.ViewModels
{
    public class QuoteOfTheDayViewModel
    {
        public Guid Id { get; set; }
        public string QuoteText { get; set; } = string.Empty;
        public string AuthorName { get; set; } = string.Empty;
        public string AuthorDescription { get; set; } = string.Empty;
        public DateOnly? AuthorBirthdate { get; set; }
        public byte[]? AuthorImage { get; set; }
        public string? AuthorImageMimeType { get; set; }
    }
}
