using Fiap.ProjetoFifa2018.Dominio.Entidades.Times;
using Fiap.ProjetoFifa2018.Infra.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.ProjetoFifa2018.Dominio.Repositorios
{
    public interface ITimeRepositorio
    {
        Pagina<Time> ObterTimesPaginados(int paginaAtual, int itensPorPagina);
        Time ObterTimePorId(int id);
        Time CadastrarTime(Time time);
        Time AtualizarTime(Time time);
        void DeletarTime(int id);
    }
}
