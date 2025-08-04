using Frontend.Models;

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
                    ReleaseDate = new DateOnly(12,09,25)
                },

                new()
                {
                    Id = 2,
                    Model = "2",
                    Brand = "Mercedes",
                    maxSpeed = 150,
                    maxLiftingCapacity = 40,
                    Price = 45000,
                    ReleaseDate = new DateOnly(13,09,25)
                },

                new()
                {
                    Id = 3,
                    Model = "3",
                    Brand = "Mercedes",
                    maxSpeed = 160,
                    maxLiftingCapacity = 40,
                    Price = 50000,
                    ReleaseDate = new DateOnly(15,09,25)
                }
        ];

        public static Task<List<AllTruck>> GetAllTrucksAsync()
        {
            return Task.FromResult(truckslist.ToList());
        }
    }
}
    