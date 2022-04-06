using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestMVCController.Models;

namespace TestMVCController.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult TestControllerContext()
        {            
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            return Content($"{controllerName}/{actionName}");
        }

        public IActionResult PrintRequestAddress()
        {
            var remote = this.HttpContext.Connection.RemoteIpAddress;
            var local = this.HttpContext.Connection.LocalIpAddress;
            return Content($"remote: {remote}, local: {local}");
        }

        public IActionResult PrintRequestInfo()
        {
            string requestInfo = Request.QueryString.ToString();
            return Content($"request: {requestInfo}");
        }

        public IActionResult CountInSession()
        {
            int count = (int?)HttpContext.Session.GetInt32("count") ?? 0;
            count++;
            HttpContext.Session.SetInt32("count", count);
            return Content($"count: {count}");
        }


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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