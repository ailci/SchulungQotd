using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using SchulungQotd.Blazor.Wasm.Model;
using SchulungQotd.Blazor.Wasm.Services;

namespace SchulungQotd.Blazor.Wasm.Pages;
public partial class Home
{
    [Inject] public IHttpClientFactory HttpClientFactory { get; set; } = default!;
    public QuoteOfTheDayViewModel? QotdViewModel { get; set; }
    [Inject] public IQotdApiService QotdApiService { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        //HttpClientFactory
        //var client = HttpClientFactory.CreateClient("qotdapi");
        //QotdViewModel = await client.GetFromJsonAsync<QuoteOfTheDayViewModel>("authors/quotes/qotd");

        // 2. Version als Service
        QotdViewModel = await QotdApiService.GetQuoteOfTheDayAsync();
    }
}
