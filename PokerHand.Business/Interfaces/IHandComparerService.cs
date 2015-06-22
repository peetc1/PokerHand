using PokerHand.Business.Objects;

namespace PokerHand.Business.Interfaces
{
    public interface IHandComparerService
    {
        Winner GetWinner(Player player1, Player player2);
    }
}
