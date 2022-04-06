using Microsoft.AspNetCore.Mvc;

namespace RoutingTestApp.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Article()
        {
            return View(Request.RouteValues["article"]);
        }
    }
}
