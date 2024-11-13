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
    public async Task<IEnumerable<AuthorViewModel>?> GetAuthorsAsync(bool includeQuotes = false)
    {
        var authors = !includeQuotes
            ? await context.Authors.ToListAsync()
            : await context.Authors.Include(c => c.Quotes).ToListAsync();

        var authorsViewModel = authors.Select(author => new AuthorViewModel
        {
            Id = author.Id,
            Name = author.Name,
            Description = author.Description,
            BirthDate = author.BirthDate,
            Photo = author.Photo,
            PhotoMimeType = author.PhotoMimeType,
            Quotes = author.Quotes.Select(q => new QuoteViewModel
            {
                QuoteText = q.QuoteText,
                AuthorName = q.Author.Name,
                Id = q.Id,
                AuthorId = q.AuthorId
            }).ToList()
        });

        return authorsViewModel;
    }

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
            AuthorPhotoMimeType = randomQuote.Author?.PhotoMimeType,
            AuthorName = randomQuote.Author?.Name
        };
    }
}