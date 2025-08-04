using Frontend.Models;
using System.Threading.Tasks;

namespace Frontend.Clients
{
    public class TruckClients
    {
        private static readonly List<AllTruck> truckslist =
        [
                new()
                {
                    Id = 1,
                    Model = "1",
                    Brand = "Mercedes",
                    maxSpeed = 120,
                    maxLiftingCapacity = 40,
                    Price = 40000,
                    ReleaseDate = new DateOnly(2025,03,13)
                },

                new()
                {
                    Id = 2,
                    Model = "2",
                    Brand = "Mercedes",
                    maxSpeed = 150,
                    maxLiftingCapacity = 40,
                    Price = 45000,
                    ReleaseDate = new DateOnly(2004,08,6)
                },

                new()
                {
                    Id = 3,
                    Model = "3",
                    Brand = "Mercedes",
                    maxSpeed = 160,
                    maxLiftingCapacity = 40,
                    Price = 50000,
                    ReleaseDate = new DateOnly(2000,04,19)
                }
        ];


        static List<BrandDetails> brands = new List<BrandDetails>();
        

        public static Task<List<AllTruck>> GetAllTrucksAsync()
        {
            return Task.FromResult(truckslist.ToList());
        }

        public static async Task<List<BrandDetails>> GetAllBrand()
        {
            brands = await BrandClients.GetAllBrandAsync();
            return brands;
        }

        public static async Task AddTruck(TruckDetails truck)
        {
            await GetAllBrand();

            ArgumentException.ThrowIfNullOrWhiteSpace(truck.BrandId);
            var brand = brands.Single(b => b.Id == int.Parse(truck.BrandId));

            var AllTruck = new AllTruck
            {
                Id = truckslist.Count + 1,
                Model = truck.Model,
                Brand = brand.BrandName,
                maxSpeed = truck.maxSpeed,
                maxLiftingCapacity = truck.maxLiftingCapacity,
                Price = truck.Price,
                ReleaseDate = truck.ReleaseDate,

            };

            truckslist.Add(AllTruck);
        }
    }
}
    