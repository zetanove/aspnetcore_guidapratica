using TestEmailSender.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Services;

namespace TestEmailSender.Controllers
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
            IEmailSender sender = (IEmailSender)HttpContext.RequestServices.GetService(typeof(IEmailSender));
            sender.Send("email@test.it", "subject", "body");

            EmailSender sender2 = (EmailSender)HttpContext.RequestServices.GetService(typeof(EmailSender));
            sender2.Send("email@test.it", "subject", "body");
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