using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHand.Business.Objects;

namespace PokerHand.Tests
{
    [TestClass]
    public class DeckTest
    {
        private const int _fullDeck = 52;

        [TestMethod]
        public void FullDeck()
        {
            // setup
            var deck = new DeckService();

            // execute
            var left = deck.GetCardsLeft();

            // validation
            Assert.AreEqual(_fullDeck, left);
        }

        [TestMethod]
        public void PartialDeckAfterPulling()
        {
            // setup
            var deck = new DeckService();

            // execute
            var left = deck.GetCardsLeft();

            for (var i = 0; i < 45; i++)
            {
                deck.GetNextCard();
            }

            var remaining = deck.GetCardsLeft();

            // validation
            Assert.AreEqual(_fullDeck - 45, remaining);
        }

    }
}
