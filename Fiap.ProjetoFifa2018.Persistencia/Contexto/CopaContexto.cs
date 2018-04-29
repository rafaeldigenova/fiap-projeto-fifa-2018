using Fiap.ProjetoFifa2018.Dominio.Entidades.Times;
using Fiap.ProjetoFifa2018.Dominio.Entidades.Torneios;
using Fiap.ProjetoFifa2018.Dominio.Jogadores;
using Fiap.ProjetoFifa2018.Persistencia.Configs;
using Microsoft.EntityFrameworkCore;

namespace Fiap.ProjetoFifa2018.Persistencia.Contexto
{
    public class CopaContexto : DbContext
    {
        public CopaContexto(DbContextOptions<CopaContexto> options)
            : base(options)
        {

        }

        public DbSet<Time> Times { get; set; }
        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<Torneio> Torneios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new TimeConfig());
            builder.ApplyConfiguration(new JogadorConfig());
        }
    }
}
