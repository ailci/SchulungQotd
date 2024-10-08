using Microsoft.EntityFrameworkCore;
using SchulungQotd.Data.Context;
using SchulungQotd.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchulungQotd.Service
{
    public class QotdService : IQotdService
    {
        private readonly QotdContext _context;

        public QotdService(QotdContext context)
        {
            _context = context;
        }

        public QuoteOfTheDayViewModel? GetQuoteOfTheDay()
        {
            var quotes = _context.Quotes.Include(c => c.Author).ToList();
            var random = new Random();

            var randomQuote = quotes[random.Next(0, quotes.Count)];  //6,1,3,9,7

            return new QuoteOfTheDayViewModel
            {
                QuoteText = randomQuote.QuoteText,
                AuthorName = randomQuote.Author?.Name ?? string.Empty,
                AuthorDescription = randomQuote.Author?.Description ?? string.Empty,
                AuthorBirthdate = randomQuote.Author?.BirthDate,
                AuthorImage = randomQuote.Author?.Photo,
                AuthorImageMimeType = randomQuote.Author?.PhotoMimeType
            };
        }
    }
}
