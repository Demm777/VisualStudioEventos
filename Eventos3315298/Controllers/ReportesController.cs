using Eventos3315298.Data;
using Eventos3315298.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Eventos3315298.Controllers
{
    public class ReportesController : Controller
    {
        private readonly IReporteService _reporteService;
        private readonly Eventos3315298Context _context;

        public ReportesController(IReporteService reporteService, Eventos3315298Context context)
        {
            _reporteService = reporteService;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var torneo = await _context.Torneos
                .Select(t => new { t.TorneoId, t.Nombre })
                .ToListAsync();
            ViewBag.TorneosList = torneo;
            return View();
        }

        public async Task<IActionResult> TorneoEquipos(int id)
        {
            var reporteDTO = await _reporteService.ObtenerEquiposPorTorneo(id);
            if(reporteDTO == null)
            {
                TempData["Error"] = "No se encontro el Torneo especificado";
                return RedirectToAction(nameof(Index));
            }
            return View(reporteDTO);
        }

        public async Task<IActionResult> ExportarExcelTorneoEquipos(int id)
        {
            var reporteDto = await _reporteService.ObtenerEquiposPorTorneo(id);
            if (reporteDto == null)
            {
                TempData["Error"] = "No se encontro el Torneo especificado";
                return RedirectToAction(nameof(Index));
            }
            //? - investigar esto -
            var builder = new System.Text.StringBuilder();

            builder.AppendLine($"TORNEO:;\"{reporteDto.NombreTorneo}\"");
            builder.AppendLine($"CATEGORIA:;\"{reporteDto.CategoriaTorneo}\"");
            builder.AppendLine($"MUNICIPIO:;\"{reporteDto.MunicipioTorneo}\"");

            //encabezados de la tabla
            builder.AppendLine("ID Equipo;Nombre Equipo;Disciplina;Entrenador;Celular Entrenador");

            //Llenar filas
            foreach (var equipo in reporteDto.EquiposInscritos)
            {
                builder.AppendLine($"{equipo.EquipoId};\"{equipo.NombreEquipo}\";\"{equipo.Disciplina}\";\"{equipo.NombreEntrenador}\";\"{equipo.CelularEntrenador}\"");
            }

            //conversion codigos UTF-8
            var preamble = System.Text.Encoding.UTF8.GetPreamble();
            var bodyBytes = System.Text.Encoding.UTF8.GetBytes(builder.ToString());
            var fileBytes = preamble.Concat(bodyBytes).ToArray();

            //generar csv
            string filename = $"Reporte_Equipo_Torneo_{id}_{DateTime.Now:yyyyMMdd_HHmm}.csv";
            return File(fileBytes,"text/csv",filename);
        }
    }
}
