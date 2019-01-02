using BLL.WebApi.Models.ViewModels;
using DAL.CosmosDb.Entities;
using DAL.CosmosDb.Mapper;
using DAL.Interfaces.DTO;
using NUnit.Framework;
using NUnit.Framework.Internal;

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

            if (isTrueMapper(model, _mapperTester))
            {
                Assert.Pass();
            }

            Assert.Fail();
        }
        private bool isTrueMapper(Car carModel, Item itemModel)
        {
            if (carModel.Id != itemModel.Id) return false;
            if (carModel.Colour != itemModel.Colour) return false;
            if (carModel.Make != itemModel.Make) return false;
            if (carModel.Model != itemModel.Model) return false;
            return isTrueFeatureModel(carModel.Features, itemModel.Features);
        }

        private bool isTrueFeatureModel(CarFeatures carFeatures, ItemFeatures itemFeatures)
        {
            if (carFeatures.AirConditioning != itemFeatures.AirConditioning) return false;
            if (carFeatures.AudioPlayer != itemFeatures.AudioPlayer) return false;
            if (carFeatures.CupHolder != itemFeatures.CupHolder) return false;
            return carFeatures.HeatingSeats == itemFeatures.HeatingSeats;
        }
    }
}