using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Fiap.ProjetoFifa2018.Dominio.Entidades.Torneios;
using Fiap.ProjetoFifa2018.Dominio.Entidades.Times;
using Microsoft.EntityFrameworkCore;

namespace Fiap.ProjetoFifa2018.Persistencia.Contexto
{
    public static class DbInitializer
    {
        public static void Seed(CopaContexto contexto)
        {
            contexto.Database.EnsureCreated();

            SeedTorneio(contexto);
            SeedTimes(contexto);
        }

        public static void SeedTorneio(CopaContexto contexto)
        {
            if (!contexto.Torneios.Any())
            {
                contexto.Database.ExecuteSqlCommand(
                    "SET IDENTITY_INSERT dbo.Torneios ON; SET IDENTITY_INSERT dbo.Grupo ON; SET IDENTITY_INSERT dbo.TimeDoGrupo ON;");

                var torneio = new Torneio() { Id = 1, DataDeInicioDoTorneio = DateTime.Now, QuantidadeDeGrupos = 8, QuantidadeDeTimes = 32 };

                var grupoA = new Grupo() { Id = 1, Nome = "Grupo A" };
                grupoA.AdicionarTime(new TimeDoGrupo() { Id = 1, NomeDoTime = "Russia", Escudo = "RUS" });
                grupoA.AdicionarTime(new TimeDoGrupo() { Id = 2, NomeDoTime = "Saudi Arabia", Escudo = "KSA" });
                grupoA.AdicionarTime(new TimeDoGrupo() { Id = 3, NomeDoTime = "Egypt", Escudo = "EGY" });
                grupoA.AdicionarTime(new TimeDoGrupo() { Id = 4, NomeDoTime = "Uruguay", Escudo = "URU" });

                var grupoB = new Grupo() { Id = 2, Nome = "Grupo B" };
                grupoB.AdicionarTime(new TimeDoGrupo() { Id = 5, NomeDoTime = "Portugal", Escudo = "POR" });
                grupoB.AdicionarTime(new TimeDoGrupo() { Id = 6, NomeDoTime = "Spain", Escudo = "ESP" });
                grupoB.AdicionarTime(new TimeDoGrupo() { Id = 7, NomeDoTime = "Morocco", Escudo = "MAR" });
                grupoB.AdicionarTime(new TimeDoGrupo() { Id = 8, NomeDoTime = "IR Iran", Escudo = "IRN" });

                var grupoC = new Grupo() { Id = 3, Nome = "Grupo C" };
                grupoC.AdicionarTime(new TimeDoGrupo() { Id = 9, NomeDoTime = "France", Escudo = "FRA" });
                grupoC.AdicionarTime(new TimeDoGrupo() { Id = 10, NomeDoTime = "Australia", Escudo = "AUS" });
                grupoC.AdicionarTime(new TimeDoGrupo() { Id = 11, NomeDoTime = "Peru", Escudo = "PER" });
                grupoC.AdicionarTime(new TimeDoGrupo() { Id = 12, NomeDoTime = "Denmark", Escudo = "DEN" });

                var grupoD = new Grupo() { Id = 4, Nome = "Grupo D" };
                grupoD.AdicionarTime(new TimeDoGrupo() { Id = 13, NomeDoTime = "Argentina", Escudo = "ARG" });
                grupoD.AdicionarTime(new TimeDoGrupo() { Id = 14, NomeDoTime = "Iceland", Escudo = "ISL" });
                grupoD.AdicionarTime(new TimeDoGrupo() { Id = 15, NomeDoTime = "Croatia", Escudo = "CRO" });
                grupoD.AdicionarTime(new TimeDoGrupo() { Id = 16, NomeDoTime = "Nigeria", Escudo = "NGA" });

                var grupoE = new Grupo() { Id = 5, Nome = "Grupo E" };
                grupoE.AdicionarTime(new TimeDoGrupo() { Id = 17, NomeDoTime = "Brazil", Escudo = "BRA" });
                grupoE.AdicionarTime(new TimeDoGrupo() { Id = 18, NomeDoTime = "Switzerland", Escudo = "SUI" });
                grupoE.AdicionarTime(new TimeDoGrupo() { Id = 19, NomeDoTime = "Costa Rica", Escudo = "CRC" });
                grupoE.AdicionarTime(new TimeDoGrupo() { Id = 20, NomeDoTime = "Serbia", Escudo = "SRB" });

                var grupoF = new Grupo() { Id = 6, Nome = "Grupo F" };
                grupoF.AdicionarTime(new TimeDoGrupo() { Id = 21, NomeDoTime = "Germany", Escudo = "GER" });
                grupoF.AdicionarTime(new TimeDoGrupo() { Id = 22, NomeDoTime = "Mexico", Escudo = "MEX" });
                grupoF.AdicionarTime(new TimeDoGrupo() { Id = 23, NomeDoTime = "Sweden", Escudo = "SWE" });
                grupoF.AdicionarTime(new TimeDoGrupo() { Id = 24, NomeDoTime = "Korea Republic", Escudo = "KOR" });

                var grupoG = new Grupo() { Id = 7, Nome = "Grupo G" };
                grupoG.AdicionarTime(new TimeDoGrupo() { Id = 25, NomeDoTime = "Belgium", Escudo = "BEL" });
                grupoG.AdicionarTime(new TimeDoGrupo() { Id = 26, NomeDoTime = "Panama", Escudo = "PAN" });
                grupoG.AdicionarTime(new TimeDoGrupo() { Id = 27, NomeDoTime = "Tunisia", Escudo = "TUN" });
                grupoG.AdicionarTime(new TimeDoGrupo() { Id = 28, NomeDoTime = "England", Escudo = "ENG" });

                var grupoH = new Grupo() { Id = 8, Nome = "Grupo H" };
                grupoH.AdicionarTime(new TimeDoGrupo() { Id = 29, NomeDoTime = "Poland", Escudo = "POL" });
                grupoH.AdicionarTime(new TimeDoGrupo() { Id = 30, NomeDoTime = "Senegal", Escudo = "SEN" });
                grupoH.AdicionarTime(new TimeDoGrupo() { Id = 31, NomeDoTime = "Colombia", Escudo = "COL" });
                grupoH.AdicionarTime(new TimeDoGrupo() { Id = 32, NomeDoTime = "Japan", Escudo = "JPN" });

                torneio.AdicionarGrupos(new List<Grupo> { grupoA, grupoB, grupoC, grupoD, grupoE, grupoF, grupoG, grupoH });

                contexto.Torneios.Add(torneio);

                contexto.SaveChanges();

                contexto.Database.ExecuteSqlCommand(
                    "SET IDENTITY_INSERT dbo.Torneios OFF; SET IDENTITY_INSERT dbo.Grupo OFF; SET IDENTITY_INSERT dbo.TimeDoGrupo OFF;");
            }
        }

        public static void SeedTimes(CopaContexto contexto)
        {
            if (!contexto.Times.Any())
            {
                contexto.Times.Add(new Time() { Id = 1, NomeDoTime = "Russia", Escudo = "RUS" });
                contexto.Times.Add(new Time() { Id = 2, NomeDoTime = "Saudi Arabia", Escudo = "KSA" });
                contexto.Times.Add(new Time() { Id = 3, NomeDoTime = "Egypt", Escudo = "EGY" });
                contexto.Times.Add(new Time() { Id = 4, NomeDoTime = "Uruguay", Escudo = "URU" });

                contexto.Times.Add(new Time() { Id = 5, NomeDoTime = "Portugal", Escudo = "POR" });
                contexto.Times.Add(new Time() { Id = 6, NomeDoTime = "Spain", Escudo = "ESP" });
                contexto.Times.Add(new Time() { Id = 7, NomeDoTime = "Morocco", Escudo = "MAR" });
                contexto.Times.Add(new Time() { Id = 8, NomeDoTime = "IR Iran", Escudo = "IRN" });

                contexto.Times.Add(new Time() { Id = 9, NomeDoTime = "France", Escudo = "FRA" });
                contexto.Times.Add(new Time() { Id = 10, NomeDoTime = "Australia", Escudo = "AUS" });
                contexto.Times.Add(new Time() { Id = 11, NomeDoTime = "Peru", Escudo = "PER" });
                contexto.Times.Add(new Time() { Id = 12, NomeDoTime = "Denmark", Escudo = "DEN" });

                contexto.Times.Add(new Time() { Id = 13, NomeDoTime = "Argentina", Escudo = "ARG" });
                contexto.Times.Add(new Time() { Id = 14, NomeDoTime = "Iceland", Escudo = "ISL" });
                contexto.Times.Add(new Time() { Id = 15, NomeDoTime = "Croatia", Escudo = "CRO" });
                contexto.Times.Add(new Time() { Id = 16, NomeDoTime = "Nigeria", Escudo = "NGA" });

                contexto.Times.Add(new Time() { Id = 17, NomeDoTime = "Brazil", Escudo = "BRA" });
                contexto.Times.Add(new Time() { Id = 18, NomeDoTime = "Switzerland", Escudo = "SUI" });
                contexto.Times.Add(new Time() { Id = 19, NomeDoTime = "Costa Rica", Escudo = "CRC" });
                contexto.Times.Add(new Time() { Id = 20, NomeDoTime = "Serbia", Escudo = "SRB" });

                contexto.Times.Add(new Time() { Id = 21, NomeDoTime = "Germany", Escudo = "GER" });
                contexto.Times.Add(new Time() { Id = 22, NomeDoTime = "Mexico", Escudo = "MEX" });
                contexto.Times.Add(new Time() { Id = 23, NomeDoTime = "Sweden", Escudo = "SWE" });
                contexto.Times.Add(new Time() { Id = 24, NomeDoTime = "Korea Republic", Escudo = "KOR" });

                contexto.Times.Add(new Time() { Id = 25, NomeDoTime = "Belgium", Escudo = "BEL" });
                contexto.Times.Add(new Time() { Id = 26, NomeDoTime = "Panama", Escudo = "PAN" });
                contexto.Times.Add(new Time() { Id = 27, NomeDoTime = "Tunisia", Escudo = "TUN" });
                contexto.Times.Add(new Time() { Id = 28, NomeDoTime = "England", Escudo = "ENG" });

                contexto.Times.Add(new Time() { Id = 29, NomeDoTime = "Poland", Escudo = "POL" });
                contexto.Times.Add(new Time() { Id = 30, NomeDoTime = "Senegal", Escudo = "SEN" });
                contexto.Times.Add(new Time() { Id = 31, NomeDoTime = "Colombia", Escudo = "COL" });
                contexto.Times.Add(new Time() { Id = 32, NomeDoTime = "Japan", Escudo = "JPN" });
            }
        }
    }
}
