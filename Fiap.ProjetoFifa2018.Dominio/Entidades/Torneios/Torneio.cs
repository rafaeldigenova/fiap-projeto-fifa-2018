using Fiap.ProjetoFifa2018.Dominio.Entidades.Times;
using Fiap.ProjetoFifa2018.Dominio.Exceptions;
using Fiap.ProjetoFifa2018.Infra.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fiap.ProjetoFifa2018.Dominio.Entidades.Torneios
{
    public class Torneio : EntidadeBase
    {
        public int QuantidadeDeTimes { get; set; }
        public int QuantidadeDeGrupos { get; set; }
        public DateTime DataDeInicioDoTorneio { get; set; }

        private List<Grupo> _grupos { get; }
        public IReadOnlyCollection<Grupo> Grupos
        {
            get
            {
                return _grupos.ToArray();
            }
        }

        public Torneio()
        {
            _grupos = new List<Grupo>();
        }

        /// <summary>
        /// Adiciona o Grupo ao torneio
        /// </summary>
        /// <param name="grupo"></param>
        /// <exception cref="JogadorJaCadastradoNoTimeException">Retorna exceção caso o grupo já tenha sido adicionado ao torneio</exception>
        public void AdicionarJogador(Grupo grupo)
        {
            var grupoDoTorneio = _grupos.Where(x => x.Id == grupo.Id).FirstOrDefault();

            if (grupoDoTorneio != null)
                throw new TimeJaCadastradoNoGrupoException();

            _grupos.Add(grupo);
        }

        /// <summary>
        /// Adiciona apenas os grupos que ainda não estiverem no torneio, ignora os demais
        /// </summary>
        /// <param name="grupos"></param>
        public void AdicionarGrupos(List<Grupo> grupos)
        {
            var gruposASeremAdicionados = grupos.Where(x => !_grupos.Any(y => y.Id == x.Id));
            _grupos.AddRange(gruposASeremAdicionados);
        }

        /// <summary>
        /// Remove os grupos do torneio
        /// </summary>
        /// <param name="grupos"></param>
        public void RemoverGrupos(List<Grupo> grupos)
        {
            grupos.ForEach(x => _grupos.Remove(x));
        }
    }
}
