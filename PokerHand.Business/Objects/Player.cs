using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PokerHand.Business.Objects
{
    public class Player
    {
        public Player()
        {
            Hand = new List<Card>();
        }

        public Player(string username)
        {
            Hand = new List<Card>();
            Name = username;
        }

        [Display(Name = "Player Name:")]
        public string Name { get; set; }

        public List<Card> Hand { get; set; }
    }
}