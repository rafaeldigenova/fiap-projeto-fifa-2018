using Fiap.ProjetoFifa2018.Dominio.Entidades.Times;
using Fiap.ProjetoFifa2018.Infra.Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.ProjetoFifa2018.Dominio.Repositorios
{
    public interface ITimeRepositorio
    {
        Pagina<Time> ObterTimesPaginados(int paginaAtual, int itensPorPagina);
        List<Time> ObterTimes();
        Time ObterTimePorId(int id);
        Task<Time> CadastrarTime(Time time);
        Task<Time> AtualizarTime(Time time);
        Task DeletarTime(int id);
    }
}
