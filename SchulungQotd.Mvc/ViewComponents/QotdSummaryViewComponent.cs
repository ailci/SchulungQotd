using Microsoft.AspNetCore.Mvc;
using SchulungMvc.Common.ViewModels;
using SchulungQotd.Service;

namespace SchulungQotd.Mvc.ViewComponents
{
    public class QotdSummaryViewComponent(IQotdService qotdService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var authors = (await qotdService.GetAuthorsAsync(includeQuotes: true)).ToList();

            var qotsSummaryVm = new QotdSummaryViewModel
            {
                AuthorsQuantity = authors.Count,
                QuotesQuantity = authors.Sum(c => c.Quotes.Count)
            };

            //return View(qotsSummaryVm);

            return View("Alternative", qotsSummaryVm);
        }
    }
}
