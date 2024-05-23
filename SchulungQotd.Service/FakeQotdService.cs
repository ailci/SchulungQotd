using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchulungMvc.Common.ViewModels;

namespace SchulungQotd.Service
{
    public class FakeQotdService : IQotdService
    {
        public async Task<QuoteOfTheDayViewModel?> GetQuoteOfTheDayAsync()
        {
            var qotdVm = new QuoteOfTheDayViewModel
            {
                AuthorName = "Ali Ilci",
                QuoteText = "Larum lierum Löffelstiel, wer nicht fragt, der weiß nicht viel.",
                AuthorDescription = "Dozent",
                AuthorBirthdate = DateOnly.FromDateTime(new DateTime(1978, 07, 13)),
                AuthorImage = null,
                AuthorImageMimeType = null
            };

            return await Task.FromResult(qotdVm);
        }

        public async Task<IEnumerable<AuthorViewModel>?> GetAuthorsAsync(bool includeQuotes = false)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthorViewModel?> GetAuthorByIdAsync(Guid id, bool includeQuotes = false)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthorViewModel?> DeleteAuthorAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
