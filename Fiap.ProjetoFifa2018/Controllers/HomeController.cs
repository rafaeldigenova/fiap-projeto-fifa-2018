using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Fiap.ProjetoFifa2018.Models;

namespace Fiap.ProjetoFifa2018.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
