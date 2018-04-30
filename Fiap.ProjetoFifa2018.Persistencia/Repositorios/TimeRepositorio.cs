using Fiap.ProjetoFifa2018.Persistencia.Contexto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.ProjetoFifa2018.Persistencia.Repositorios
{
    public class TimeRepositorio
    {
        private CopaContexto _contexto;

        public TimeRepositorio(CopaContexto contexto)
        {
            _contexto = contexto;
        }
    }
}
