using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using cliente_blazor;
using cliente_blazor.Servicios;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

string urlApi;

#if DEBUG
    urlApi = "http://localhost:5016/";
#else
    urlApi = "http://apipersonas.runasp.net/"; // sin 's' porque en MonsterASP no está habilitado HTTPS
#endif

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(urlApi)
});

builder.Services.AddScoped<ServicioPersona>();

await builder.Build().RunAsync();
