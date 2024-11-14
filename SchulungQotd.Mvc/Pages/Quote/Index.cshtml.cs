using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchulungQotd.Service;
using SchulungQotd.Shared.Models;

namespace SchulungQotd.Mvc.Pages.Quote
{
    public class IndexModel(IQotdService qotdService) : PageModel
    {
        #region Members/Constructor

        public IEnumerable<QuoteViewModel>? Quotes { get; set; }

        #endregion

        public async Task OnGetAsync()
        {
            Quotes = await qotdService.GetQuotesAsync(true);
        }
    }
}
