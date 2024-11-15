﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchulungQotd.Shared.Models;

namespace SchulungQotd.Service
{
    public interface IQotdService
    {
        Task<QuoteOfTheDayViewModel?> GetQuoteOfTheDayAsync();
        Task<IEnumerable<AuthorViewModel>?> GetAuthorsAsync(bool includeQuotes = false);
        Task<AuthorViewModel?> GetAuthorByIdAsync(Guid id);
        Task<AuthorViewModel?> DeleteAuthorAsync(Guid id);
        Task<AuthorViewModel?> AddAuthorAsync(AuthorForCreateViewModel authorForCreateViewModel);

        Task<IEnumerable<QuoteViewModel>?> GetQuotesAsync(bool includeAuthor = false);
    }
}
