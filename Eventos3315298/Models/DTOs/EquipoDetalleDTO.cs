namespace Eventos3315298.Models.DTOs
{
    public class EquipoDetalleDTO
    {
        public int EquipoId { get; set; }
        public string NombreEquipo { get; set; } = "";
        public string Disciplina { get; set; } = "";
        public string NombreEntrenador { get; set; } = "";
        public string CelularEntrenador { get; set; } = "";
    }
}
