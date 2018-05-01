using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiap.ProjetoFifa2018.Dominio.Entidades.Jogadores;
using Fiap.ProjetoFifa2018.Dominio.Exceptions.Jogadores;
using Fiap.ProjetoFifa2018.Dominio.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.ProjetoFifa2018.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Jogadores")]
    public class JogadoresController : Controller
    {
        private readonly IJogadorRepositorio _jogadorRepositorio;

        public JogadoresController(IJogadorRepositorio jogadorRepositorio)
        {
            _jogadorRepositorio = jogadorRepositorio;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get(int paginaAtual, int itensPorPagina)
        {
            return Ok(_jogadorRepositorio.ObterJogadoresPaginados(paginaAtual, itensPorPagina));
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetJogador")]
        public IActionResult Get(int id)
        {
            return Ok(_jogadorRepositorio.ObterJogadorPorId(id));
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Jogador jogador)
        {
            try
            {
                var jogadorCadastrado = await _jogadorRepositorio.CadastrarJogador(jogador);

                return CreatedAtRoute(routeName: "GetJogador",
                                      routeValues: new { id = jogadorCadastrado.Id },
                                      value: jogadorCadastrado);
            }
            catch (NaoEPossivelCadastrarJogadorComIdJaExistenteException ex)
            {
                return StatusCode(StatusCodes.Status409Conflict);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Jogador jogador)
        {
            try
            {
                var jogadorAtualizado = await _jogadorRepositorio.AtualizarJogador(jogador);

                return Ok(jogadorAtualizado);
            }
            catch (JogadorNaoEncontradoException ex)
            {
                return NotFound();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _jogadorRepositorio.DeletarJogador(id);

                return Ok();
            }
            catch (JogadorNaoEncontradoException ex)
            {
                return NotFound();
            }
        }
    }
}
