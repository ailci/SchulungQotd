using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchulungMvc.Common.ViewModels
{
    public class AuthorViewModel : AuthorBaseViewModel
    {
        public byte[]? Photo { get; set; }
        public string? PhotoMimeType { get; set; }
        public List<QuoteViewModel> Quotes { get; set; } = new();
    }
}
