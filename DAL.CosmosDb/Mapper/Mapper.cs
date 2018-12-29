using System.Collections.Generic;
using DAL.CosmosDb.Entities;
using DAL.Interfaces.DTO;

namespace DAL.CosmosDb.Mapper
{
    public static class Mapper
    {
        public static IEnumerable<Car> ToEnumerableCarDto(IEnumerable<Item> items)
        {
            var cars = new List<Car>();

            foreach (var item in items)
            {
                cars.Add(ToCarDto(item));
            }

            return cars;
        }
        public static Car ToCarDto(Item item) => new Car()
        {
            Id = item.Id,
            Model = item.Model,
            Colour = item.Colour,
            Make = item.Make,
            Features = ToCarFeatureDto(item.Features)
        };

        private static CarFeatures ToCarFeatureDto(ItemFeatures itemFeatures) => new CarFeatures()
        {
            AirConditioning = itemFeatures.AirConditioning,
            HeatingSeats = itemFeatures.HeatingSeats,
            AudioPlayer = itemFeatures.AudioPlayer,
            CupHolder = itemFeatures.CupHolder
        };
    }
}