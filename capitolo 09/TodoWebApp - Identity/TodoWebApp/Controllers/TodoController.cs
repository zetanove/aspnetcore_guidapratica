using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoWebApp.Models;

namespace TodoWebApp.Controllers
{
    [Authorize]
    public class TodoController : Controller
    {
        TodoDbContext db;

        public TodoController(TodoDbContext context)
        {
            db = context;
        }

        public IActionResult Categorie() => View(db.Categorie.ToList());


        public IActionResult TestSql()
        {
            var query=db.Categorie.FromSqlRaw("SELECT * FROM Categorie");
            var list = query.ToList();

            string nome = "Generale";
            query = db.Categorie.FromSqlRaw("SELECT * FROM Categorie WHERE NomeCategoria={0}", nome);

            return Json(list);
        }

        // GET: TodoController
        public ActionResult Index()
        {
            var todos = db.Todos.ToList();

            todos = db.Todos.Where(t=> t.Categoria.NomeCategoria.StartsWith("A")).ToList();

            return View(todos);
        }

        
        // GET: TodoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TodoController/Create
        public ActionResult Create()
        {
            return View();
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

        // GET: TodoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
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

        public IActionResult CreateCategoria() => View(new Categoria());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategoria(Categoria categoria)
        {

            try
            {
                db.Categorie.Add(categoria);
                db.SaveChanges();
            }
            catch
            {
                return View(categoria);
            }
            return RedirectToAction(nameof(Categorie));
        }

        public IActionResult EditCategoria(int id)
        {
            var categoria = db.Categorie.SingleOrDefault(c => c.IDCategoria == id);

            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCategoria(Categoria categoria)
        {
            try
            {
                db.Update(categoria);
                int count = await db.SaveChangesAsync();
                TempData["save"] = categoria.NomeCategoria;
            }
            catch
            {
                return View(categoria);
            }
            return RedirectToAction(nameof(Categorie));
        }

        public JsonResult DeleteCategoria(int id)
        {
            var categoria = db.Categorie.SingleOrDefault(c => c.IDCategoria == id);
            db.Remove(categoria);
            db.SaveChanges();
            return Json(new { message = "Categoria eliminata" });
        }
    }
}
