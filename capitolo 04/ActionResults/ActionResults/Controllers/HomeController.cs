using ActionResults.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace ActionResults.Controllers
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

        object Load(int id) => null;

        public IActionResult Edit(int id)
        {
            if (HasPermission(User, id))
            {
                var model = Load(id);
                if (model == null)
                    return RedirectToAction("Index");
                return View(model);
            }
            
            return Unauthorized();
        }

        private bool HasPermission(ClaimsPrincipal user, int id)
        {
            return true;
        }

        public IActionResult TestOk()
        {
            return new OkResult();
        }

        public IActionResult TestOkObject()
        {
            return Ok("richiesta ok");
        }

        public IActionResult TestCreated()
        {
            return Created("http://www.antoniopelleriti.it/test", "test");
        }

        public IActionResult BadRequestResult()
        {
            
            return BadRequest("richiesta non valida");
        }

        public ForbidResult ForbidResult()
        {

            return Forbid();
        }


        public IActionResult RedirectToActionResult()
        {
            return RedirectToAction("Index", "Home", new {id = 123} );
        }

        public ActionResult DownloadFile()
        {
            return File("~/download/immagine.png", "image/png"/*,"immagine_1.png"*/);
        }
        public IActionResult PhysicalFileResult()
        {
            var path = "C:\\temp\\test.txt";
            return new PhysicalFileResult(path, "text/plain");
        }

        public IActionResult FileContentResult()
        {
            var path = "C:\\temp\\test.txt";
            var bytes=System.IO.File.ReadAllBytes(path);
            return new FileContentResult(bytes, " text/plain");

        }

        public PartialViewResult PartialViewTest()
        {
            return PartialView("_PartialViewTest");
        }

        public JsonResult JsonResultTest()
        {
            return Json(new {message="questo è il testo", error=false, data=DateTime.Now});
        }

        public JsonResult JsonResultTest2()
        {
            Todo t = new Todo("prova", "descrizione dell'attività", DateTime.Today.AddDays(10));
            return Json(t);
        }

        public IActionResult ContentResultTest()
        {
            return Content("prova");
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