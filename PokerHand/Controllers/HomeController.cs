using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PokerHand.Business.Objects;
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
        public virtual ActionResult Index(User user1, User user2)
        {
            return View();
        }
    }
}