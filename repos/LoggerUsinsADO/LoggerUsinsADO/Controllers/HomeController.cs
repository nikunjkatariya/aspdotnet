using LoggerUsinsADO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Web;

namespace LoggerUsinsADO.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static int LogCount=0;
        [System.ComponentModel.Browsable(true)]
        public bool IsPostBack { get; }
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            if (IsPostBack)
            {
                _logger.Log(LogLevel.Information, (++LogCount).ToString());
            }
/*            Console.WriteLine("Logger:"+LogCount);*/
        }

        public IActionResult Index()
        {
            return View();
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