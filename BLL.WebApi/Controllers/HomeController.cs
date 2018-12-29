using System.Web.Mvc;

namespace BLL.WebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Redirect("swagger");
        }
    }
}
