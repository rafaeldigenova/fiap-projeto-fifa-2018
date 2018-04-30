using Fiap.ProjetoFifa2018.Infra.Dominio;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Fiap.ProjetoFifa2018.Dominio.Entidades.Times;

namespace Fiap.ProjetoFifa2018.Dominio.Entidades.Partidas
{
    public class Partida : EntidadeBase
    {
        public int IdDoTimeMandante { get; set; }
        public int IdDoTimeVisitante { get; set; }
        public int? IdDoTimeVencedor { get; set; }
        public string NomeDoTimeMandante { get; set; }
        public string NomeDoTimeVisitante { get; set; }
        public DateTime DataDaPartida { get; set; }


        private List<GolsDaPartida> _gols;
        public IReadOnlyCollection<GolsDaPartida> Gols
        {
            get { return _gols.ToArray(); }
        }

        public Partida()
        {
            _gols = new List<GolsDaPartida>();
        }

        public int ObterGolsDoMandante()
        {
            return _gols.Where(x => x.IdDoTimeQueMarcou == IdDoTimeMandante).Count();
        }

        public int ObterGolsDoVisitante ()
        {
            return _gols.Where(x => x.IdDoTimeQueMarcou == IdDoTimeVisitante).Count();
        }
    }
}
