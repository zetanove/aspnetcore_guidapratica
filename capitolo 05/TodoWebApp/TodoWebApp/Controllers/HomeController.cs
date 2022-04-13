using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TodoWebApp.Models;

namespace TodoWebApp.Controllers
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
            ViewData["Messaggio"] = "Buongiorno";
            ViewBag.Data = DateTime.Today;

            TempData["Messaggio"] = "Buongiorno";

            return View();
        }

        public IActionResult Privacy()
        {
            string msg;

            if (TempData.ContainsKey("Messaggio"))
                msg = TempData["Messaggio"].ToString(); // restituisce il valore "Buongiorno" 

            TempData.Keep("Messaggio");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult PassData(string msg)
        {
            var d = msg;
            ViewData["Messaggio"] = d;
            return View("Index");
        }
    }
}