using Eventos3315298.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventos3315298.Data
{
    public class MunicipioConfig : IEntityTypeConfiguration<Municipio>
    {
        public void Configure(EntityTypeBuilder<Municipio> builder)
        {
            builder.HasKey(col => col.MunicipioId);
            //identity = primary key | valueGenerate = auto Increment
            builder.Property(col => col.MunicipioId).UseIdentityColumn().ValueGeneratedOnAdd();
            builder.Property(col => col.Nombre).HasMaxLength(25).IsRequired();
            //HasIndex = geenra indice restrictivo "unique"
            builder.HasIndex(col => col.Nombre).IsUnique();
        }
    }
}
