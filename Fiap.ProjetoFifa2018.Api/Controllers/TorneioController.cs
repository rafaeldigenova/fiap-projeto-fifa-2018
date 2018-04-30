using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiap.ProjetoFifa2018.Dominio.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.ProjetoFifa2018.Api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ITorneioRepositorio _torneioRepositorio;

        public ValuesController(ITorneioRepositorio torneioRepositorio)
        {
            _torneioRepositorio = torneioRepositorio;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_torneioRepositorio.ObterTorneios());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_torneioRepositorio.ObterTorneioPorId(id));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
