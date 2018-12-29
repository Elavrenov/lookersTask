using BLL.WebApi.Models.ViewModels;
using DAL.Interfaces.DTO;

namespace BLL.WebApi.Mappers
{
    public static class Mapper
    {
        public static CarViewModel ToCarViewModel(Car item) => new CarViewModel()
        {
            Id = item.Id,
            Model = item.Model,
            Colour = item.Colour,
            Make = item.Make,
            Features = ToCarFeatureViewModel(item.Features)
        };

        private static CarFeaturesViewModel ToCarFeatureViewModel(CarFeatures itemFeatures) => new CarFeaturesViewModel()
        {
            AirConditioning = itemFeatures.AirConditioning,
            HeatingSeats = itemFeatures.HeatingSeats,
            AudioPlayer = itemFeatures.AudioPlayer,
            CupHolder = itemFeatures.CupHolder
        };
    }
}