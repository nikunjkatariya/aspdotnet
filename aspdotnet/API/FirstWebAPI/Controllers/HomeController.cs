using Microsoft.AspNetCore.Mvc;

namespace FirstWebAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
