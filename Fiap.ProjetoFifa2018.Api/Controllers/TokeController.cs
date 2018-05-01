using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Fiap.ProjetoFifa2018.Dominio.Entidades.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Fiap.ProjetoFifa2018.Api.Controllers
{
    [Route("/token")]
    public class TokenController : Controller
    {
        [HttpPost]
        public IActionResult Create([FromBody]TokenInfo model)
        {
            if (IsValidUserAndPasswordCombination(model.username, model.password))
            {
                var token = GenerateToken(model.username);
                //Salvar no DB
                return new ObjectResult(token);

            }
            return BadRequest();
        }

        private bool IsValidUserAndPasswordCombination(object username, object password)
        {
            throw new NotImplementedException();
        }

        private bool IsValidUserAndPasswordCombination(string username, string password)
        {
            return !string.IsNullOrEmpty(username) && username == password;
        }

        private string GenerateToken(string username)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString()),
            };

            var token = new JwtSecurityToken(
                new JwtHeader(new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes("the secret that needs to be at least 16 characeters long for HmacSha256")),
                                             SecurityAlgorithms.HmacSha256)),
                new JwtPayload(claims));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
