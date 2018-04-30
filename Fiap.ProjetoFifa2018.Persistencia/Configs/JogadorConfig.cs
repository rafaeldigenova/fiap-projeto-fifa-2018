using Fiap.ProjetoFifa2018.Dominio.Entidades.Jogadores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiap.ProjetoFifa2018.Persistencia.Configs
{
    public class JogadorConfig : IEntityTypeConfiguration<Jogador>
    {
        public void Configure(EntityTypeBuilder<Jogador> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(e => e.Nome)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(e => e.NumeroDaCamisa)
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(e => e.Posicao)
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(e => e.DataDeNascimento)
                .IsRequired();
        }
    }
}
