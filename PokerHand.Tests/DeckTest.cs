using System;
using System.Collections.Specialized;
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
            for (var i = 0; i < 45; i++)
            {
                deck.GetNextCard();
            }

            var left = deck.GetCardsLeft();

            // validation
            Assert.AreEqual(_fullDeck - 45, left);
        }

        [TestMethod]
        public void FullDeckAfterPullingAndShuffling()
        {
            // setup
            var deck = new DeckService();

            // execute
            for (var i = 0; i < 45; i++)
            {
                deck.GetNextCard();
            }

            deck.Shuffle();
            var left = deck.GetCardsLeft();

            // validation
            Assert.AreEqual(_fullDeck, left);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "No cards left in the deck")]
        public void ErrorPullingToManyCards()
        {
            // Arrange
            var deck = new DeckService();

            // Act
            for (var i = 0; i < 53; i++)
            {
                deck.GetNextCard();
            }
        }
    }
}
