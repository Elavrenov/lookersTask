using BLL.WebApi.Mappers;
using BLL.WebApi.Models.ViewModels;
using DAL.Interfaces.DTO;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace BLL.WebApi.Tests
{
    [TestFixture]
    public class MapperTests
    {
        private Car _mapperTester = new Car
        {
            Id = "11",
            Make = "Ford",
            Model = "Garrs",
            Colour = "Blue",
            Features = new CarFeatures()
            {
                AirConditioning = true,
                HeatingSeats = false,
                AudioPlayer = false,
                CupHolder = false
            }
        };

        [Test]
        public void WebApiMapperTest_ReturnTrueIfMappingWasMade()
        {
            var carView = Mapper.ToCarViewModel(_mapperTester);

            if (IsTrueMapper(carView, _mapperTester))
            {
                Assert.Pass();
            }

            Assert.Fail();
        }

        private bool IsTrueMapper(CarViewModel viewModel, Car carModel)
        {
            return viewModel.Id == carModel.Id
                   && (viewModel.Colour == carModel.Colour
                       && (viewModel.Make == carModel.Make
                           && (viewModel.Model == carModel.Model
                               && IsTrueFeatureModel(viewModel.Features, carModel.Features))));
        }

        private bool IsTrueFeatureModel(CarFeaturesViewModel viewModel, CarFeatures carModel)
        {
            return viewModel.AirConditioning == carModel.AirConditioning
                   && (viewModel.AudioPlayer == carModel.AudioPlayer
                       && (viewModel.CupHolder == carModel.CupHolder
                           && viewModel.HeatingSeats == carModel.HeatingSeats));
        }
    }
}
