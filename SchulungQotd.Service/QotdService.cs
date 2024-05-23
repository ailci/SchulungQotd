using SchulungMvc.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchulungQotd.Data.Context;

namespace SchulungQotd.Service
{
    public class QotdService(ILogger<QotdService> logger, QotdContext context, IMapper mapper) : IQotdService
    {
        public async Task<QuoteOfTheDayViewModel?> GetQuoteOfTheDayAsync()
        {
            logger.LogInformation("GetQuoteOfTheDayAsync wurde aufgerufen...");

            var quotes = await context.Quotes
                                      .Include(c => c.Author)
                                      .ToListAsync();
            
            var random = new Random();

            var randomQuote = quotes[random.Next(0, quotes.Count)]; // 5,9,7,6,1,2,4...

            return mapper.Map<QuoteOfTheDayViewModel>(randomQuote);

            //Manuelles Mapping  => Klasse + Eigenschaft = Mapping
            //return new QuoteOfTheDayViewModel
            //{
            //    Id = randomQuote.Id,
            //    QuoteText = randomQuote.QuoteText,
            //    AuthorName = randomQuote.Author.Name,
            //    AuthorDescription = randomQuote.Author.Description,
            //    AuthorBirthdate = randomQuote.Author.BirthDate,
            //    AuthorImage = randomQuote.Author.Photo,
            //    AuthorImageMimeType = randomQuote.Author.PhotoMimeType
            //};
        }

        public async Task<IEnumerable<AuthorViewModel>?> GetAuthorsAsync(bool includeQuotes = false)
        {
            var authors = !includeQuotes
                ? await context.Authors.ToListAsync()
                : await context.Authors.Include(c => c.Quotes).ToListAsync();

            return mapper.Map<IEnumerable<AuthorViewModel>>(authors);
        }
    }
}
