using Fiap.ProjetoFifa2018.Dominio.Entidades.Times;
using Fiap.ProjetoFifa2018.Dominio.Enums;
using Fiap.ProjetoFifa2018.Infra.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.ProjetoFifa2018.Dominio.Jogadores
{
    public class Jogador : EntidadeBase
    {
        public string Nome { get; set; } 
        public int NumeroDaCamisa { get; set; }
        public DateTime DataDeNascimento  { get; set; }
        public Posicao Posicao { get; set; }
        public Time Time { get; set; }
    }
}
