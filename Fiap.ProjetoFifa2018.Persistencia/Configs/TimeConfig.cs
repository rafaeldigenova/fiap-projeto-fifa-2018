using Fiap.ProjetoFifa2018.Dominio.Entidades.Times;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiap.ProjetoFifa2018.Persistencia.Configs
{
    public class TimeConfig : IEntityTypeConfiguration<Time>
    {
        public void Configure(EntityTypeBuilder<Time> builder)
        {
            builder.HasKey(e => e.Id);
            
            builder.Property(e => e.Id)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(e => e.NomeDoTime)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(e => e.Escudo)
                .HasMaxLength(150)
                .IsRequired();

            builder.HasMany(e => e.Jogadores).WithOne(e => e.Time);
        }
    }
}
