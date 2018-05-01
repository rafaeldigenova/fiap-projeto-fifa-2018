using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Fiap.ProjetoFifa2018.Models;
using Fiap.ProjetoFifa2018.Persistencia.Contexto;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Fiap.ProjetoFifa2018.Dominio.Entidades.Jogadores;

namespace Fiap.ProjetoFifa2018.Web.Controllers
{
    public class JogadoresController : Controller
    {
        private readonly CopaContexto _contexto;

        public JogadoresController(CopaContexto contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("admin"))
                {
                    return View(_contexto.Jogadores.ToList());
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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Nome,NumeroDaCamisa,Posicao,DataDeNascimento")] Jogador jogador)
        {
            if (ModelState.IsValid)
            {
                _contexto.Add(jogador);
                _contexto.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(jogador);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogador = _contexto.Jogadores.SingleOrDefault(x => x.Id == id);

            if (jogador == null)
            {
                return NotFound();
            }

            return View(jogador);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Nome,NumeroDaCamisa,Posicao,DataDeNascimento")] Jogador jogador)
        {
            if (id != jogador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _contexto.Update(jogador);
                    _contexto.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JogadorExists(jogador.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(jogador);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogador = _contexto.Jogadores.SingleOrDefault(x => x.Id == id);

            if (jogador == null)
            {
                return NotFound();
            }

            return View(jogador);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var jogador = _contexto.Jogadores.SingleOrDefault(x => x.Id == id);
            _contexto.Jogadores.Remove(jogador);
            _contexto.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private bool JogadorExists(int id)
        {
            return _contexto.Jogadores.Any(x => x.Id == id);
        }
    }
}
