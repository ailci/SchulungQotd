using Microsoft.AspNetCore.Components;
using SchulungQotd.Service;
using SchulungQotd.Shared.Models;

namespace SchulungQotd.BlazorServer.Components.Pages;
public partial class Home
{
    [Inject] public IQotdService QotdService { get; set; } = default!;
    public QuoteOfTheDayViewModel? QotdViewModel { get; set; }

    protected override async Task OnInitializedAsync()
    {
        //QotdViewModel = await QotdService.GetQuoteOfTheDayAsync();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            QotdViewModel = await QotdService.GetQuoteOfTheDayAsync();
            StateHasChanged();
        }
    }
}
