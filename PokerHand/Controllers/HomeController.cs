using System.Web.Mvc;
using PokerHand.Business.Interfaces;
using PokerHand.Business.Objects;
using PokerHand.Models;

namespace PokerHand.Controllers
{
    public partial class HomeController : Controller
    {
        private IDeck _gameDeck;

        [HttpGet]
        public virtual ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult Index(IndexModel model)
        {
            if (ModelState.IsValid)
            {
                // go to game page
                return RedirectToAction("Game", new { model.UserName1, model.UserName2 });
            }
            return View(model);
        }

        [HttpGet]
        public virtual ActionResult Game(IndexModel indexModel)
        {
            if (indexModel.UserName1 == null || indexModel.UserName2 == null)
            {
                return RedirectToAction(MVC.Home.Index());
            }

            // build model
            var model = new GameModel(indexModel);

            return View(model);
        }

        [HttpPost]
        public virtual ActionResult Game(GameModel model)
        {
            return View(model);
        }
    }
}