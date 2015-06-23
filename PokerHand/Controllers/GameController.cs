using System;
using System.Collections.Generic;
using System.Web.Mvc;
using PokerHand.Business.Interfaces;
using PokerHand.Business.Objects;
using PokerHand.Models;

namespace PokerHand.Controllers
{
    public partial class GameController : Controller
    {
        private IDeckService _deck;
        private IHandComparerService _comparer;
        private const int HandSize = 5;

        // this is for unit testing purposes only rather than using Moq etc
        public GameController()
        {
            _deck = new DeckService();
            _comparer = new HandComparerService();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameController"/> class.
        /// </summary>
        /// <param name="deck">The deck.</param>
        /// <param name="comparer">The comparer for poker hands</param>
        public GameController(IDeckService deck, IHandComparerService comparer)
        {
            // initialize or pull from session for re-usable deck (would normally just use database)
            System.Web.HttpContext.Current.Session["DeckService"] = System.Web.HttpContext.Current.Session["DeckService"] ?? deck;
            _deck = (IDeckService)System.Web.HttpContext.Current.Session["DeckService"];
            _comparer = comparer;
        }

        // GET: Game
        [HttpGet]
        public virtual ActionResult Index(string playerName1, string playerName2)
        {
            // something is wrong go back to home page
            if (String.IsNullOrEmpty(playerName1) || String.IsNullOrEmpty(playerName2))
            {
                return RedirectToAction(MVC.Home.Index());
            }

            // build model
            var model = new GameModel(playerName1, playerName2);

            return View(model);
        }

        // Shuffle the deck
        [HttpPost]
        public void Shuffle()
        {
            // shuffle deck
            _deck.Shuffle();
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

        /// <summary>
        /// Deals to the specified players.
        /// </summary>
        /// <param name="players">The players.</param>
        /// <returns>JsonResult.</returns>
        [HttpPost]
        public virtual JsonResult Deal(Players players)
        {
            // clear hands
            players.Player1.Hand = new List<Card>();
            players.Player2.Hand = new List<Card>();

            // add cards to hands alternately
            for (var i = 0; i < HandSize; i++)
            {
                players.Player1.Hand.Add(_deck.GetNextCard());
                players.Player2.Hand.Add(_deck.GetNextCard());
            }

            // shuffle deck if there's only 10 left
            if (_deck.GetCardsLeft() < 10) _deck.Shuffle();

            // return player hands and winner
            return Json(new GameModel
            {
                Player1 = players.Player1,
                Player2 = players.Player2,
                GameWinner = CalculateWinner(players.Player1, players.Player2)
            });
        }
    }
}