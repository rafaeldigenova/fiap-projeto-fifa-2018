using Fiap.ProjetoFifa2018.Dominio.Entidades.Partidas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiap.ProjetoFifa2018.Persistencia.Configs
{
    public class PartidaConfig : IEntityTypeConfiguration<Partida>
    {
        public void Configure(EntityTypeBuilder<Partida> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(e => e.DataDaPartida)
                .IsRequired();

            builder.HasMany(e => e.Gols).WithOne(x => x.Partida)
                .IsRequired();

            builder.Property(e => e.NomeDoTimeMandante)
                .IsRequired();

            builder.Property(e => e.NomeDoTimeVisitante)
                .IsRequired();

            builder.Property(e => e.IdDoTimeVencedor)
                .IsRequired();

            builder.Property(e => e.IdDoTimeVisitante)
                .IsRequired();

            builder.Property(e => e.IdDoTimeMandante)
                .IsRequired();
        }
    }
}
