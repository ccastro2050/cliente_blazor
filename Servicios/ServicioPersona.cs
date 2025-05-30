using System.Net.Http.Json;
using cliente_blazor.Modelos;

namespace cliente_blazor.Servicios
{
    public class ServicioPersona
    {
        private readonly HttpClient clienteHttp;

        public ServicioPersona(HttpClient clienteHttp)
        {
            this.clienteHttp = clienteHttp;
        }

        // Obtener lista de personas desde la API
        public async Task<List<Persona>?> ObtenerPersonasAsync()
        {
            return await clienteHttp.GetFromJsonAsync<List<Persona>>("api/persona");
        }

        // Insertar persona en la API
        public async Task InsertarPersonaAsync(Persona persona)
        {
            await clienteHttp.PostAsJsonAsync("api/persona", persona);
        }
    }
}
