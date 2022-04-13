using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoWebApp.Models;

namespace TodoWebApp.Controllers
{
    public class TodoController : Controller
    {

        List<Todo> listTodos;

        public TodoController()
        {
            if (listTodos == null)
            {
                listTodos = new();
                for (int i = 0; i < 10; i++)
                {
                    listTodos.Add(new() { Id = i, 
                        Descrizione = "Descrizione dell'attività " + i, 
                        Titolo = "Titolo " + i,
                        Promemoria = DateTime.Today.AddDays(1),
                    });
                }
            }
        }

        // GET: TodoController
        public ActionResult Index()
        {
            return View(listTodos);
        }

        public ActionResult List()
        {
            return View(listTodos);
        }

        // GET: TodoController/Details/5
        public ActionResult Details(int id)
        {
            var model= listTodos.Find(t => t.Id == id);
            if (model == null)
            {
                return NotFound("Attività con id=" + id +" non trovata");
            }
            return View(model);
        }

        // GET: TodoController/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: TodoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TodoController/Edit/id
        public ActionResult Edit(int id)
        {
            var model = listTodos.Find(t => t.Id == id);
            if (model == null)
            {
                TempData["ErrorMessage"] = $"Attività {id} non trovata";
                return RedirectToAction(nameof(List));
            }
            return View(model);
        }

        // POST: TodoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TodoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TodoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
