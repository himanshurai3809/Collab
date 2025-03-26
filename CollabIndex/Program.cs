using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CollabIndex;
using CollabIndex.Services.User;
using CollabIndex.Services.Wallet;
using CollabIndex.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) }); 
builder.Services.AddScoped<IApiClient, ApiClient>(); // Generic API client
builder.Services.AddScoped<WalletAuthService>();     // Wallet authentication
builder.Services.AddScoped<UserService>();

await builder.Build().RunAsync();
