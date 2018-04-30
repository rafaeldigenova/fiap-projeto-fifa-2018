using Fiap.ProjetoFifa2018.Dominio.Entidades.Torneios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiap.ProjetoFifa2018.Persistencia.Configs
{
    public class PlayoffsConfig : IEntityTypeConfiguration<Playoffs>
    {
        public void Configure(EntityTypeBuilder<Playoffs> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(e => e.IdDaPartidaDeIda)
                .IsRequired();

            builder.Property(e => e.IdDaPartidaDeVolta)
                .IsRequired();

            builder.Property(e => e.IdDoTimeVencedor)
                .IsRequired();

            builder.Property(e => e.Nivel)
                .IsRequired();
        }
    }
}
