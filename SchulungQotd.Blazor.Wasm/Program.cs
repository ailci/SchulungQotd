using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SchulungQotd.Blazor.Wasm;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//HttpClientFactory - NamedClient
builder.Services.AddHttpClient("qotdapi", options =>
{
    options.BaseAddress = new Uri("https://localhost:7256");
    options.DefaultRequestHeaders.Add("Accept", "application/json");
});

await builder.Build().RunAsync();
