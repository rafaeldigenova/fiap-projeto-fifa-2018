using Fiap.ProjetoFifa2018.Dominio.Entidades.Times;
using Fiap.ProjetoFifa2018.Dominio.Enums;
using Fiap.ProjetoFifa2018.Infra.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Fiap.ProjetoFifa2018.Dominio.Entidades.Jogadores
{
    public class Jogador : EntidadeBase
    {
        public string Nome { get; set; } 
        [Display(Name = "Número da Camisa")]
        public int NumeroDaCamisa { get; set; }
        [Display(Name = "Data de Nascimento")]
        public DateTime DataDeNascimento  { get; set; }
        [Display(Name = "Posição")]
        public Posicao Posicao { get; set; }
        public Time Time { get; set; }
    }
}
