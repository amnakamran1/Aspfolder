using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Session.Models;
using Microsoft.AspNetCore.Http;

namespace Session.Controllers
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
            HttpContext.Session.SetString("key", "Amna");
            TempData["SessionID"]=HttpContext.Session.Id;
            return View();
        }

        public IActionResult About()
        {
            if (HttpContext.Session.GetString("key") != null)
            {
                ViewBag.Data = HttpContext.Session.GetString("key").ToString();
            }

            return View();
        }
        public IActionResult Contact()
        {
            if (HttpContext.Session.GetString("key") != null)
            {
                ViewBag.Data = HttpContext.Session.GetString("key").ToString();
            }

            return View();
        }
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("key") != null)
            {
                 HttpContext.Session.Remove("key");
            }

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
