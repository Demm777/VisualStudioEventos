using Eventos3315298.Data;
using Eventos3315298.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Eventos3315298.Controllers
{
    public class EquipoController : Controller
    {
        private readonly Eventos3315298Context _context;

        public EquipoController(Eventos3315298Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Equipo> equipos = await _context.Equipos
                .Include(e => e.Entrenador)
                .ToListAsync();
            return View(equipos);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.EntrenadorId = new SelectList(await _context.Entrenadores.ToListAsync(),
                                                    "EntrenadorId", "NombreCompleto");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Equipo equipo)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.EntrenadorId = new SelectList(await _context.Entrenadores.ToListAsync(),
                                                    "EntrenadorId", "NombreCompleto", equipo.EntrenadorId);
                return View(equipo);
            }
            try
            {
                _context.Equipos.Add(equipo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (DbUpdateException e)
            {
                if (e.InnerException is SqlException sqlE && (sqlE.Number == 2627 || sqlE.Number == 2601))
                {
                    if (sqlE.Message.Contains("IX_Equipos_Nombre"))
                    {
                        ModelState.AddModelError(nameof(equipo.Nombre), "ya existe un Equipo con este Nombre");
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
            ViewBag.EntrenadorId = new SelectList(await _context.Entrenadores.ToListAsync(),
                                                    "EntrenadorId", "NombreCompleto", equipo.EntrenadorId);
            return View(equipo);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo == null)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.EntrenadorId = new SelectList(await _context.Entrenadores.ToListAsync(),
                                                    "EntrenadorId", "NombreCompleto", equipo.EntrenadorId);
            return View(equipo);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Equipo equipo)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.EntrenadorId = new SelectList(await _context.Entrenadores.ToListAsync(),
                                                        "EntrenadorId", "NombreCompleto", equipo.EntrenadorId);
                return View(equipo);
            }
            try
            {
                _context.Equipos.Update(equipo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (DbUpdateException e)
            {
                if (e.InnerException is SqlException sqlE && (sqlE.Number == 2627 || sqlE.Number == 2601))
                {
                    if (sqlE.Message.Contains("IX_Equipos_Nombre"))
                    {
                        ModelState.AddModelError(nameof(equipo.Nombre), "ya existe un equipo con este Nombre");
                    }
                    else if (sqlE.Message.Contains("IX_Equipos_EntrenadorId"))
                    {
                        ModelState.AddModelError(nameof(equipo.Entrenador), "ya existe un equipo con este Entrenador");
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
            ViewBag.EntrenadorId = new SelectList(await _context.Entrenadores.ToListAsync(),
                                                    "EntrenadorId", "NombreCompleto", equipo.EntrenadorId);

            return View(equipo);
        }


        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(equipo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo == null)
            {
                TempData["Error"] = "Equipo no existe";
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.Equipos.Remove(equipo);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                if (e.InnerException is SqlException sqlE && sqlE.Number == 547)
                {
                    TempData["Error"] = "No se puede eliminar, Equipo con registros asociados";
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
