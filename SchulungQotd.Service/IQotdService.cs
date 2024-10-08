using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchulungQotd.Service.Models;

namespace SchulungQotd.Service
{
    public interface IQotdService
    {
        QuoteOfTheDayViewModel? GetQuoteOfTheDay();
        IEnumerable<AuthorViewModel> GetAuthors();
        Task<AuthorViewModel?> AddAuthorAsync(AuthorCreateViewModel authorCreateViewModel);
    }
}
