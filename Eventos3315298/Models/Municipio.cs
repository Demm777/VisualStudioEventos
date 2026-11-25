namespace Eventos3315298.Models
{
    public class Municipio
    {
        public int MunicipioId {  get; set; }
        public string Nombre { get; set; } = "";

        public ICollection<Torneo> Torneos { get; set; } = new List<Torneo>();
    }
}
