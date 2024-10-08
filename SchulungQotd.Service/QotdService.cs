using Microsoft.EntityFrameworkCore;
using SchulungQotd.Data.Context;
using SchulungQotd.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic.CompilerServices;
using SchulungQotd.Domain;
using SchulungQotd.Service.Utilities;
using AutoMapper;

namespace SchulungQotd.Service
{
    public class QotdService : IQotdService
    {
        private readonly QotdContext _context;
        private readonly ILogger<QotdService> _logger;
        private readonly IMapper _mapper;

        public QotdService(QotdContext context, ILogger<QotdService> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<AuthorViewModel?> AddAuthorAsync(AuthorCreateViewModel authorCreateViewModel)
        {
            _logger.LogInformation($"AddAuthor aufgerufen.. {authorCreateViewModel}");

            //var author = new Author
            //{
            //    Name = authorCreateViewModel.Name,
            //    Description = authorCreateViewModel.Description,
            //    BirthDate = authorCreateViewModel.BirthDate
            //};

            //if (authorCreateViewModel.Photo is not null)
            //{
            //    var (fileContent, contentType) = await Util.GetFile(authorCreateViewModel.Photo);
            //    author.Photo = fileContent;
            //    author.PhotoMimeType = contentType;
            //}

            var author = _mapper.Map<Author>(authorCreateViewModel);

            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return _mapper.Map<AuthorViewModel>(author);
        }

        public async Task<IEnumerable<QuoteViewModel>?> GetQuotesAsync()
        {
            var quotes = await _context.Quotes.Include(c => c.Author).ToListAsync();

            return _mapper.Map<IEnumerable<QuoteViewModel>>(quotes);
        }

        public IEnumerable<AuthorViewModel> GetAuthors()
        {
            var authors = _context.Authors.ToList();

            //var authorsViewModel = authors.Select(c => new AuthorViewModel
            //{
            //    Id = c.Id,
            //    Name = c.Name,
            //    Description = c.Description,
            //    BirthDate = c.BirthDate,
            //    Photo = c.Photo,
            //    PhotoMimeType = c.PhotoMimeType
            //});

            //return authorsViewModel;

            //Automapper
            return _mapper.Map<IEnumerable<AuthorViewModel>>(authors);
        }

        public QuoteOfTheDayViewModel? GetQuoteOfTheDay()
        {
            var quotes = _context.Quotes.Include(c => c.Author).ToList();
            var random = new Random();

            var randomQuote = quotes[random.Next(0, quotes.Count)];  //6,1,3,9,7

            //return new QuoteOfTheDayViewModel
            //{
            //    QuoteText = randomQuote.QuoteText,
            //    AuthorName = randomQuote.Author?.Name ?? string.Empty,
            //    AuthorDescription = randomQuote.Author?.Description ?? string.Empty,
            //    AuthorBirthdate = randomQuote.Author?.BirthDate,
            //    AuthorImage = randomQuote.Author?.Photo,
            //    AuthorImageMimeType = randomQuote.Author?.PhotoMimeType
            //};

            return _mapper.Map<QuoteOfTheDayViewModel>(randomQuote);
        }
    }
}
