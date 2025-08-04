namespace Frontend.Models
{
    public class AllTruck
    {
        public int Id { get; set; }

        public required string Model { get; set; }

        public required string Brand { get; set; }

        public int maxSpeed { get; set; }

        public int maxLiftingCapacity { get; set; }

        public int Price { get; set; }

        public DateOnly ReleaseDate { get; set; }
    }
}
