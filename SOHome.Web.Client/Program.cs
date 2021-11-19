using Blazored.LocalStorage;

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using SOHome.Common.Interfaces;
using SOHome.Domain.Providers;
using SOHome.Domain.Services;
using SOHome.Web.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Supply HttpClient instances that include access tokens when making requests to the server project
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient("SOHome.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("SOHome.ServerAPI"));

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore(options => { });
builder.Services.AddScoped<IAuthService, APIAuthService>();
builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
builder.Services.AddBlazoredLocalStorage();


await builder.Build().RunAsync();
