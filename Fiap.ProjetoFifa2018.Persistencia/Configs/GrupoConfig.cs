using Fiap.ProjetoFifa2018.Dominio.Entidades.Torneios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiap.ProjetoFifa2018.Persistencia.Configs
{
    public class GrupoConfig : IEntityTypeConfiguration<Grupo>
    {
        public void Configure(EntityTypeBuilder<Grupo> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(e => e.Nome)
                .IsRequired();

            builder.HasMany(e => e.Times).WithOne(e => e.Grupo);
        }
    }
}
