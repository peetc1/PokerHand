using System.Collections.Generic;

namespace PokerHand.Models
{
    /// <summary>
    /// Interface ICard
    /// </summary>
    public interface ICard
    {
        KeyValuePair<string, int> Type { get; set; }
        KeyValuePair<int,string> Suit { get; set; }
    }
}