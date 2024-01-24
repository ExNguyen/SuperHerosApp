using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperherosApp.Data;
using SuperherosApp.Models;

namespace SuperherosApp.Controllers
{
    public class SuperherosController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SuperherosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SuperherosController
        public ActionResult Index()
        {
            //LINQ query to retrieve all rows from table
            var superheros = _context.Superheros.ToList();
            return View(superheros);
        }

        // GET: SuperherosController/Details/5
        public ActionResult Details(int id)
        {
            //LINQ query to find a specific row from table
            var specficHero = _context.Superheros.Where(s => s.Id == id);
            return View(specficHero);
        }

        // GET: SuperherosController/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: SuperherosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Superhero superhero)
        {
            try
            {
                _context.Superheros.Add(superhero);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperherosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SuperherosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Superhero superhero)
        {
            try
            {
                _context.Superheros.Update(superhero);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperherosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SuperherosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Superhero superhero)
        {
            try
            {
                _context.Superheros.Remove(superhero);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
