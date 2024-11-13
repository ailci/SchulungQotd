using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchulungQotd.Shared.Models
{
    public class AuthorViewModel : AuthorBaseViewModel
    {
        public byte[]? Photo { get; set; }
        public string? PhotoMimeType { get; set; }
        public IList<QuoteViewModel> Quotes { get; set; } = [];
    }
}
