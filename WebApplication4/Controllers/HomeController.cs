using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult index()
        {
            return View();
        }

        public IActionResult privacy()
        {
            return View();
        }

        public IActionResult Form()
        {
            return View();
        }



        public ActionResult Index1()
        {
            // Store the list of Countries in ViewBag.  
            ViewBag.Countries = new List<string>()
    {
        "India",
        "US",
        "UK",
        "Canada"
    };

            // Finally return a view
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}