using Microsoft.AspNetCore.Mvc;
using TodoWebApp.Models;

namespace TodoWebApp.Controllers
{
    public class TodoController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = "Todo";
            return View();
        }

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
    }
}
