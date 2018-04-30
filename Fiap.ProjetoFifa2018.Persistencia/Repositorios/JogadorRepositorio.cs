using Fiap.ProjetoFifa2018.Dominio.Exceptions.Jogadores;
using Fiap.ProjetoFifa2018.Dominio.Entidades.Jogadores;
using Fiap.ProjetoFifa2018.Dominio.Repositorios;
using Fiap.ProjetoFifa2018.Infra.Dominio;
using Fiap.ProjetoFifa2018.Persistencia.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiap.ProjetoFifa2018.Persistencia.Repositorios
{
    public class JogadorRepositorio : IJogadorRepositorio
    {
        private CopaContexto _contexto;

        public JogadorRepositorio(CopaContexto contexto)
        {
            _contexto = contexto;
        }

        public Jogador AtualizarJogador(Jogador jogador)
        {
            var jogadorNoBanco = ObterJogadorPorId(jogador.Id);

            if (jogadorNoBanco == null)
                throw new JogadorNaoEncontradoException();

            _contexto.Jogadores.Update(jogador);

            return jogador;
        }

        public Jogador CadastrarJogador(Jogador jogador)
        {
            var jogadorNoBanco = ObterJogadorPorId(jogador.Id);

            if (jogadorNoBanco != null)
                throw new NaoEPossivelCadastrarJogadorComIdJaExistenteException();

            _contexto.Jogadores.Update(jogador);

            return jogador;
        }

        public void DeletarJogador(int id)
        {
            var jogadorNoBanco = ObterJogadorPorId(id);

            if (jogadorNoBanco == null)
                throw new JogadorNaoEncontradoException();

            _contexto.Jogadores.Remove(jogadorNoBanco);
        }

        public Pagina<Jogador> ObterJogadoresPaginados(int paginaAtual, int itensPorPagina)
        {
            var pagina = new Pagina<Jogador>()
            {
                Itens = _contexto.Jogadores.Skip(itensPorPagina * (paginaAtual - 1)).Take(itensPorPagina).ToList(),
                TotalDeItens = _contexto.Jogadores.Count()
            };

            return pagina;
        }

        public Jogador ObterJogadorPorId(int id)
        {
            return _contexto.Jogadores.FirstOrDefault(x => x.Id == id);
        }
    }
}
