using Eventos3315298.Models.DTOs;

namespace Eventos3315298.Services
{
    public interface IReporteService
    {
        Task<TorneoEquiposReporteDTO?> ObtenerEquiposPorTorneo(int torneoId);
        Task<List<TorneoEquiposReporteDTO>> ObtenerTodosLosTorneosConEquipos();
    }
}
