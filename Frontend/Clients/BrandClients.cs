using Frontend.Models;

namespace Frontend.Clients
{
    public class BrandClients
    {
        private static readonly List<BrandDetails> brandlist =
        [
            new()
            {
                Id = 1,
                BrandName = "Volvo"
            },
            new()
            {
                Id = 2,
                BrandName = "Mercedes"
            },
            new()
            {
                Id = 3,
                BrandName = "Scania"
            }
        ];

        public static Task<List<BrandDetails>> GetAllBrandAsync()
        {
            return Task.FromResult(brandlist.ToList());
        }
    }
}
