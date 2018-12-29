using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using BLL.WebApi.Models.ViewModels;
using PL.MVC.WebClient;

namespace PL.MVC.Controllers
{
    public class CarsController : Controller
    {
        private readonly HttpClient _client = WebApiClient.Instance;
        private const string GetAllCars = "cars";
        private const string DefaultErrorMsg = "Server error. Please contact administrator.";
        public async Task<ActionResult> Index()
        {
            IEnumerable<CarViewModel> cars;

            var responseTask = await _client.GetAsync(GetAllCars);

            if (responseTask.IsSuccessStatusCode)
            {
                var readTask = await responseTask.Content.ReadAsAsync<IList<CarViewModel>>();
                cars = readTask;
            }
            else
            {
                cars = Enumerable.Empty<CarViewModel>();
                ModelState.AddModelError(string.Empty, DefaultErrorMsg);
            }

            return View(cars);
        }

        public async Task<ActionResult> FeatureResult(string id)
        {
            CarViewModel car;

            var responseTask = await _client.GetAsync($"{GetAllCars}/{id}");

            if (responseTask.IsSuccessStatusCode)
            {
                var readTask = await responseTask.Content.ReadAsAsync<CarViewModel>();
                car = readTask;
            }
            else
            {
                car = new CarViewModel();
                ModelState.AddModelError(string.Empty, DefaultErrorMsg);
            }

            return PartialView(car.Features);
        }
    }
}