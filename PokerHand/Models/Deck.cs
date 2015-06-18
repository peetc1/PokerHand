using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PokerHand.Business;

namespace PokerHand.Models
{
    public class Deck
    {
        #region Constants

        private const int DeckSize = 52;

        #endregion

        #region Private variables

        /// <summary>
        /// The card set (A-K)
        /// </summary>
        private static List<KeyValuePair<string, int>> CardSet = new List<KeyValuePair<string, int>>
        {
            new KeyValuePair<string, int>("A", 1),
            new KeyValuePair<string, int>("2", 2),
            new KeyValuePair<string, int>("3", 3),
            new KeyValuePair<string, int>("4", 4),
            new KeyValuePair<string, int>("5", 5),
            new KeyValuePair<string, int>("6", 6),
            new KeyValuePair<string, int>("7", 7),
            new KeyValuePair<string, int>("8", 8),
            new KeyValuePair<string, int>("9", 9),
            new KeyValuePair<string, int>("10", 10),
            new KeyValuePair<string, int>("J", 11),
            new KeyValuePair<string, int>("Q", 12),
            new KeyValuePair<string, int>("K", 13)
        };

        private static List<KeyValuePair<int,string>> Suits = new List<KeyValuePair<int, string>>
        {
            new KeyValuePair<int, string>(1, "C"),
            new KeyValuePair<int, string>(2, "D"),
            new KeyValuePair<int, string>(3, "H"),
            new KeyValuePair<int, string>(4, "S")
        };

        private readonly Stack<Card> _cardStack;
        #endregion
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Deck"/> class.
        /// </summary>
        public Deck()
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
            foreach (var suit in Suits)
            {
                cards.AddRange(CardSet.Select(card => new Card
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
        /// Burns the card.
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
