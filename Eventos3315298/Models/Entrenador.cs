namespace Eventos3315298.Models
{
    public class Entrenador
    {
        public int EntrenadorId { get; set; }
        public string Documento { get; set; } = "";
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string NombreCompleto => $"{Nombres} {Apellidos}";
        public string Correo { get; set; } = null!;
        public string Celular { get; set; } = null!;
        public string Rh { get; set; } = null!;
        public string Eps { get; set; } = null!;

        //realacion 1:1 con equipo
        public Equipo? Equipo { get; set; } = null!;

    }
}
