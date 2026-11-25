using Eventos3315298.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventos3315298.Data
{
    public class EquipoConfig : IEntityTypeConfiguration<Equipo>
    {
        public void Configure(EntityTypeBuilder<Equipo> builder)
            {
               builder.HasKey(col => col.EquipoId);
                builder.Property(col => col.EquipoId)
                    .UseIdentityColumn()
                    .ValueGeneratedOnAdd();

                builder.Property(col => col.Nombre)
                    .HasMaxLength(20)
                    .IsRequired();
                builder.HasIndex(col => col.Nombre)
                    .IsUnique();

                builder.Property(col => col.Disciplina)
                    .HasMaxLength(20)
                    .IsRequired();

                builder.Property(col => col.Localidad)
                    .HasMaxLength(20)
                    .IsRequired();

                builder.Property(col => col.EntrenadorId)
                    .IsRequired();

                //configurar la relacion 1:1 con entrenaodr
                builder.HasOne(eq=>eq.Entrenador)
                    .WithOne(en=>en.Equipo)
                    .HasForeignKey<Equipo>(eq=>eq.EntrenadorId)
                    .OnDelete(DeleteBehavior.Restrict);

            // configurar relacion 1:m con torneo
            builder.HasMany(e => e.Torneos)
                .WithMany(t => t.Equipos)
                .UsingEntity(j => j.ToTable("TorneoEquipo"));
            }
     }
}
