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
        public void ErrorPullingToManyCards()
        {
            // setup
            var deck = new DeckService();

            var error = "";

            // execute
            try
            {
                for (var i = 0; i < 53; i++)
                {
                    deck.GetNextCard();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            // validation
            Assert.AreEqual("No cards left in the deck", error);
        }

    }
}
