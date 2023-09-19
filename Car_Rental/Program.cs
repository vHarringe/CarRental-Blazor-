using Car_Business.Classes;
using Car_Data;
using Car_Rental;
using Car_Rental.Data.Classes;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<BookingProcessor>();
builder.Services.AddSingleton<IData, CollectionData>();
builder.Services.AddSingleton<ISingletonStartup, AppStart>();





await builder.Build().RunAsync();
