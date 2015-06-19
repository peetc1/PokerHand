using System.Collections.Generic;
using PokerHand.Models;
using System.ComponentModel.DataAnnotations;

namespace PokerHand.Business.Objects
{
    public class User
    {
        public User(string username)
        {
            Name = username;
        }

        [Display(Name = "Player Name:")]
        public string Name { get; set; }

        public IEnumerable<ICard> Hand { get; set; }
    }
}