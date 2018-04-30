using Fiap.ProjetoFifa2018.Persistencia.Contexto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.ProjetoFifa2018.Persistencia.Repositorios
{
    public class TorneioRepositorio
    {
        private CopaContexto _contexto;

        public TorneioRepositorio(CopaContexto contexto)
        {
            _contexto = contexto;
        }

    }
}
