using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Fiap.ProjetoFifa2018.Dominio.Entidades.Torneios;
using Fiap.ProjetoFifa2018.Dominio.Repositorios;

namespace Fiap.ProjetoFifa2018.Aplicacao.Grupos
{
    public class ServicoGrupo : IServicoGrupo
    {
        public ITorneioRepositorio _repositorioTorneios;

        public ServicoGrupo(ITorneioRepositorio repositorioTorneios)
        {
            _repositorioTorneios = repositorioTorneios;
        }

        public List<Grupo> ObterGrupos()
        {
            var torneio = _repositorioTorneios.ObterTorneioPorId(1);

            return torneio.Grupos.ToList();
        }
    }
}
