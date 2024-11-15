using System.Net.Http.Json;
using SchulungQotd.Blazor.Wasm.Model;

namespace SchulungQotd.Blazor.Wasm.Services
{
    public class QotdApiService(HttpClient client) : IQotdApiService
    {
        private const string QotdUri = "authors/quotes/qotd";

        public Task<QuoteOfTheDayViewModel?> GetQuoteOfTheDayAsync()
        {
            return client.GetFromJsonAsync<QuoteOfTheDayViewModel>(QotdUri);
        }
    }
}
