using Fiap.ProjetoFifa2018.Aplicacao.Grupos;
using Fiap.ProjetoFifa2018.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.ProjetoFifa2018.Web.ViewComponents
{
    [ViewComponent(Name = "Grupos")]
    public class GruposViewComponents : ViewComponent
    {
        private IServicoGrupo _servicoGrupo;

        public GruposViewComponents(IServicoGrupo servicoGrupo)
        {
            _servicoGrupo = servicoGrupo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var view = "grupo";

            var grupos = _servicoGrupo.ObterGrupos();

            var model = grupos.Select(x => new GrupoViewModel()
            {
                NomeDoGrupo = x.Nome,
                Times = x.Times.Select(y => new TimeViewModel()
                {
                    Escudo = y.Escudo,
                    NomeDoTime = y.NomeDoTime
                }).ToList()
            }).ToList();

            return View(view, model);
        }
    }
}
