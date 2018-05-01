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
                var torneio = new Torneio() { Nome = "Copa do Mundo - Fifa 2018", DataDeInicioDoTorneio = DateTime.Now, QuantidadeDeGrupos = 8, QuantidadeDeTimes = 32 };

                var grupoA = new Grupo() {Nome = "Grupo A" };
                grupoA.AdicionarTime(new TimeDoGrupo() {NomeDoTime = "Russia", Escudo = "RUS" });
                grupoA.AdicionarTime(new TimeDoGrupo() {NomeDoTime = "Saudi Arabia", Escudo = "KSA" });
                grupoA.AdicionarTime(new TimeDoGrupo() {NomeDoTime = "Egypt", Escudo = "EGY" });
                grupoA.AdicionarTime(new TimeDoGrupo() {NomeDoTime = "Uruguay", Escudo = "URU" });

                var grupoB = new Grupo() {Nome = "Grupo B" };
                grupoB.AdicionarTime(new TimeDoGrupo() {NomeDoTime = "Portugal", Escudo = "POR" });
                grupoB.AdicionarTime(new TimeDoGrupo() {NomeDoTime = "Spain", Escudo = "ESP" });
                grupoB.AdicionarTime(new TimeDoGrupo() {NomeDoTime = "Morocco", Escudo = "MAR" });
                grupoB.AdicionarTime(new TimeDoGrupo() {NomeDoTime = "IR Iran", Escudo = "IRN" });

                var grupoC = new Grupo() {Nome = "Grupo C" };
                grupoC.AdicionarTime(new TimeDoGrupo() {NomeDoTime = "France", Escudo = "FRA" });
                grupoC.AdicionarTime(new TimeDoGrupo() {NomeDoTime = "Australia", Escudo = "AUS" });
                grupoC.AdicionarTime(new TimeDoGrupo() {NomeDoTime = "Peru", Escudo = "PER" });
                grupoC.AdicionarTime(new TimeDoGrupo() {NomeDoTime = "Denmark", Escudo = "DEN" });

                var grupoD = new Grupo() {Nome = "Grupo D" };
                grupoD.AdicionarTime(new TimeDoGrupo() {NomeDoTime = "Argentina", Escudo = "ARG" });
                grupoD.AdicionarTime(new TimeDoGrupo() {NomeDoTime = "Iceland", Escudo = "ISL" });
                grupoD.AdicionarTime(new TimeDoGrupo() {NomeDoTime = "Croatia", Escudo = "CRO" });
                grupoD.AdicionarTime(new TimeDoGrupo() {NomeDoTime = "Nigeria", Escudo = "NGA" });

                var grupoE = new Grupo() {Nome = "Grupo E" };
                grupoE.AdicionarTime(new TimeDoGrupo() {NomeDoTime = "Brazil", Escudo = "BRA" });
                grupoE.AdicionarTime(new TimeDoGrupo() {NomeDoTime = "Switzerland", Escudo = "SUI" });
                grupoE.AdicionarTime(new TimeDoGrupo() {NomeDoTime = "Costa Rica", Escudo = "CRC" });
                grupoE.AdicionarTime(new TimeDoGrupo() {NomeDoTime = "Serbia", Escudo = "SRB" });

                var grupoF = new Grupo() {Nome = "Grupo F" };
                grupoF.AdicionarTime(new TimeDoGrupo() {NomeDoTime = "Germany", Escudo = "GER" });
                grupoF.AdicionarTime(new TimeDoGrupo() {NomeDoTime = "Mexico", Escudo = "MEX" });
                grupoF.AdicionarTime(new TimeDoGrupo() {NomeDoTime = "Sweden", Escudo = "SWE" });
                grupoF.AdicionarTime(new TimeDoGrupo() {NomeDoTime = "Korea Republic", Escudo = "KOR" });

                var grupoG = new Grupo() {Nome = "Grupo G" };
                grupoG.AdicionarTime(new TimeDoGrupo() {NomeDoTime = "Belgium", Escudo = "BEL" });
                grupoG.AdicionarTime(new TimeDoGrupo() {NomeDoTime = "Panama", Escudo = "PAN" });
                grupoG.AdicionarTime(new TimeDoGrupo() {NomeDoTime = "Tunisia", Escudo = "TUN" });
                grupoG.AdicionarTime(new TimeDoGrupo() {NomeDoTime = "England", Escudo = "ENG" });

                var grupoH = new Grupo() {Nome = "Grupo H" };
                grupoH.AdicionarTime(new TimeDoGrupo() {NomeDoTime = "Poland", Escudo = "POL" });
                grupoH.AdicionarTime(new TimeDoGrupo() {NomeDoTime = "Senegal", Escudo = "SEN" });
                grupoH.AdicionarTime(new TimeDoGrupo() {NomeDoTime = "Colombia", Escudo = "COL" });
                grupoH.AdicionarTime(new TimeDoGrupo() {NomeDoTime = "Japan", Escudo = "JPN" });

                torneio.AdicionarGrupo(grupoA);
                torneio.AdicionarGrupo(grupoB);
                torneio.AdicionarGrupo(grupoC);
                torneio.AdicionarGrupo(grupoD);
                torneio.AdicionarGrupo(grupoE);
                torneio.AdicionarGrupo(grupoF);
                torneio.AdicionarGrupo(grupoG);
                torneio.AdicionarGrupo(grupoH);

                contexto.Torneios.Add(torneio);

                contexto.SaveChanges();
            }
        }

        public static void SeedTimes(CopaContexto contexto)
        {
            if (!contexto.Times.Any())
            {
                contexto.Times.Add(new Time() { NomeDoTime = "Russia", Escudo = "RUS" });
                contexto.Times.Add(new Time() { NomeDoTime = "Saudi Arabia", Escudo = "KSA" });
                contexto.Times.Add(new Time() { NomeDoTime = "Egypt", Escudo = "EGY" });
                contexto.Times.Add(new Time() { NomeDoTime = "Uruguay", Escudo = "URU" });

                contexto.Times.Add(new Time() { NomeDoTime = "Portugal", Escudo = "POR" });
                contexto.Times.Add(new Time() { NomeDoTime = "Spain", Escudo = "ESP" });
                contexto.Times.Add(new Time() { NomeDoTime = "Morocco", Escudo = "MAR" });
                contexto.Times.Add(new Time() { NomeDoTime = "IR Iran", Escudo = "IRN" });

                contexto.Times.Add(new Time() { NomeDoTime = "France", Escudo = "FRA" });
                contexto.Times.Add(new Time() {  NomeDoTime = "Australia", Escudo = "AUS" });
                contexto.Times.Add(new Time() {  NomeDoTime = "Peru", Escudo = "PER" });
                contexto.Times.Add(new Time() {  NomeDoTime = "Denmark", Escudo = "DEN" });

                contexto.Times.Add(new Time() {  NomeDoTime = "Argentina", Escudo = "ARG" });
                contexto.Times.Add(new Time() {  NomeDoTime = "Iceland", Escudo = "ISL" });
                contexto.Times.Add(new Time() {  NomeDoTime = "Croatia", Escudo = "CRO" });
                contexto.Times.Add(new Time() {  NomeDoTime = "Nigeria", Escudo = "NGA" });

                contexto.Times.Add(new Time() {  NomeDoTime = "Brazil", Escudo = "BRA" });
                contexto.Times.Add(new Time() {  NomeDoTime = "Switzerland", Escudo = "SUI" });
                contexto.Times.Add(new Time() {  NomeDoTime = "Costa Rica", Escudo = "CRC" });
                contexto.Times.Add(new Time() {  NomeDoTime = "Serbia", Escudo = "SRB" });

                contexto.Times.Add(new Time() {  NomeDoTime = "Germany", Escudo = "GER" });
                contexto.Times.Add(new Time() {  NomeDoTime = "Mexico", Escudo = "MEX" });
                contexto.Times.Add(new Time() {  NomeDoTime = "Sweden", Escudo = "SWE" });
                contexto.Times.Add(new Time() {  NomeDoTime = "Korea Republic", Escudo = "KOR" });

                contexto.Times.Add(new Time() {  NomeDoTime = "Belgium", Escudo = "BEL" });
                contexto.Times.Add(new Time() {  NomeDoTime = "Panama", Escudo = "PAN" });
                contexto.Times.Add(new Time() {  NomeDoTime = "Tunisia", Escudo = "TUN" });
                contexto.Times.Add(new Time() {  NomeDoTime = "England", Escudo = "ENG" });

                contexto.Times.Add(new Time() {  NomeDoTime = "Poland", Escudo = "POL" });
                contexto.Times.Add(new Time() {  NomeDoTime = "Senegal", Escudo = "SEN" });
                contexto.Times.Add(new Time() {  NomeDoTime = "Colombia", Escudo = "COL" });
                contexto.Times.Add(new Time() {  NomeDoTime = "Japan", Escudo = "JPN" });


                contexto.SaveChanges();
            }
        }
    }
}
