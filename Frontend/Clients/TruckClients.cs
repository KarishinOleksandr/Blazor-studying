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
                    Brand = "Scania",
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
            BrandDetails brand = await GetBrandDetailsAsync(truck.BrandId);

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
        private static async Task<BrandDetails> GetBrandDetailsAsync(string? id)
        {
            await GetAllBrand();

            ArgumentException.ThrowIfNullOrWhiteSpace(id);
            return brands.Single(b => b.Id == int.Parse(id));
        }

        public static async Task<TruckDetails> GetTruck(int? id)
        {
            var truck = truckslist.Find(x => x.Id == id);
            await GetAllBrand();
            BrandDetails brand = brands.Single(x => string.Equals(x.BrandName, truck.Brand, StringComparison.OrdinalIgnoreCase));

            var truckdetails = new TruckDetails()
            {
                Id = truck.Id,
                Model = truck.Model,
                BrandId = brand.Id.ToString(),
                maxSpeed = truck.maxSpeed,
                maxLiftingCapacity= truck.maxLiftingCapacity,
                Price = truck.Price,
                ReleaseDate = truck.ReleaseDate,
            };
            return truckdetails;
        }

        public static async Task UpdateGame(TruckDetails updated)
        {
            BrandDetails brand = await GetBrandDetailsAsync(updated.BrandId);    
            AllTruck truck = truckslist.Find(x => x.Id == updated.Id);

            truck.Model = updated.Model;
            truck.Brand = brand.BrandName;
            truck.maxSpeed = updated.maxSpeed;
            truck.maxLiftingCapacity = updated.maxLiftingCapacity;
            truck.Price = updated.Price;
            truck.ReleaseDate = updated.ReleaseDate;

        }
    }
}
    