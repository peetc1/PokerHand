using System.Collections.Generic;
using PokerHand.Models;

namespace PokerHand.Business.Objects
{
    public class User
    {
        public string Name { get; set; }
        public IEnumerable<ICard> Hand { get; set; }
    }
}