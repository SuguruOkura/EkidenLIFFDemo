using BlazorApp.Client;
using LineDC.Liff;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
var appSettings = builder.Configuration.Get<AppSettings>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["API_Prefix"] ?? builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<ILiffClient>(serviceProvider =>
{
    return new LiffClient(appSettings.LiffId);
});
await builder.Build().RunAsync();
