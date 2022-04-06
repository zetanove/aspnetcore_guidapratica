using Microsoft.AspNetCore.Mvc;

namespace TodoWebApp.Controllers
{
    public class TodoController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = "Todo";
            return View();
        }
    }
}
