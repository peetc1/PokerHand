using PokerHand.Business.Objects;

namespace PokerHand.Business.Interfaces
{
    public interface IDeckService
    {
        void Shuffle();
        Card GetNextCard();
        int GetCardsLeft();
    }
}
