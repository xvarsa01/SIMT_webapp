using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using Simt.Web.App;
using Simt.Web.BL;
using Simt.Web.BL.Facades;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddRadzenComponents();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IPlatformApiClient, PlatformApiClient>();
builder.Services.AddScoped<PlatformFacade>();

builder.Services.AddScoped<IStopApiClient, StopApiClient>();
builder.Services.AddScoped<StopFacade>();

builder.Services.AddScoped<IRouteApiClient, RouteApiClient>();
builder.Services.AddScoped<RouteFacade>();

builder.Services.AddScoped<ILineApiClient, LineApiClient>();
builder.Services.AddScoped<LineFacade>();

builder.Services.AddScoped<IMapApiClient, MapApiClient>();
builder.Services.AddScoped<MapFacade>();

builder.Services.AddScoped<IPlayerApiClient, PlayerApiClient>();
builder.Services.AddScoped<PlayerFacade>();

builder.Services.AddScoped<IVehicleApiClient, VehicleApiClient>();
builder.Services.AddScoped<VehicleFacade>();

builder.Services.AddScoped<IServiceApiClient, ServiceApiClient>();
builder.Services.AddScoped<ServiceFacade>();

await builder.Build().RunAsync();