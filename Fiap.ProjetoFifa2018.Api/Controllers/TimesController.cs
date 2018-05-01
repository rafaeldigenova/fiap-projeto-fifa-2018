using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiap.ProjetoFifa2018.Dominio.Entidades.Times;
using Fiap.ProjetoFifa2018.Dominio.Exceptions.Times;
using Fiap.ProjetoFifa2018.Dominio.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.ProjetoFifa2018.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Times")]
    public class TimesController : Controller
    {
        private readonly ITimeRepositorio _timeRepositorio;

        public TimesController(ITimeRepositorio timeRepositorio)
        {
            _timeRepositorio = timeRepositorio;
        }

        [HttpGet]
        public IActionResult Get(int paginaAtual = 1, int itensPorPagina = 10)
        {
            return Ok(_timeRepositorio.ObterTimesPaginados(paginaAtual, itensPorPagina));
        }

        [HttpGet("{id}", Name="GetTimes")]
        public IActionResult Get(int id)
        {
            return Ok(_timeRepositorio.ObterTimePorId(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Time time)
        {
            try
            {
                var timeCadastrado = await _timeRepositorio.CadastrarTime(time);

                return CreatedAtRoute(routeName: "GetTimes",
                                      routeValues: new { id = timeCadastrado.Id },
                                      value: timeCadastrado);
            }
            catch (NaoEPossivelCadastrarTimeComIdJaExistenteException)
            {
                return StatusCode(StatusCodes.Status409Conflict);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Time time)
        {
            try
            {
                var timeAtualizado = await _timeRepositorio.AtualizarTime(time);

                return Ok(timeAtualizado);
            }
            catch (TimeNaoEncontradoException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _timeRepositorio.DeletarTime(id);

                return Ok();
            }
            catch (TimeNaoEncontradoException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
