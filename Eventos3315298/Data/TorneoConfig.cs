using Eventos3315298.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventos3315298.Data
{
    public class TorneoConfig : IEntityTypeConfiguration<Torneo>
    {
        public void Configure(EntityTypeBuilder<Torneo> builder)
        {
            builder.HasKey(col => col.TorneoId);
            builder.Property(col => col.TorneoId)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();
            builder.Property(col => col.Nombre)
                .HasMaxLength(20)
                .IsRequired();
            builder.HasIndex(col => col.Nombre)
                .IsUnique();
            builder.Property(col => col.Categoria)
                .HasMaxLength(20)
                .IsRequired();
            builder.Property(col => col.FechaInicio)
                .IsRequired();
            builder.Property(col => col.FechaFin)
                .IsRequired();

            //configurar la relacion
            builder.HasOne(t => t.Municipio)
                .WithMany(m => m.Torneos)
                .HasForeignKey(t => t.MunicipioId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
