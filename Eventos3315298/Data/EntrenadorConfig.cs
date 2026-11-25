using Eventos3315298.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventos3315298.Data
{
    public class EntrenadorConfig : IEntityTypeConfiguration<Entrenador>
    {
            public void Configure(EntityTypeBuilder<Entrenador> builder)
            {
                builder.HasKey(col => col.EntrenadorId);
                builder.Property(col => col.EntrenadorId)
                    .UseIdentityColumn()
                    .ValueGeneratedOnAdd();

                builder.Property(col => col.Documento)
                    .HasMaxLength(10)
                    .IsRequired();
                builder.HasIndex(col => col.Documento)
                    .IsUnique();

                builder.Property(col => col.Nombres)
                    .HasMaxLength(30)
                    .IsRequired();

                builder.Property(col => col.Apellidos)
                    .IsRequired();

                builder.Property(col => col.Correo)
                    .IsRequired();
                builder.HasIndex(col => col.Correo)
                    .IsUnique();

                builder.Property(col => col.Celular)
                    .HasMaxLength (10)
                    .IsRequired();
                builder.HasIndex(col => col.Celular)
                    .IsUnique();

                builder.Property(col => col.Rh)
                    .HasMaxLength(3)
                    .IsRequired();

                builder.Property(col => col.Eps)
                    .HasMaxLength(15)
                    .IsRequired();
        }
    }
}
