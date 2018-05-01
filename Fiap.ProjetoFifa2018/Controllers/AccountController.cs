using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.ProjetoFifa2018.Web.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Times");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ViewModel.LoginViewModel model)
        {
            if (model.UserName == "lucas" && model.Password == "123")
            {
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, model.UserName));
                claims.Add(new Claim(ClaimTypes.Role, "admin"));
                var id = new ClaimsIdentity(claims, "password");                
                var principal = new ClaimsPrincipal(id);

                await HttpContext.SignInAsync("app", principal, new AuthenticationProperties() { IsPersistent = model.IsPersistent });

                return RedirectToAction("Index", "Home");
            }

            return View("NotFound");
        }

        public async Task<IActionResult> Logoff()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}