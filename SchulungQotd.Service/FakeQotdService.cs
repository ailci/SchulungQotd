using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchulungQotd.Service.Models;

namespace SchulungQotd.Service
{
    public class FakeQotdService : IQotdService
    {
        public Task<AuthorViewModel?> AddAuthorAsync(AuthorCreateViewModel authorCreateViewModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AuthorViewModel> GetAuthors()
        {
            throw new NotImplementedException();
        }

        public QuoteOfTheDayViewModel? GetQuoteOfTheDay()
        {
            return new QuoteOfTheDayViewModel()
            {
                AuthorName = "Fake Author",
                AuthorDescription = "FakeDescription",
                AuthorBirthdate = new DateOnly(2000, 5, 9),
                QuoteText = "Larum lierum Löffelstiel, wer nicht fragt, der weiß nicht viel!"
            };
        }
    }
}
