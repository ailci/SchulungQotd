using Microsoft.AspNetCore.Components;
using SchulungQotd.Service;
using SchulungQotd.Shared.Models;

namespace SchulungQotd.BlazorServer.Components.Pages;
public partial class Home : IDisposable
{
    [Inject] public IQotdService QotdService { get; set; } = default!;
    public QuoteOfTheDayViewModel? QotdViewModel { get; set; }
    [Inject] public PersistentComponentState ApplicationState { get; set; } = default!;
    private PersistingComponentStateSubscription _persistingComponentStateSubscription;

    protected override async Task OnInitializedAsync()
    {
        _persistingComponentStateSubscription = ApplicationState.RegisterOnPersisting(PersistData);

        var statedLoaded = ApplicationState.TryTakeFromJson<QuoteOfTheDayViewModel>("qotd", out var qotd);
        QotdViewModel = statedLoaded && qotd is not null ? qotd : await QotdService.GetQuoteOfTheDayAsync();

        //QotdViewModel = await QotdService.GetQuoteOfTheDayAsync();
    }

    private Task PersistData()
    {
        ApplicationState.PersistAsJson("qotd", QotdViewModel);
        return Task.CompletedTask;
    }

    //protected override async Task OnAfterRenderAsync(bool firstRender)
    //{
    //    if (firstRender)
    //    {
    //        QotdViewModel = await QotdService.GetQuoteOfTheDayAsync();
    //        StateHasChanged();
    //    }
    //}

    public void Dispose()
    {
        _persistingComponentStateSubscription.Dispose();
    }
}
