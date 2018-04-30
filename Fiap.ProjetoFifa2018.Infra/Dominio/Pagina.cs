using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.ProjetoFifa2018.Infra.Dominio
{
    public class Pagina<T>
    {
        public List<T> Itens { get; set; }
        public int TotalDeItens { get; set; }
        public int PaginaAtual { get; set; }
        public int ItensPorPagina { get; set; }

        public Pagina()
        {
            Itens = new List<T>();
            PaginaAtual = 1;
            ItensPorPagina = 10;
        }
    }
}
