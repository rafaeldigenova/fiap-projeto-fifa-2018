using Fiap.ProjetoFifa2018.Dominio.Entidades.Partidas;
using Fiap.ProjetoFifa2018.Dominio.Entidades.Jogadores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiap.ProjetoFifa2018.Persistencia.Configs
{
    public class GolsDaPartidaConfig : IEntityTypeConfiguration<GolsDaPartida>
    {
        public void Configure(EntityTypeBuilder<GolsDaPartida> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(e => e.IdDoJogadorQueMarcou)
                .IsRequired();

            builder.Property(e => e.NomeDoJogadorQueMarcou)
                .IsRequired();

            builder.Property(e => e.IdDoTimeQueMarcou)
                .IsRequired();

            builder.Property(e => e.TempoDoGolEmMinutos)
                .IsRequired();
        }
    }
}
