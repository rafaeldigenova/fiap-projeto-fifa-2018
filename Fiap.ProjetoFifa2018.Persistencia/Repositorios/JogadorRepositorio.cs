﻿using Fiap.ProjetoFifa2018.Persistencia.Contexto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.ProjetoFifa2018.Persistencia.Repositorios
{
    public class JogadorRepositorio
    {
        private CopaContexto _contexto;

        public JogadorRepositorio(CopaContexto contexto)
        {
            _contexto = contexto;
        }
    }
}
