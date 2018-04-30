using Fiap.ProjetoFifa2018.Dominio.Entidades.Jogadores;
using Fiap.ProjetoFifa2018.Infra.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.ProjetoFifa2018.Dominio.Repositorios
{
    public interface IJogadorRepositorio
    {
        Pagina<Jogador> ObterJogadoresPaginados(int paginaAtual, int itensPorPagina);
        Jogador ObterJogadorPorId(int id);
        Jogador CadastrarJogador(Jogador jogador);
        Jogador AtualizarJogador(Jogador jogador);
        void DeletarJogador(int id);
    }
}
