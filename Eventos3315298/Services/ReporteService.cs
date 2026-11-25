using Eventos3315298.Data;
using Eventos3315298.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Eventos3315298.Services
{
    // implementar todos los miembros de forma explicita
    public class ReporteService : IReporteService
    {
        //inyectar context
        private readonly Eventos3315298Context _context;
        // generar contructor
        public ReporteService(Eventos3315298Context context)
        {
            _context = context;
        }

        //Consultas con notacion linq
        public async Task<TorneoEquiposReporteDTO?> ObtenerEquiposPorTorneo(int torneoId)
        {
            return await _context.Torneos
                //estructura 'forEach': recorre torneoId hasta que sea igual al del metodo y lo almacena en 't'
                .Where(t => t.TorneoId == torneoId)
                .Include(t => t.Municipio)
                .Include(t => t.Equipos)
                    .ThenInclude(e => e.Entrenador)
                .Select(t => new TorneoEquiposReporteDTO
                {
                    TorneoId = t.TorneoId,
                    NombreTorneo = t.Nombre,
                    CategoriaTorneo = t.Categoria,
                    MunicipioTorneo = t.Municipio != null ? t.Municipio.Nombre : "Sin asignar",
                    EquiposInscritos = t.Equipos.Select(e => new EquipoDetalleDTO
                    {
                        EquipoId = e.EquipoId,
                        NombreEquipo = e.Nombre,
                        Disciplina= e.Disciplina,
                        NombreEntrenador = e.Entrenador != null ? e.Entrenador.NombreCompleto : "Sin asignar",
                        CelularEntrenador = e.Entrenador != null ? e.Entrenador.Celular : "N/A"
                    }).ToList()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<List<TorneoEquiposReporteDTO>> ObtenerTodosLosTorneosConEquipos()
        {

            return await _context.Torneos
                .Include(t => t.Municipio)
                .Include(t => t.Equipos)
                    .ThenInclude(e => e.Entrenador)
                .Select(t => new TorneoEquiposReporteDTO
                {
                    TorneoId = t.TorneoId,
                    NombreTorneo = t.Nombre,
                    CategoriaTorneo = t.Categoria,
                    MunicipioTorneo = t.Municipio != null ? t.Municipio.Nombre : "Sin asignar",
                    EquiposInscritos = t.Equipos.Select(e => new EquipoDetalleDTO
                    {
                        EquipoId = e.EquipoId,
                        NombreEquipo = e.Nombre,
                        NombreEntrenador = e.Entrenador != null ? e.Entrenador.NombreCompleto : "Sin asignar",
                        CelularEntrenador = e.Entrenador != null ? e.Entrenador.Celular : "N/A"
                    }).ToList()
                })
                .ToListAsync();
        }
    }
}
