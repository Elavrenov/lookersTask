namespace BLL.WebApi.Models.ViewModels
{
    public class CarViewModel
    {
        public string Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string Colour { get; set; }

        public CarFeaturesViewModel Features { get; set; }
    }
}