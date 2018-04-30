using Fiap.ProjetoFifa2018.Dominio.Entidades.Torneios;
using Fiap.ProjetoFifa2018.Dominio.Repositorios;
using Fiap.ProjetoFifa2018.Persistencia.Contexto;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Fiap.ProjetoFifa2018.Infra.Dominio;
using Fiap.ProjetoFifa2018.Dominio.Exceptions.Torneios;

namespace Fiap.ProjetoFifa2018.Persistencia.Repositorios
{
    public class TorneioRepositorio : ITorneioRepositorio
    {
        private CopaContexto _contexto;

        public TorneioRepositorio(CopaContexto contexto)
        {
            _contexto = contexto;
        }

        public Torneio AtualizarTorneio(Torneio torneio)
        {
            var timeNoBanco = ObterTorneioPorId(torneio.Id);

            if (timeNoBanco == null)
                throw new TorneioNaoEncontradoException();

            _contexto.Torneios.Update(torneio);

            return torneio;
        }

        public Torneio CadastrarTorneio(Torneio torneio)
        {
            var timeNoBanco = ObterTorneioPorId(torneio.Id);

            if (timeNoBanco != null)
                throw new NaoEPossivelCadastrarTorneioComIdJaExistenteException();

            _contexto.Torneios.Update(torneio);

            return torneio;
        }

        public void DeletarTorneio(int id)
        {
            var timeNoBanco = ObterTorneioPorId(id);

            if (timeNoBanco == null)
                throw new TorneioNaoEncontradoException();

            _contexto.Torneios.Remove(timeNoBanco);
        }

        public Torneio ObterTorneioPorId(int id)
        {
            return _contexto.Torneios.FirstOrDefault(x => x.Id == id);
        }

        public Pagina<Torneio> ObterTorneiosPaginados(int paginaAtual, int itensPorPagina)
        {
            var pagina = new Pagina<Torneio>()
            {
                Itens = _contexto.Torneios.Skip(itensPorPagina * (paginaAtual - 1)).Take(itensPorPagina).ToList(),
                TotalDeItens = _contexto.Torneios.Count()
            };

            return pagina;
        }
    }
}
