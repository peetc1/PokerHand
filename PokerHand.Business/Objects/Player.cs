using System.Collections.Generic;
using PokerHand.Models;
using System.ComponentModel.DataAnnotations;

namespace PokerHand.Business.Objects
{
    public class Player
    {
        public Player()
        {
            Hand = new ICard[5];
        }

        public Player(string username)
        {
            Hand = new ICard[5];
            Name = username;
        }

        [Display(Name = "Player Name:")]
        public string Name { get; set; }

        public ICard[] Hand { get; set; }
    }
}