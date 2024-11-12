using SchulungQotd.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchulungQotd.Data.Context;

namespace SchulungQotd.Service;

public class QotdService(QotdContext context) : IQotdService
{
    public async Task<QuoteOfTheDayViewModel?> GetQuoteOfTheDayAsync()
    {
        var quotes = await context.Quotes.Include(c => c.Author).ToListAsync();
        var random = new Random();

        var randomQuote = quotes[random.Next(0, quotes.Count)];

        return new QuoteOfTheDayViewModel
        {
            Id = randomQuote.Id,
            QuoteText = randomQuote.QuoteText,
            AuthorBirthDate = randomQuote.Author?.BirthDate,
            AuthorDescription = randomQuote.Author?.Description ?? string.Empty,
            AuthorPhoto = randomQuote.Author?.Photo,
            AuthorPhotoMimeType = randomQuote.Author?.PhotoMimeType
        };
    }
}