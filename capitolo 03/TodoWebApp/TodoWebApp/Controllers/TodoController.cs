using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
=======
using TodoWebApp.Models;
>>>>>>> 0e44c351cf42a920290473a45126986ce73f69ce

namespace TodoWebApp.Controllers
{
    public class TodoController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = "Todo";
            return View();
        }
<<<<<<< HEAD
=======

        public IActionResult Details(int id)
        {
            Todo model = new Todo()
            {
                Id = id,
                Titolo = "La mia prima attività",
                Descrizione = "è una prova",
                Promemoria = DateTime.Now,
                Completato = false
            };

            return View(model);
        }
>>>>>>> 0e44c351cf42a920290473a45126986ce73f69ce
    }
}
