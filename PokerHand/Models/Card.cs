using System.Collections.Generic;
using PokerHand.Business;

namespace PokerHand.Models
{
    public class Card : ICard
    {
        public KeyValuePair<string,int> Type { get; set; }
        public KeyValuePair<int,string> Suit { get; set; }
    }
}
