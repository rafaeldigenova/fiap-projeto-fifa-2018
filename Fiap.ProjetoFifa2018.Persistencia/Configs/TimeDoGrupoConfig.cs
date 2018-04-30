using Fiap.ProjetoFifa2018.Dominio.Entidades.Torneios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiap.ProjetoFifa2018.Persistencia.Configs
{
    public class TimeDoGrupoConfig : IEntityTypeConfiguration<TimeDoGrupo>
    {
        public void Configure(EntityTypeBuilder<TimeDoGrupo> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(e => e.Vitorias)
                .IsRequired();

            builder.Property(e => e.Empates)
                .IsRequired();

            builder.Property(e => e.Derrotas)
                .IsRequired();

            builder.Property(e => e.GolsMarcados)
                .IsRequired();

            builder.Property(e => e.GolsSofridos)
                .IsRequired();

            builder.Property(e => e.IdDoTime)
                .IsRequired();

            builder.Property(e => e.NomeDoTime)
                .IsRequired();

            builder.Property(e => e.PontuacaoAtual)
                .IsRequired();
        }
    }
}
