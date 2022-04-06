using Microsoft.AspNetCore.Mvc;
using Microsoft.Docs.Samples;

namespace RoutingTestApp.Controllers
{
    public class TestAttrController: Controller
    {
        [Route("")]
        [Route("Test")]
        [Route("Test/Index")]
        [Route("Test/Index/{id?}")]
        public IActionResult Index(int? id)
        {
            return Ok("Index " + id);
        }

        [Route("Test/About")]
        [Route("Test/About/{id?}")]
        public IActionResult About(int? id)
        {
            return Ok("About " + id);
        }


        [Route("[controller]/[action]")]
        public IActionResult Details(int? id)
        {
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

            return Content(controllerName+"/" + actionName+"/" + id);
        }
    }

    [Route("Anag")]
    public class AnagraficheController: Controller
    {
        [Route("Dettagli/{id?}")]
        public IActionResult Details(int? id)
        {
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

            return Content(controllerName + "/" + actionName + "/" + id);
        }
    }


    [Route("AreaRiservata/[controller]/[action]")]
    public class Anagrafiche2Controller : Controller
    {
        [Route("{id?}")]
        public IActionResult Edit(int? id)
        {
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

            return Content(controllerName + "/" + actionName + "/" + id);
        }
    }

}
