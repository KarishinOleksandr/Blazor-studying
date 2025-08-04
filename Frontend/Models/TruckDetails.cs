namespace Frontend.Models
{
    public class TruckDetails
    {
        public int Id { get; set; }

        public required string Model { get; set; }

        public string? BrandId { get; set; }

        public int maxSpeed { get; set; }

        public int maxLiftingCapacity { get; set; }

        public int Price { get; set; }

        public DateOnly ReleaseDate { get; set; }
    }
}
    