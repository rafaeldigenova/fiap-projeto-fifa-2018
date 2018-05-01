using Fiap.ProjetoFifa2018.Dominio.Entidades.Torneios;
using Fiap.ProjetoFifa2018.Infra.Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.ProjetoFifa2018.Dominio.Repositorios
{
    public interface ITorneioRepositorio
    {
        Pagina<Torneio> ObterTorneiosPaginados(int paginaAtual, int itensPorPagina);
        Torneio ObterTorneioPorId(int id);
        Torneio ObterTorneioPorNome(string nome);
        Task<Torneio> CadastrarTorneio(Torneio torneio);
        Task<Torneio> AtualizarTorneio(Torneio torneio);
        Task DeletarTorneio(int id);
    }
}
