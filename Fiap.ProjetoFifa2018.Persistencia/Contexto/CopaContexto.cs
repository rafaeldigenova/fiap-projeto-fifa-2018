using Fiap.ProjetoFifa2018.Dominio.Entidades.Times;
using Fiap.ProjetoFifa2018.Dominio.Entidades.Torneios;
using Fiap.ProjetoFifa2018.Dominio.Jogadores;
using Microsoft.EntityFrameworkCore;
using System;

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

    }
}
