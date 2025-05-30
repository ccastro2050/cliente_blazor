using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using cliente_blazor;
using cliente_blazor.Servicios; // Incluir el espacio de nombres del servicio

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Definir la URL base de la API según el entorno
string urlApi;

#if DEBUG
    // URL de la API local en desarrollo
    urlApi = "https://localhost:5016/";
#else
    // URL pública de la API publicada en MonsterASP
    urlApi = "https://apipersonas.runasp.net/";
#endif

// Registrar HttpClient con la URL correspondiente
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(urlApi)
});

// Registrar el servicio de persona
builder.Services.AddScoped<ServicioPersona>();

await builder.Build().RunAsync();
