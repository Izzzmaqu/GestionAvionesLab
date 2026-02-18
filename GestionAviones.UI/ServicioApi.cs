using GestionAviones.Model;
using System.Text;
using System.Text.Json;

namespace GestionAviones.UI
{
    public class ServicioApi
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "api/ServicioDeAviones";

        public ServicioApi(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("AvionesApi");
        }

        public async Task<IEnumerable<Avion>> ObtengaLaListaAsync()
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/ObtengaLaLista");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Avion>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<Avion>> ObtengaLaListaDeActivosAsync()
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/ObtengaLaListaDeActivos");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Avion>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<Avion>> ObtengaLaListaDeInActivosAsync()
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/ObtengaLaListaDeInActivos");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Avion>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Avion?> ObtengaElAvionAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/ObtengaElAvion?id={id}");
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound) return null;
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Avion>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task AgregarAsync(Avion avion)
        {
            var json = JsonSerializer.Serialize(avion);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{BaseUrl}/Agregue", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task EditeElAvionAsync(Avion avion)
        {
            var json = JsonSerializer.Serialize(avion);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{BaseUrl}/EditeElAvion", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task ActivarAsync(int id)
        {
            var response = await _httpClient.PutAsync($"{BaseUrl}/Active?id={id}", null);
            response.EnsureSuccessStatusCode();
        }

        public async Task DesActivarAsync(int id)
        {
            var response = await _httpClient.PutAsync($"{BaseUrl}/DesActive?id={id}", null);
            response.EnsureSuccessStatusCode();
        }
    }
}
