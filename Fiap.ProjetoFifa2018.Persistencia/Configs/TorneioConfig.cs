using Fiap.ProjetoFifa2018.Dominio.Entidades.Torneios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiap.ProjetoFifa2018.Persistencia.Configs
{
    public class TorneioConfig : IEntityTypeConfiguration<Torneio>
    {
        public void Configure(EntityTypeBuilder<Torneio> builder)
        {
            builder.HasKey(e => e.Id);
            
            builder.Property(e => e.Id)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(e => e.DataDeInicioDoTorneio)
                .IsRequired();

            builder.Property(e => e.QuantidadeDeGrupos)
                .IsRequired();

            builder.Property(e => e.QuantidadeDeTimes)
                .IsRequired();

            builder.HasMany(e => e.Grupos).WithOne(e => e.Torneio);
        }
    }
}
