using Frontend.Models;

namespace Frontend.Clients
{
    public class BrandClients(HttpClient httpClient)
    {
        public Task<List<BrandDetails>> GetAllBrandAsync() => httpClient.GetFromJsonAsync<List<BrandDetails>>("brands");
    }
}
