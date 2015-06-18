using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHand.Models;

namespace PokerHand.Tests
{
    [TestClass]
    public class DeckTest
    {
        [TestMethod]
        public void FullDeck()
        {
            // setup
            var deck = new Deck();

            // execute
            var left = deck.GetCardsLeft();

            // validation
            Assert.AreEqual(52, left);
        }
    }
}
