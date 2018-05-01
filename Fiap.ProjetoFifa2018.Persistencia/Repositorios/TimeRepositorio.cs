using Fiap.ProjetoFifa2018.Dominio.Entidades.Times;
using Fiap.ProjetoFifa2018.Dominio.Exceptions.Times;
using Fiap.ProjetoFifa2018.Dominio.Repositorios;
using Fiap.ProjetoFifa2018.Infra.Dominio;
using Fiap.ProjetoFifa2018.Persistencia.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.ProjetoFifa2018.Persistencia.Repositorios
{
    public class TimeRepositorio : ITimeRepositorio
    {
        private CopaContexto _contexto;

        public TimeRepositorio(CopaContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<Time> AtualizarTime(Time time)
        {
            var timeNoBanco = ObterTimePorId(time.Id);

            if (timeNoBanco == null)
                throw new TimeNaoEncontradoException();

            _contexto.Times.Update(time);

            await _contexto.SaveChangesAsync();

            return time;
        }

        public async Task<Time> CadastrarTime(Time time)
        {
            var timeNoBanco = ObterTimePorId(time.Id);

            if (timeNoBanco != null)
                throw new NaoEPossivelCadastrarTimeComIdJaExistenteException();

            _contexto.Times.Update(time);

            await _contexto.SaveChangesAsync();

            return time;
        }

        public async Task DeletarTime(int id)
        {
            var timeNoBanco = ObterTimePorId(id);

            if (timeNoBanco == null)
                throw new TimeNaoEncontradoException();

            _contexto.Times.Remove(timeNoBanco);

            await _contexto.SaveChangesAsync();
        }

        public Time ObterTimePorId(int id)
        {
            return _contexto.Times.FirstOrDefault(x => x.Id == id);
        }

        public Pagina<Time> ObterTimesPaginados(int paginaAtual, int itensPorPagina)
        {
            var pagina = new Pagina<Time>()
            {
                Itens = _contexto.Times.Skip(itensPorPagina * (paginaAtual - 1)).Take(itensPorPagina).ToList(),
                TotalDeItens = _contexto.Times.Count()
            };

            return pagina;
        }
    }
}
