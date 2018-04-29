using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.ProjetoFifa2018.Dominio.Entidades.Torneios
{
    public class Torneio
    {
        public int QuantidadeDeTimes { get; set; }
        public int QuantidadeDeGrupos { get; set; }
        public DateTime DataDeInicioDoTorneio { get; set; }
    }
}
