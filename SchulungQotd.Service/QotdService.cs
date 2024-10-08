using Microsoft.EntityFrameworkCore;
using SchulungQotd.Data.Context;
using SchulungQotd.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic.CompilerServices;
using SchulungQotd.Domain;
using SchulungQotd.Service.Utilities;

namespace SchulungQotd.Service
{
    public class QotdService : IQotdService
    {
        private readonly QotdContext _context;
        private readonly ILogger<QotdService> _logger;

        public QotdService(QotdContext context, ILogger<QotdService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<AuthorViewModel?> AddAuthorAsync(AuthorCreateViewModel authorCreateViewModel)
        {
            _logger.LogInformation($"AddAuthor aufgerufen.. {authorCreateViewModel}");

            var author = new Author
            {
                Name = authorCreateViewModel.Name,
                Description = authorCreateViewModel.Description,
                BirthDate = authorCreateViewModel.BirthDate
            };

            if (authorCreateViewModel.Photo is not null)
            {
                var (fileContent, contentType) = await Util.GetFile(authorCreateViewModel.Photo);
                author.Photo = fileContent;
                author.PhotoMimeType = contentType;
            }

            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return new AuthorViewModel
            {
                Id = author.Id,
                Name = author.Name,
                Description = author.Description,
                BirthDate = author.BirthDate,
                Photo = author.Photo,
                PhotoMimeType = author.PhotoMimeType
            };
        }

        public IEnumerable<AuthorViewModel> GetAuthors()
        {
            var authors = _context.Authors.ToList();

            var authorsViewModel = authors.Select(c => new AuthorViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                BirthDate = c.BirthDate,
                Photo = c.Photo,
                PhotoMimeType = c.PhotoMimeType
            });

            return authorsViewModel;
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
