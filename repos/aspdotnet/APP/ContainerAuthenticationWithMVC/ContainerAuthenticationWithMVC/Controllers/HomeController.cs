using ContainerAuthenticationWithMVC.Data;
using ContainerAuthenticationWithMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ContainerAuthenticationWithMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index([Bind("Username", "Password", "Usertype", "Token")] User user)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Containers");
            }
            return View(user);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}