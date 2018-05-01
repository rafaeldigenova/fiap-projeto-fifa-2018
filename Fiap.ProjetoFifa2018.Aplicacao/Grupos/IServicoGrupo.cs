using Fiap.ProjetoFifa2018.Dominio.Entidades.Torneios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.ProjetoFifa2018.Aplicacao.Grupos
{
    public interface IServicoGrupo
    {
        List<Grupo> ObterGrupos();
    }
}
