using Eventos3315298.Models;
using Microsoft.EntityFrameworkCore;

namespace Eventos3315298.Data
{
    // : = herencia
    public class Eventos3315298Context:DbContext
    {
        //agregar constructor
        public Eventos3315298Context(DbContextOptions<Eventos3315298Context> options)
            :base(options)
        {

        }
        //Atributos
        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<Torneo> Torneos { get; set; }

        public DbSet<Entrenador> Entrenadores { get; set; }
        public DbSet<Equipo> Equipos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //inyectar clase de configuracion
            modelBuilder.ApplyConfiguration(new MunicipioConfig());
            modelBuilder.ApplyConfiguration(new TorneoConfig());
            modelBuilder.ApplyConfiguration(new EntrenadorConfig());
            modelBuilder.ApplyConfiguration(new EquipoConfig());
        }
    }
}
