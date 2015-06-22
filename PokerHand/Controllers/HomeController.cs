using System;
using System.Web.Mvc;
using PokerHand.Models;

namespace PokerHand.Controllers
{
    public partial class HomeController : Controller
    {
        [HttpGet]
        public virtual ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult Index(IndexModel model)
        {
            // model isn't valid try again
            if (!ModelState.IsValid) return View(model);

            // have to copy to create 2 brand new variables to avoid null ref error on game controller
            var player1 = String.Copy(model.PlayerName1);
            var player2 = String.Copy(model.PlayerName2);

            // go to game page
            return RedirectToAction(MVC.Game.Index(player1, player2));
        }
    }
}