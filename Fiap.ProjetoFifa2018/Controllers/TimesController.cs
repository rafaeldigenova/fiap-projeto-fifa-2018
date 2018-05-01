using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Fiap.ProjetoFifa2018.Models;
using Fiap.ProjetoFifa2018.Persistencia.Contexto;
using System.Linq;

namespace Fiap.ProjetoFifa2018.Web.Controllers
{
    public class TimesController : Controller
    {
        private readonly CopaContexto _contexto;

        public TimesController(CopaContexto contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("admin"))
                {
                    return View(_contexto.Times.ToList());
                }
                else
                {
                    return RedirectToAction("Denied", "Account");
                }
            }

            return RedirectToAction("Index", "Account");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
