using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PokerHand.Business.Interfaces;
using PokerHand.Business.Objects;

namespace PokerHand.Models
{
    public class GameModel
    {
        public GameModel(IndexModel model)
        {
            GameDeck = new Deck();
            User1 = new User(model.UserName1);
            User2 = new User(model.UserName2);
        }

        public IDeck GameDeck { get; set; }

        [Display(Name = "Player 1:")]
        public User User1 { get; set; }

        [Display(Name = "Player 2:")]
        public User User2 { get; set; }
    }
}