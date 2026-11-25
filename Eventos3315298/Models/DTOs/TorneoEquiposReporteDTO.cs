namespace Eventos3315298.Models.DTOs
{
    public class TorneoEquiposReporteDTO
    {
        // Nombre de cada uno
        public int TorneoId { get; set; }
        public string NombreTorneo { get; set; } = "";
        public string CategoriaTorneo { get; set; } = "";
        public string MunicipioTorneo { get; set; } = "";
        // Lista de torneos
        public List<EquipoDetalleDTO> EquiposInscritos { get; set; } = new();
    }
}
