using Fiap.ProjetoFifa2018.Dominio.Entidades.Times;
using Fiap.ProjetoFifa2018.Infra.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.ProjetoFifa2018.Dominio.Entidades.Torneios
{
    public class TimeDoGrupo : EntidadeBase
    {
        public Grupo Grupo { get; set; }
        public string NomeDoTime { get; set; }
        public string Escudo { get; set; }
        public int IdDoTime { get; set; }
        public int PontuacaoAtual { get; set; }
        public int Vitorias { get; set; }
        public int Empates { get; set; }
        public int Derrotas { get; set; }
        public int GolsMarcados { get; set; }
        public int GolsSofridos { get; set; }

        public TimeDoGrupo()
        {
            PontuacaoAtual = 0;
            Vitorias = 0;
            Empates = 0;
            Derrotas = 0;
            GolsSofridos = 0;
            GolsMarcados = 0;
        }
    }
}
