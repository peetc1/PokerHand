using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PokerHand.Business.Objects;

namespace PokerHand.Models
{
    public class GameModel
    {
        protected Deck GameDeck { get; set; }
        protected User User1 { get; set; }
        protected User User2 { get; set; }
    }
}