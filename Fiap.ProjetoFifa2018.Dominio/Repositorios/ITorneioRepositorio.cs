using Fiap.ProjetoFifa2018.Dominio.Entidades.Torneios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.ProjetoFifa2018.Dominio.Repositorios
{
    public interface ITorneioRepositorio
    {
        List<Torneio> ObterTorneios();
        Torneio ObterTorneioPorId(int id);
    }
}
