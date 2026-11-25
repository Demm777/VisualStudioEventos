using Eventos3315298.Data;
using Eventos3315298.Migrations;
using Eventos3315298.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Eventos3315298.Controllers
{
    public class EntrenadorController : Controller
    {
        private readonly Eventos3315298Context _context;

        public EntrenadorController(Eventos3315298Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var entrenadores = await _context.Entrenadores.ToListAsync();
            return View(entrenadores);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Entrenador entrenador)
        {
            if (!ModelState.IsValid)
            {
                return View(entrenador);
            }
            try
            {
                _context.Entrenadores.Add(entrenador);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (DbUpdateException e)
            {
                if (e.InnerException is SqlException sqlE && (sqlE.Number == 2627 || sqlE.Number == 2601))
                {
                    if (sqlE.Message.Contains("IX_Entrenadores_Documento"))
                    {
                        ModelState.AddModelError(nameof(entrenador.Documento), "ya existe un Entrenador con este Documento");
                    }
                    else if (sqlE.Message.Contains("IX_Entrenadores_Celular"))
                    {
                        ModelState.AddModelError(nameof(entrenador.Celular), "ya existe un Entrenador con este Celular");
                    }
                    else if (sqlE.Message.Contains("IX_Entrenadores_Correo"))
                    {
                        ModelState.AddModelError(nameof(entrenador.Correo), "ya existe un Entrenador con este Correo");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Error general en la base de datos");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Ocurrio un error inesperado");
                }
            }

            return View(entrenador);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var entrenador = await _context.Entrenadores.FindAsync(id);
            if (entrenador == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(entrenador);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Entrenador entrenador)
        {
            if (!ModelState.IsValid)
            {
                return View(entrenador);
            }
            try
            {
                _context.Entrenadores.Update(entrenador);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (DbUpdateException e)
            {
                if (e.InnerException is SqlException sqlE && (sqlE.Number == 2627 || sqlE.Number == 2601))
                {
                    if (sqlE.Message.Contains("IX_Entrenadores_Documento"))
                    {
                        ModelState.AddModelError(nameof(entrenador.Documento), "ya existe un Entrenador con este Documento");
                    }
                    else if (sqlE.Message.Contains("IX_Entrenadores_Celular"))
                    {
                        ModelState.AddModelError(nameof(entrenador.Celular), "ya existe un Entrenador con este Celular");
                    }
                    else if (sqlE.Message.Contains("IX_Entrenadores_Correo"))
                    {
                        ModelState.AddModelError(nameof(entrenador.Correo), "ya existe un Entrenador con este Correo");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Error general en la base de datos");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Ocurrio un error inesperado");
                }
            }

            return View(entrenador);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            var entrenador = await _context.Entrenadores.FindAsync(id);
            if (entrenador == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(entrenador);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var entrenador = await _context.Entrenadores.FindAsync(id);
            if (entrenador==null)
            {
                TempData["Error"] = "Entrenador no existe";
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.Entrenadores.Remove(entrenador);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                if (e.InnerException is SqlException sqlE && sqlE.Number == 547)
                {
                    TempData["Error"] = "No se puede eliminar, Entrenador con registros asociados";
                }
                else
                {
                    TempData["Error"] = "Error inesperado, intente nuevamente";
                }
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
