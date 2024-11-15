using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Options;
using SchulungQotd.Blazor.Wasm;
using SchulungQotd.Blazor.Wasm.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//OptionsPattern
builder.Services.Configure<QotdWasmAppSettings>(builder.Configuration.GetSection("QotdWasmAppSettings"));

//HttpClientFactory - NamedClient
//builder.Services.AddHttpClient("qotdapi", (sp,options) =>
//{
//    //var internaluri = builder.Configuration["QotdWasmAppSettings:InternalQotdServiceUri"];
//    var apiConfiguration = sp.GetRequiredService<IOptions<QotdWasmAppSettings>>().Value;
//    options.BaseAddress = new Uri(apiConfiguration.InternalQotdServiceUri);
//    options.DefaultRequestHeaders.Add("Accept", "application/json");
//});

builder.Services.AddScoped<IQotdApiService, QotdApiService>();

//TypedClient
builder.Services.AddHttpClient<IQotdApiService, QotdApiService>((sp, options) =>
{
    var apiConfiguration = sp.GetRequiredService<IOptions<QotdWasmAppSettings>>().Value;
    options.BaseAddress = new Uri(apiConfiguration.InternalQotdServiceUri);
    options.DefaultRequestHeaders.Add("Accept", "application/json");
});

await builder.Build().RunAsync();
