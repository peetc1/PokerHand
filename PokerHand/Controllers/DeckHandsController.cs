using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PokerHand.Business.Interfaces;
using PokerHand.Business.Objects;
using PokerHand.Models;

namespace PokerHand.Controllers
{
    public class DeckHandsController : ApiController
    {
        private IDeckService _deck;
        private readonly IHandComparerService _comparer;
        private const int HandSize = 5;

        // for some reason ninject isn't working (built no arg constructor)
        public DeckHandsController()
        {
            _deck = new DeckService();
            _comparer = new HandComparerService();
        }

        public DeckHandsController(IDeckService deck, IHandComparerService comparer)
        {
            _deck = deck;
            _comparer = comparer;
        }
        
        // Shuffle api/<controller>
        [HttpGet]
        public void Shuffle()
        {
            // shuffle deck
            _deck = _deck.Shuffle();
        }

        /// <summary>
        /// Calculates the winner.
        /// </summary>
        /// <param name="player1">The player1 including thier current hand.</param>
        /// <param name="player2">The player2 including thier current hand.</param>
        /// <returns>Winner.</returns>
        private Winner CalculateWinner(Player player1, Player player2)
        {
            // determine hand winner
            return _comparer.GetWinner(player1, player2);
        }

        public GameModel Deal(Player player1, Player player2)
        {
            // add cards to hands alternately
            for (var i = 0; i < HandSize; i++)
            {
                player1.Hand[i] = _deck.GetNextCard();
                player2.Hand[i] = _deck.GetNextCard();
            }

            // shuffle deck
            if (_deck.GetCardsLeft() < 10) _deck.Shuffle();

            // return player hands and winner
            return new GameModel
            {
                Player1 = player1,
                Player2 = player2,
                GameWinner = CalculateWinner(player1,player2)
            };
        }

        /*
          

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }
        

        
        */
    }
}