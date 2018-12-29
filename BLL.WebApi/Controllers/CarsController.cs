using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using BLL.WebApi.Mappers;
using BLL.WebApi.Models.ViewModels;
using DAL.Interfaces.Interfaces;

namespace BLL.WebApi.Controllers
{
    public class CarsController : ApiController
    {
        private readonly IRepository _repository;

        public CarsController(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IHttpActionResult> GetAllItemsAsync()
        {
            var items = await _repository.GetAllItemsAsync();

            IList<CarViewModel> cars = new List<CarViewModel>();

            foreach (var item in items)
            {
                cars.Add(Mapper.ToCarViewModel(item));
            }

            if (cars.Count == 0)
            {
                return NotFound();
            }

            return Ok(cars);
        }

        public async Task<IHttpActionResult> GetItemById(int id)
        {
            var item = await _repository.GetItemByIdAsync($"{id}");

            if (item == null)
            {
                return NotFound();
            }

            var car = Mapper.ToCarViewModel(item);

            return Ok(car);
        }
    }
}

