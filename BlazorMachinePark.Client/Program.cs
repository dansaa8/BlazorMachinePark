using Blazored.LocalStorage;
using BlazorMachinePark.Client;
using BlazorMachinePark.Contracts.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<IMachineService, ClientMachineService>();

await builder.Build().RunAsync();
