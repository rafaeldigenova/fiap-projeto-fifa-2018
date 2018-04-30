using Fiap.ProjetoFifa2018.Dominio.Entidades.Jogadores;
using Fiap.ProjetoFifa2018.Infra.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.ProjetoFifa2018.Dominio.Entidades.Partidas
{
    public class GolsDaPartida : EntidadeBase
    {
        public string NomeDoJogadorQueMarcou { get; set; }
        public int TempoDoGolEmMinutos { get; set; }
        public int IdDoJogadorQueMarcou { get; set; }
        public int IdDoTimeQueMarcou { get; set; }
        public Partida Partida { get; set; }
    }
}
