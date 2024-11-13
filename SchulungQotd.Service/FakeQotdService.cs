using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchulungQotd.Shared.Models;

namespace SchulungQotd.Service
{
    public class FakeQotdService : IQotdService
    {
        public async Task<QuoteOfTheDayViewModel?> GetQuoteOfTheDayAsync()
        {
            var qotdVm = new QuoteOfTheDayViewModel
            {
                Id = Guid.NewGuid(),
                QuoteText = "Larum lierum Löffelstiel",
                AuthorDescription = "Beschreibung",
                AuthorName = "Ich"
            };

            return await Task.FromResult(qotdVm);
        }
    }
}
