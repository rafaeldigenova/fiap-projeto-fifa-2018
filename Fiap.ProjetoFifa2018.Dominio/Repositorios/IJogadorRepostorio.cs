using Fiap.ProjetoFifa2018.Dominio.Entidades.Jogadores;
using Fiap.ProjetoFifa2018.Infra.Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.ProjetoFifa2018.Dominio.Repositorios
{
    public interface IJogadorRepositorio
    {
        Pagina<Jogador> ObterJogadoresPaginados(int paginaAtual, int itensPorPagina);
        Jogador ObterJogadorPorId(int id);
        Task<Jogador> CadastrarJogador(Jogador jogador);
        Task<Jogador> AtualizarJogador(Jogador jogador);
        Task DeletarJogador(int id);
    }
}
