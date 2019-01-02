using DAL.CosmosDb.Entities;
using DAL.CosmosDb.Mapper;
using DAL.Interfaces.DTO;
using NUnit.Framework;

namespace BLL.WebApi.Tests
{
    [TestFixture()]
    public class DalMappingTests
    {
        private Item _mapperTester = new Item
        {
            Id = "11",
            Make = "Ford",
            Model = "Garrs",
            Colour = "Blue",
            Features = new ItemFeatures()
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
            var model = Mapper.ToCarDto(_mapperTester);

            if (IsTrueMapper(model, _mapperTester))
            {
                Assert.Pass();
            }

            Assert.Fail();
        }
        private bool IsTrueMapper(Car carModel, Item itemModel)
        {
            return carModel.Id == itemModel.Id
                   && (carModel.Colour == itemModel.Colour
                       && (carModel.Make == itemModel.Make
                           && (carModel.Model == itemModel.Model
                               && IsTrueFeatureModel(carModel.Features, itemModel.Features))));
        }

        private bool IsTrueFeatureModel(CarFeatures carFeatures, ItemFeatures itemFeatures)
        {
            return carFeatures.AirConditioning == itemFeatures.AirConditioning
                   && (carFeatures.AudioPlayer == itemFeatures.AudioPlayer
                       && (carFeatures.CupHolder == itemFeatures.CupHolder
                           && carFeatures.HeatingSeats == itemFeatures.HeatingSeats));
        }
    }
}