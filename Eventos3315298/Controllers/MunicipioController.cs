using Eventos3315298.Data;
using Eventos3315298.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Eventos3315298.Controllers
{
    public class MunicipioController : Controller
    {
        //Inyectar contexto
        private readonly Eventos3315298Context _context;

        public MunicipioController(Eventos3315298Context context)
        {
            _context = context;
        } 

        [HttpGet] //obtener
        public async Task<IActionResult> Index()
        {
            var municipios = await _context.Municipios.ToListAsync();
            return View(municipios);
        }

        [HttpGet] //crear vista
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] //crear
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Municipio municipio)
        {
            if (!ModelState.IsValid)
            {
                return View(municipio);
            }
            try
            {
                _context.Municipios.Add(municipio);
                await _context.SaveChangesAsync();
                TempData["Mensaje"] = "Municipio creado con exiti";
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException e)
            {
                if (e.InnerException is SqlException sqlEx && (sqlEx.Number == 2627 || sqlEx.Number == 2601))
                {
                    if (sqlEx.Message.Contains("IX_Municipios_Nombre"))
                    {
                        ModelState.AddModelError(nameof(municipio.Nombre), "Ya existe un Municipio con este nombre");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Ocurrio un error en la base de datos");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Ocurrio un error inesperado");
                }
            }
            return View(municipio);
        }

        [HttpGet] //editar vista
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Index));
            }
            var municipio = await _context.Municipios.FindAsync(id);
            if (municipio == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(municipio);
        }

        [HttpPost] //editar 
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Municipio municipio)
        {
            if (!ModelState.IsValid)
            {
                return View(municipio);
            }
            try
            {
                _context.Municipios.Update(municipio);
                await _context.SaveChangesAsync();
                TempData["Mensaje"] = "Municipio modificado con exiti";
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException e)
            {
                if (e.InnerException is SqlException sqlEx && (sqlEx.Number == 2627 || sqlEx.Number == 2601))
                {
                    if (sqlEx.Message.Contains("IX_Municipios_Nombre"))
                    {
                        ModelState.AddModelError(nameof(municipio.Nombre), "Ya existe un Municipio con este nombre");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Ocurrio un error en la base de datos");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Ocurrio un error inesperado");
                }
            }
            return View(municipio);
        }

        [HttpGet] //details
        public async Task<IActionResult> Details(int id)
        {
            var municipio = await _context.Municipios.FindAsync(id);
            if (municipio != null)
            {
                return View(municipio);
            }
            return RedirectToAction(nameof(Index));
        }
         
        [HttpGet] //eliminar vista
        public async Task<IActionResult> Delete(int? id)
        {
            var municipio = await _context.Municipios.FindAsync(id);
            if (municipio != null)
            {
                return View(municipio);
            }
            return RedirectToAction(nameof(Index));
        }

        /*
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletConfirmed(int id)
        {
            var municipio = await _context.Municipios.FindAsync(id);
            if (municipio == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.Municipios.Remove(municipio);
                await _context.SaveChangesAsync();
                TempData["mensaje"] = "Municipio eliminado correctamente";
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is SqlException sqlEx && sqlEx.Number == 547)
                {
                    TempData["Error"] = "El Municipio tiene torneos activos. No se puede eliminar";
                }
                else
                {
                    TempData["Error"] = "No se puede eliminar, Error inesperado";
                }
            }
            return RedirectToAction(nameof(Index));
        }
        */

        [HttpPost] //eliminar
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var municipio = await _context.Municipios.FindAsync(id);
            if (municipio == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.Municipios.Remove(municipio);
                await _context.SaveChangesAsync();
                TempData["mensaje"] = "Municipio eliminado correctamente";
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is SqlException sqlEx && sqlEx.Number == 547)
                {
                    TempData["Error"] = "El Municipio tiene torneos activos. No se puede eliminar";
                }
                else
                {
                    TempData["Error"] = "No se puede eliminar, Error inesperado";
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
