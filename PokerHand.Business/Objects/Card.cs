using System.Collections.Generic;
using PokerHand.Models;

namespace PokerHand.Business.Objects
{
    public class Card : ICard
    {
        public KeyValuePair<string,int> Type { get; set; }
        public KeyValuePair<int,string> Suit { get; set; }
    }
}
