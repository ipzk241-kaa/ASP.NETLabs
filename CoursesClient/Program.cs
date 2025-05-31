using CoursesClient;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AuthService>();
builder.Services.AddScoped<AuthService>();


builder.Services.AddScoped(sp =>
    new HttpClient { BaseAddress = new Uri("https://localhost:7267/api/") });

await builder.Build().RunAsync();
