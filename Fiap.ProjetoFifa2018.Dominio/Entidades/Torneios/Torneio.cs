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
        public string Nome { get; set; }

        public List<Grupo> Grupos { get; set; }

        public Torneio()
        {
            Grupos = new List<Grupo>();
        }

        /// <summary>
        /// Adiciona o Grupo ao torneio
        /// </summary>
        /// <param name="grupo"></param>
        /// <exception cref="JogadorJaCadastradoNoTimeException">Retorna exceção caso o grupo já tenha sido adicionado ao torneio</exception>
        public void AdicionarGrupo(Grupo grupo)
        {
            var grupoDoTorneio = Grupos.Where(x => x.Id == grupo.Id).FirstOrDefault();

            if (grupoDoTorneio != null && grupo.Id != 0)
                throw new TimeJaCadastradoNoGrupoException();

            grupo.Torneio = this;

            Grupos.Add(grupo);
        }

        /// <summary>
        /// Adiciona apenas os grupos que ainda não estiverem no torneio, ignora os demais
        /// </summary>
        /// <param name="grupos"></param>
        public void AdicionarGrupos(List<Grupo> grupos)
        {
            var gruposASeremAdicionados = grupos.Where(x => !Grupos.Any(y => y.Id == x.Id));
            foreach(var grupo in gruposASeremAdicionados)
            {
                grupo.Torneio = this;
            }
            Grupos.AddRange(gruposASeremAdicionados);
        }

        /// <summary>
        /// Remove os grupos do torneio
        /// </summary>
        /// <param name="grupos"></param>
        public void RemoverGrupos(List<Grupo> grupos)
        {
            grupos.ForEach(x => Grupos.Remove(x));
        }
    }
}
