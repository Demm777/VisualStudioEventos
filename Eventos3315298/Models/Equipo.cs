namespace Eventos3315298.Models
{
    public class Equipo
    {
        public int EquipoId { get; set; }
        public string Nombre { get; set; } = null!;
        public string Disciplina { get; set; } = null!;
        public string Localidad { get; set; } = null!;

        // llave foranea para la relacion con entrenador
        public int EntrenadorId { get; set; }
        public Entrenador? Entrenador { get; set; } = null!; //propiedad navigacional

        // relacion 1:m con torneo
        public ICollection<Torneo> Torneos { get; set; } = new List<Torneo>();
    }
}
