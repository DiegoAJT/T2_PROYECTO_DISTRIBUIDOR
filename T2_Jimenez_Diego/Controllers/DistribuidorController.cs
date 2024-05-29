using Microsoft.AspNetCore.Mvc;
using T2_Jimenez_Diego.Datos;
using T2_Jimenez_Diego.Models;

namespace T2_Jimenez_Diego.Controllers
{
    public class DistribuidorController : Controller
    {
        private readonly ApplicationDbContext _db;
        public DistribuidorController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Distribuidor> listaDis = _db.Distribuidor;
            return View(listaDis);
        }

        //Funciones del sistema CRUD
        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        public IActionResult Crear() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Distribuidor dis)
        {
            if (ModelState.IsValid) 
            { 
                _db.Distribuidor.Add(dis);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(dis);
        }

        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        public IActionResult Actualizar(int? id)
        { 
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Distribuidor.Find(id);

            if(obj == null)
            {
                return NotFound();
            }
            return View(obj); 
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Actualizar(Distribuidor dis)
        {
            if (ModelState.IsValid)
            {
                _db.Distribuidor.Update(dis);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(dis);
        }

        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        public IActionResult Eliminar(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Distribuidor.Find(id);

            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(Distribuidor dis)
        {
            if (dis == null) 
            { 
                return NotFound();
            }
            _db.Distribuidor.Remove(dis);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
