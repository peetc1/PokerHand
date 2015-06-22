using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHand.Business.Objects;

namespace PokerHand.Tests.Controllers
{
    [TestClass]
    public class DeckHandsControllerTest
    {
        [TestMethod]
        public void FullDeck()
        {
            // setup
            var deck = new DeckService();

            // execute
            var left = deck.GetCardsLeft();

            // validation
            Assert.AreEqual(52, left);
        }
    }
}
