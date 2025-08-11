using Frontend.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Frontend.Clients
{
    public class TruckClients(HttpClient _httpClient)
    {
        public BrandClients BrandClient;

        public async Task<List<AllTruck>> GetAllTrucksAsync() => await _httpClient.GetFromJsonAsync<List<AllTruck>>("trucks");

        public async Task AddTruck(TruckDetails truck) => await _httpClient.PostAsJsonAsync("trucks", truck);

        public async Task<TruckDetails> GetTruck(int? id) => await _httpClient.GetFromJsonAsync<TruckDetails>($"trucks/{id}") ?? throw new Exception("Don`t work");
        public async Task UpdateGame(TruckDetails updated) => _httpClient.PutAsJsonAsync($"trucks/{updated.Id}", updated);

        public async Task DeleteTruck(TruckDetails deletet) => _httpClient.DeleteAsync($"trucks/{deletet.Id}");
    }
}
    