using Fiap.ProjetoFifa2018.Dominio.Entidades.Times;
using Fiap.ProjetoFifa2018.Dominio.Exceptions;
using Fiap.ProjetoFifa2018.Infra.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fiap.ProjetoFifa2018.Dominio.Entidades.Torneios
{
    public class Grupo : EntidadeBase
    {
        public string Nome { get; set; }
        public Torneio Torneio { get; set; }

        public List<TimeDoGrupo> Times { get; set; }

        public Grupo()
        {
            Times = new List<TimeDoGrupo>();
        }

        /// <summary>
        /// Adiciona o Time ao grupo
        /// </summary>
        /// <param name="time" cref="TimeDoGrupo"></param>
        /// <exception cref="JogadorJaCadastradoNoTimeException">Retorna exceção caso o time já tenha sido adicionado ao grupo</exception>
        public void AdicionarTime(TimeDoGrupo time)
        {
            var timeDoGrupo = Times.Where(x => x.Id == time.Id).FirstOrDefault();

            if (timeDoGrupo != null && time.Id != 0)
                throw new TimeJaCadastradoNoGrupoException();

            time.Grupo = this;

            Times.Add(time);
        }

        /// <summary>
        /// Adiciona apenas os times que ainda não estiverem no grupo, ignora os demais
        /// </summary>
        /// <param name="times" cref="TimeDoGrupo"></param>
        public void AdicionarJogadores(List<TimeDoGrupo> times)
        {
            var timesASeremAdicionados = times.Where(x => !Times.Any(y => y.Id == x.Id));

            foreach (var time in timesASeremAdicionados)
            {
                time.Grupo = this;
            }

            Times.AddRange(timesASeremAdicionados);
        }

        /// <summary>
        /// Remove os times do grupo
        /// </summary>
        /// <param name="times"></param>
        public void RemoverTimes(List<TimeDoGrupo> times)
        {
            times.ForEach(x => Times.Remove(x));
        }
    }
}
