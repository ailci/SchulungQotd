using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchulungQotd.Service;
using SchulungQotd.Service.Models;

namespace SchulungQotd.Mvc.Pages.Quote
{
    public class IndexModel : PageModel
    {
        public IEnumerable<QuoteViewModel> Quotes { get; set; }
        private readonly IQotdService _qotdService;

        public IndexModel(IQotdService qotdService)
        {
            _qotdService = qotdService;
        }

        public async Task OnGetAsync()
        {
            Quotes = await _qotdService.GetQuotesAsync();
        }
    }
}
