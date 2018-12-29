namespace DAL.Interfaces.DTO
{
    public class Car
    {
        public string Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string Colour { get; set; }

        public CarFeatures Features { get; set; }
    }
}