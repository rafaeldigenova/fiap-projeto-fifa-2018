using Fiap.ProjetoFifa2018.Aplicacao.Grupos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.ProjetoFifa2018.Web.ViewComponents
{
    [ViewComponent(Name = "Grupo")]
    public class GrupoViewComponents : ViewComponent
    {
        private IServicoGrupo _servicoGrupo;

        public GrupoViewComponents(IServicoGrupo servicoGrupo)
        {
            _servicoGrupo = servicoGrupo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var view = "grupo";

            var grupos = _servicoGrupo.ObterGrupos();

            return View(view, grupos);
        }
    }
}
