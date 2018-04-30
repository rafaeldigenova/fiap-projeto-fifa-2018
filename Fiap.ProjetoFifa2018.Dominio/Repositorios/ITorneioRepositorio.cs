using Fiap.ProjetoFifa2018.Dominio.Entidades.Torneios;
using Fiap.ProjetoFifa2018.Infra.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.ProjetoFifa2018.Dominio.Repositorios
{
    public interface ITorneioRepositorio
    {
        Pagina<Torneio> ObterTorneiosPaginados(int paginaAtual, int itensPorPagina);
        Torneio ObterTorneioPorId(int id);
        Torneio CadastrarTorneio(Torneio torneio);
        Torneio AtualizarTorneio(Torneio torneio);
        void DeletarTorneio(int id);
    }
}
