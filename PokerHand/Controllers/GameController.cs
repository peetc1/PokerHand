using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using PokerHand.Business.Interfaces;
using PokerHand.Models;

namespace PokerHand.Controllers
{
    public partial class GameController : AsyncController
    {
        //private readonly IDeckService _deck;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameController"/> class.
        /// </summary>
        /// <param name="deck">The deck.</param>
        /// <param name="comparer">The comparer for poker hands</param>
        public GameController()
        {
            //_deck = deck;
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
    }
}