using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerHand.Models;

namespace PokerHand.Business.Interfaces
{
    public interface IDeck
    {
        void Shuffle();
        ICard GetNextCard();
        int GetCardsLeft();
    }
}
