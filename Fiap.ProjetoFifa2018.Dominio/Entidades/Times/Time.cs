using Fiap.ProjetoFifa2018.Dominio.Exceptions;
using Fiap.ProjetoFifa2018.Dominio.Jogadores;
using Fiap.ProjetoFifa2018.Infra.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiap.ProjetoFifa2018.Dominio.Entidades.Times
{
    public class Time : EntidadeBase
    {
        public string NomeDoTime { get; set; }
        public string Escudo { get; set; }

        private List<Jogador> _jogadores { get; }
        public IReadOnlyCollection<Jogador> Jogadores
        {
            get
            {
                return _jogadores.ToArray();
            }
        }

        public Time()
        {
            _jogadores = new List<Jogador>();
        }

        /// <summary>
        /// Adiciona o Jogador ao time
        /// </summary>
        /// <param name="jogador"></param>
        /// <exception cref="JogadorJaCadastradoNoTimeException">Retorna exceção caso o jogador já tenha sido adicionado ao time</exception>
        public void AdicionarJogador(Jogador jogador)
        {
            var jogadorDoTime = _jogadores.Where(x => x.Id == jogador.Id).FirstOrDefault();

            if (jogadorDoTime != null)
                throw new JogadorJaCadastradoNoTimeException();

            _jogadores.Add(jogador);
        }

        /// <summary>
        /// Adiciona apenas os jogadores que ainda não estiverem no time, ignora os demais
        /// </summary>
        /// <param name="jogadores"></param>
        public void AdicionarJogadores(List<Jogador> jogadores)
        {
            var jogadoresASeremAdicionados = jogadores.Where(x => !_jogadores.Any(y => y.Id == x.Id));
            _jogadores.AddRange(jogadoresASeremAdicionados);
        }

        /// <summary>
        /// Remove os jogadores do time
        /// </summary>
        /// <param name="jogadores"></param>
        public void RemoverJogadores(List<Jogador> jogadores)
        {
            jogadores.ForEach(x => _jogadores.Remove(x));
        }
    }
}
