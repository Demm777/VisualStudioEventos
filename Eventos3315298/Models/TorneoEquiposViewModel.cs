namespace Eventos3315298.Models
{
    public class TorneoEquiposViewModel
    {
        public int TorneoId { get; set; }
        public string TorneoNombre { get; set; } = "";
        public List<EquipoCheckBoxItem> EquiposDisponibles { get; set; } = new();
    }

    public class EquipoCheckBoxItem 
    {
        public int EquipoId { get; set; }
        public string NombreEquipo { get; set; } = "";
        public string Disciplina { get; set; } = "";
        public bool IsSelected { get; set; }
    }
}
