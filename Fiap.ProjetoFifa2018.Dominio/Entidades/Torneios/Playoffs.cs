using Fiap.ProjetoFifa2018.Dominio.Entidades.Partidas;
using Fiap.ProjetoFifa2018.Dominio.Enums;
using Fiap.ProjetoFifa2018.Infra.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.ProjetoFifa2018.Dominio.Entidades.Torneios
{
    public class Playoffs : EntidadeBase
    {
        public int IdDaPartidaDeIda { get; set; }
        public int? IdDaPartidaDeVolta { get; set; }
        public int? IdDoTimeVencedor { get; set; }
        public NivelDaPartida Nivel { get; set; }
    }
}
