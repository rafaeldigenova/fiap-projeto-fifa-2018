using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiap.ProjetoFifa2018.Dominio.Entidades.Torneios;
using Fiap.ProjetoFifa2018.Dominio.Exceptions.Torneios;
using Fiap.ProjetoFifa2018.Dominio.Repositorios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.ProjetoFifa2018.Api.Controllers
{
    [Authorize(Roles = "admins")]
    [Produces("application/json")]
    [Route("api/Torneios")]
    public class TorneiosController : Controller
    {
        private readonly ITorneioRepositorio _torneioRepositorio;

        public TorneiosController(ITorneioRepositorio torneioRepositorio)
        {
            _torneioRepositorio = torneioRepositorio;
        }

        [HttpGet]
        public IActionResult Get(int paginaAtual, int itensPorPagina)
        {
            return Ok(_torneioRepositorio.ObterTorneiosPaginados(paginaAtual, itensPorPagina));
        }

        [HttpGet("{id}", Name = "GetTorneios")]
        public IActionResult Get(int id)
        {
            return Ok(_torneioRepositorio.ObterTorneioPorId(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Torneio torneio)
        {
            try
            {
                var torneioCadastrado = await _torneioRepositorio.CadastrarTorneio(torneio);

                return CreatedAtRoute(routeName: "GetTorneios",
                                      routeValues: new { id = torneioCadastrado.Id },
                                      value: torneioCadastrado);
            }
            catch (NaoEPossivelCadastrarTorneioComIdJaExistenteException)
            {
                return StatusCode(StatusCodes.Status409Conflict);    
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Torneio torneio)
        {
            try
            {
                var torneioAtualizado = await _torneioRepositorio.AtualizarTorneio(torneio);

                return Ok(torneioAtualizado);
            }
            catch(TorneioNaoEncontradoException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _torneioRepositorio.DeletarTorneio(id);

                return Ok();
            }
            catch (TorneioNaoEncontradoException)
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
