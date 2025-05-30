using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using cliente_blazor;
using cliente_blazor.Servicios; // Incluir el espacio de nombres del servicio

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Registrar HttpClient con la URL de la API
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:5016/") // Reemplazar por la URL real de la API
});

// Registrar el servicio de persona
builder.Services.AddScoped<ServicioPersona>();

await builder.Build().RunAsync();
