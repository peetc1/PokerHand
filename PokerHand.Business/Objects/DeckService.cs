using System;
using System.Collections.Generic;
using System.Linq;
using PokerHand.Business.Interfaces;

namespace PokerHand.Business.Objects
{
    public class DeckService : IDeckService
    {
        #region Constants

        private const int DeckSize = 52;

        #endregion

        #region Private variables

        private Stack<Card> _cardStack;
        #endregion
        
        /// <summary>
        /// Initializes a new instance of the <see cref="DeckService"/> class.
        /// </summary>
        public DeckService()
        {
            _cardStack = new Stack<Card>();

            // initially shuffle the deck 
            Shuffle();
        }

        /// <summary>
        /// Shuffles this instance.
        /// </summary>
        public void Shuffle()
        {
            // temporary card list
            var cards = new List<Card>();

            // create temporary deck of cards
            foreach (var suit in Suits.SuitList)
            {
                cards.AddRange(CardSet.SetList.Select(card => new Card
                {
                    Suit = suit,
                    Type = new KeyValuePair<string, int>(card.Key, card.Value)
                }));
            }

            // random for shuffling (seeded with current date time for randomness after each shuffle)
            var rand = new Random((int) DateTime.Now.Ticks & 65535);

            // clear card stack
            _cardStack.Clear();

            // fill deck randomly
            for (var i = 1; i <= DeckSize; i++)
            {
                // if last card then just add it
                if (cards.Count == 1)
                {
                    var temp = cards.First();
                    _cardStack.Push(temp);
                    cards.RemoveAt(0);
                    continue;
                }

                // random id guaranteed to be within limit of cards left
                var randId = rand.Next(1, cards.Count);

                // add card to stack and remove from temp card list
                _cardStack.Push(cards[randId - 1]);
                cards.RemoveAt(randId - 1);
            }
        }

        /// <summary>
        /// Gets the next card.
        /// </summary>
        /// <returns>Card.</returns>
        public Card GetNextCard()
        {
            try
            {
                return _cardStack.Pop();
            }
            catch (InvalidOperationException)
            {
                throw new Exception("No cards left in the deck");
            }
        }

        /// <summary>
        /// Gets the cards left in the deck.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int GetCardsLeft()
        {
            return _cardStack.Count;
        }

        /// <summary>
        /// Burns the card. (wrote this for fun, I played around with texas hold-em)
        /// </summary>
        /// <param name="numOfCards">The number of cards to burn.</param>
        public void BurnCard(int numOfCards = 1)
        {
            try
            {
                for (var i = 0; i < numOfCards; i++)
                {
                    _cardStack.Pop();
                }
            }
            catch (InvalidOperationException)
            {
                // no cards left eat the error
            }
        }
    }
}
