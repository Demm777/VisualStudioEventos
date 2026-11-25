namespace Eventos3315298.Models
{
    public class Torneo
    {
        public int TorneoId { get; set; }
        public string Nombre { get; set; } = "";
        public string Categoria { get; set; } = "";

        public DateOnly FechaInicio { get; set; }

        public DateOnly FechaFin { get; set; }

        public int MunicipioId { get; set; }
        public Municipio? Municipio { get; set; }

        // relacion 1:m con equipo
        public ICollection<Equipo> Equipos { get; set; } = new List<Equipo>();
    }
}
