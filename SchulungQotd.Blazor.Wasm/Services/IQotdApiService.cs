using SchulungQotd.Blazor.Wasm.Model;

namespace SchulungQotd.Blazor.Wasm.Services
{
    public interface IQotdApiService
    {
        Task<QuoteOfTheDayViewModel?> GetQuoteOfTheDayAsync();
    }
}
