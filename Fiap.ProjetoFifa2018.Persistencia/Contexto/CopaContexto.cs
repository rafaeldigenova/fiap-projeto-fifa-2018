using Fiap.ProjetoFifa2018.Dominio.Entidades.Partidas;
using Fiap.ProjetoFifa2018.Dominio.Entidades.Times;
using Fiap.ProjetoFifa2018.Dominio.Entidades.Torneios;
using Fiap.ProjetoFifa2018.Dominio.Entidades.Jogadores;
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
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<TimeDoGrupo> TimesDosGrupos { get; set; }
        public DbSet<Playoffs> Playoffs { get; set; }
        public DbSet<GolsDaPartida> GolsDasPartidas { get; set; }
        public DbSet<Partida> Partidas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new TimeConfig());
            builder.ApplyConfiguration(new JogadorConfig());
            builder.ApplyConfiguration(new TorneioConfig());
            builder.ApplyConfiguration(new GrupoConfig());
            builder.ApplyConfiguration(new TimeDoGrupoConfig());
            builder.ApplyConfiguration(new PlayoffsConfig());
            builder.ApplyConfiguration(new GolsDaPartidaConfig());
            builder.ApplyConfiguration(new PartidaConfig());
        }
    }
}
