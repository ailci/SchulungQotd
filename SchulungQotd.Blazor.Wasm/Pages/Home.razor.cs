using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using SchulungQotd.Blazor.Wasm.Model;

namespace SchulungQotd.Blazor.Wasm.Pages;
public partial class Home
{
    [Inject] public IHttpClientFactory HttpClientFactory { get; set; } = default!;
    public QuoteOfTheDayViewModel? QotdViewModel { get; set; }

    protected override async Task OnInitializedAsync()
    {
        //HttpClientFactory
        var client = HttpClientFactory.CreateClient("qotdapi");
        QotdViewModel = await client.GetFromJsonAsync<QuoteOfTheDayViewModel>("authors/quotes/qotd");
    }
}
