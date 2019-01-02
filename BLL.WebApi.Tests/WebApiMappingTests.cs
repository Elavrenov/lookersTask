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

            if (isTrueMapper(carView,_mapperTester))
            {
                Assert.Pass();
            }
            
            Assert.Fail();
        }

        private bool isTrueMapper(CarViewModel viewModel, Car carModel)
        {
            if (viewModel.Id != carModel.Id) return false;
            if (viewModel.Colour != carModel.Colour) return false;
            if (viewModel.Make != carModel.Make) return false;
            if (viewModel.Model != carModel.Model) return false;
            return isTrueFeatureModel(viewModel.Features, carModel.Features);
        }

        private bool isTrueFeatureModel(CarFeaturesViewModel viewModel, CarFeatures carModel)
        {
            if (viewModel.AirConditioning != carModel.AirConditioning) return false;
            if (viewModel.AudioPlayer != carModel.AudioPlayer) return false;
            if (viewModel.CupHolder != carModel.CupHolder) return false;
            return viewModel.HeatingSeats == carModel.HeatingSeats;
        }
    }
}
