using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Fiap.ProjetoFifa2018.Models;
using Fiap.ProjetoFifa2018.Persistencia.Contexto;
using System.Linq;
using Fiap.ProjetoFifa2018.Dominio.Entidades.Times;
using Fiap.ProjetoFifa2018.Dominio.Repositorios;
using System.Threading.Tasks;
using Fiap.ProjetoFifa2018.Dominio.Exceptions.Times;

namespace Fiap.ProjetoFifa2018.Web.Controllers
{
    public class TimesController : Controller
    {
        private readonly ITimeRepositorio _timeRepositorio;

        public TimesController(ITimeRepositorio timeRepositorio)
        {
            _timeRepositorio = timeRepositorio;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("admin"))
                {
                    //Todo: implementar paginação
                    return View(_timeRepositorio.ObterTimes());
                }
                else
                {
                    return RedirectToAction("Denied", "Account");
                }
            }

            return RedirectToAction("Index", "Account");
        }

        public IActionResult Create()
        {
            var model = new Time();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Time time)
        {
            if (!ModelState.IsValid)
            {
                return View(time);
            }

            await _timeRepositorio.CadastrarTime(time);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var time = _timeRepositorio.ObterTimePorId(id.Value);

            if (time == null)
            {
                return NotFound();
            }

            return View(time);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Time time)
        {
            if (time.Id == 0 || time.Id == null)
            {
                return NotFound();
            }

            try
            {
                await _timeRepositorio.AtualizarTime(time);
            }catch(TimeNaoEncontradoException ex)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }

        public IActionResult ConfirmDelete(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var time = _timeRepositorio.ObterTimePorId(id.Value);

            if (time == null)
            {
                return NotFound();
            }

            return View(time);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }
            try
            {
                await _timeRepositorio.DeletarTime(id.Value);
            }
            catch (TimeNaoEncontradoException ex)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
