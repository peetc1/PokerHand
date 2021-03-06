﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHand.Business.Objects;

namespace PokerHand.Tests
{
    [TestClass]
    public class HandComparerServiceTest
    {
        // these pieces are always needed
        private Player _p1 = new Player("p1");
        private Player _p2 = new Player("p2");

        private static HandComparerService _comparerService;

        public HandComparerServiceTest()
        {
            _comparerService = new HandComparerService();
        }



        #region Straight Flush Tests

        [TestMethod]
        public void StraightFlushPushSameHand()
        {
            // Arrange
            _p1.Hand = GetStraightFlush(14);
            _p2.Hand = GetStraightFlush(14);

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, "Push. Hands are tied");
        }

        [TestMethod]
        public void StraightFlushBeatsLowerSameHand()
        {
            // Arrange
            _p1.Hand = GetStraightFlush(14);
            _p2.Hand = GetStraightFlush(10);

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        [TestMethod]
        public void StraightFlushBeatsFourOfAKind()
        {
            // Arrange
            _p1.Hand = GetStraightFlush();
            _p2.Hand = GetFourOfAKind(10, 9);

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        [TestMethod]
        public void StraightFlushBeatsFullHouse()
        {
            // Arrange
            _p1.Hand = GetStraightFlush();
            _p2.Hand = GetFullHouse(14, 10);

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        [TestMethod]
        public void StraightFlushBeatsFlush()
        {
            // Arrange
            _p1.Hand = GetStraightFlush();
            _p2.Hand = GetFlush();

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        [TestMethod]
        public void StraightFlushBeatsStraight()
        {
            // Arrange
            _p1.Hand = GetStraightFlush();
            _p2.Hand = GetStraight();

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        [TestMethod]
        public void StraightFlushBeatsThreeOfAKind()
        {
            // Arrange
            _p1.Hand = GetStraightFlush();
            _p2.Hand = GetThreeOfAKind(14,10);

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        [TestMethod]
        public void StraightFlushBeatsTwoPair()
        {
            // Arrange
            _p1.Hand = GetStraightFlush();
            _p2.Hand = GetTwoPair(14, 10, 8);

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        [TestMethod]
        public void StraightFlushBeatsPair()
        {
            // Arrange
            _p1.Hand = GetStraightFlush();
            _p2.Hand = GetPair();

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        [TestMethod]
        public void StraightFlushBeatsHighCard()
        {
            // Arrange
            _p1.Hand = GetStraightFlush();
            _p2.Hand = GetHighCard();

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        #endregion

        #region Four of a Kind Tests

        [TestMethod]
        public void FourOfAKindBeatsLowerSameHand()
        {
            // Arrange
            _p1.Hand = GetFourOfAKind();
            _p2.Hand = GetFourOfAKind(10);

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        [TestMethod]
        public void FourOfAKindBeatsFullHouse()
        {
            // Arrange
            _p1.Hand = GetFourOfAKind();
            _p2.Hand = GetFullHouse(14, 10);

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        [TestMethod]
        public void FourOfAKindBeatsFlush()
        {
            // Arrange
            _p1.Hand = GetFourOfAKind();
            _p2.Hand = GetFlush();

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        [TestMethod]
        public void FourOfAKindBeatsStraight()
        {
            // Arrange
            _p1.Hand = GetFourOfAKind();
            _p2.Hand = GetStraight();

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        [TestMethod]
        public void FourOfAKindBeatsThreeOfAKind()
        {
            // Arrange
            _p1.Hand = GetFourOfAKind();
            _p2.Hand = GetThreeOfAKind(14, 10);

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        [TestMethod]
        public void FourOfAKindBeatsTwoPair()
        {
            // Arrange
            _p1.Hand = GetFourOfAKind();
            _p2.Hand = GetTwoPair(14, 10, 8);

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        [TestMethod]
        public void FourOfAKindBeatsPair()
        {
            // Arrange
            _p1.Hand = GetFourOfAKind();
            _p2.Hand = GetPair();

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        [TestMethod]
        public void FourOfAKindBeatsHighCard()
        {
            // Arrange
            _p1.Hand = GetFourOfAKind();
            _p2.Hand = GetHighCard();

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        #endregion

        #region Full House Tests

        [TestMethod]
        public void FullHouseBeatsLowerTopThreeHand()
        {
            // Arrange
            _p1.Hand = GetFullHouse();
            _p2.Hand = GetFullHouse(10);

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        [TestMethod]
        public void FullHouseBeatsFlush()
        {
            // Arrange
            _p1.Hand = GetFullHouse();
            _p2.Hand = GetFlush();

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        [TestMethod]
        public void FullHouseBeatsStraight()
        {
            // Arrange
            _p1.Hand = GetFullHouse();
            _p2.Hand = GetStraight();

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        [TestMethod]
        public void FullHouseBeatsThreeOfAKind()
        {
            // Arrange
            _p1.Hand = GetFullHouse();
            _p2.Hand = GetThreeOfAKind(14, 10);

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        [TestMethod]
        public void FullHouseBeatsTwoPair()
        {
            // Arrange
            _p1.Hand = GetFullHouse();
            _p2.Hand = GetTwoPair(14, 10, 8);

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        [TestMethod]
        public void FullHouseBeatsPair()
        {
            // Arrange
            _p1.Hand = GetFullHouse();
            _p2.Hand = GetPair();

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        [TestMethod]
        public void FullHouseBeatsHighCard()
        {
            // Arrange
            _p1.Hand = GetFullHouse();
            _p2.Hand = GetHighCard();

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        #endregion

        #region Flush Tests

        [TestMethod]
        public void FlushPushSameHand()
        {
            // Arrange
            _p1.Hand = GetFlush();
            _p2.Hand = GetFlush();

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, "Push. Hands are tied");
        }

        [TestMethod]
        public void FlushBeatsLowerSameHand()
        {
            // Arrange
            _p1.Hand = GetFlush();
            _p2.Hand = GetFlush(10);

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }
        
        [TestMethod]
        public void FlushBeatsStraight()
        {
            // Arrange
            _p1.Hand = GetFlush();
            _p2.Hand = GetStraight();

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        [TestMethod]
        public void FlushBeatsThreeOfAKind()
        {
            // Arrange
            _p1.Hand = GetFlush();
            _p2.Hand = GetThreeOfAKind(14, 10);

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        [TestMethod]
        public void FlushBeatsTwoPair()
        {
            // Arrange
            _p1.Hand = GetFlush();
            _p2.Hand = GetTwoPair(14, 10, 8);

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        [TestMethod]
        public void FlushBeatsPair()
        {
            // Arrange
            _p1.Hand = GetFlush();
            _p2.Hand = GetPair();

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        [TestMethod]
        public void FlushBeatsHighCard()
        {
            // Arrange
            _p1.Hand = GetFlush();
            _p2.Hand = GetHighCard();

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        #endregion

        #region Straight Tests

        [TestMethod]
        public void StraightPushSameHand()
        {
            // Arrange
            _p1.Hand = GetStraight();
            _p2.Hand = GetStraight();

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, "Push. Hands are tied");
        }

        [TestMethod]
        public void StraightBeatsLowerSameHand()
        {
            // Arrange
            _p1.Hand = GetStraight();
            _p2.Hand = GetStraight(10);

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        [TestMethod]
        public void StraightBeatsThreeOfAKind()
        {
            // Arrange
            _p1.Hand = GetStraight();
            _p2.Hand = GetThreeOfAKind(14, 10);

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        [TestMethod]
        public void StraightBeatsTwoPair()
        {
            // Arrange
            _p1.Hand = GetStraight();
            _p2.Hand = GetTwoPair(14, 10, 8);

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        [TestMethod]
        public void StraightBeatsPair()
        {
            // Arrange
            _p1.Hand = GetStraight();
            _p2.Hand = GetPair();

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        [TestMethod]
        public void StraightBeatsHighCard()
        {
            // Arrange
            _p1.Hand = GetStraight();
            _p2.Hand = GetHighCard();

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        #endregion

        #region Three of a Kind Tests

        [TestMethod]
        public void ThreeOfAKindBeatsLowerTopThreeHand()
        {
            // Arrange
            _p1.Hand = GetThreeOfAKind();
            _p2.Hand = GetThreeOfAKind(10);

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        [TestMethod]
        public void ThreeOfAKindBeatsTwoPair()
        {
            // Arrange
            _p1.Hand = GetThreeOfAKind();
            _p2.Hand = GetTwoPair(14, 10, 8);

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        [TestMethod]
        public void ThreeOfAKindBeatsPair()
        {
            // Arrange
            _p1.Hand = GetThreeOfAKind();
            _p2.Hand = GetPair();

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        [TestMethod]
        public void ThreeOfAKindBeatsHighCard()
        {
            // Arrange
            _p1.Hand = GetThreeOfAKind();
            _p2.Hand = GetHighCard();

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        #endregion

        #region Two Pair Tests

        [TestMethod]
        public void TwoPairPushSameHand()
        {
            // Arrange
            _p1.Hand = GetTwoPair();
            _p2.Hand = GetTwoPair();

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, "Push. Hands are tied");
        }

        [TestMethod]
        public void TwoPairBeatsLowerTopPairHand()
        {
            // Arrange
            _p1.Hand = GetTwoPair();
            _p2.Hand = GetTwoPair(10,9);

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        [TestMethod]
        public void TwoPairBeatsLowerBottomPairHand()
        {
            // Arrange
            _p1.Hand = GetTwoPair(10, 9);
            _p2.Hand = GetTwoPair(10, 8);

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        [TestMethod]
        public void TwoPairBeatsLowerHighCardHand()
        {
            // Arrange
            _p1.Hand = GetTwoPair(10, 9, 8);
            _p2.Hand = GetTwoPair(10, 9);

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        [TestMethod]
        public void TwoPairBeatsPair()
        {
            // Arrange
            _p1.Hand = GetTwoPair();
            _p2.Hand = GetPair();

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        [TestMethod]
        public void TwoPairBeatsHighCard()
        {
            // Arrange
            _p1.Hand = GetTwoPair();
            _p2.Hand = GetHighCard();

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        #endregion

        #region Pair Tests

        [TestMethod]
        public void PairPushSameHand()
        {
            // Arrange
            _p1.Hand = GetPair();
            _p2.Hand = GetPair();

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, "Push. Hands are tied");
        }

        [TestMethod]
        public void PairBeatsLowerPairHand()
        {
            // Arrange
            _p1.Hand = GetPair();
            _p2.Hand = GetPair(5);

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        [TestMethod]
        public void PairBeatsLowerHighCardHand()
        {
            // Arrange
            _p1.Hand = GetPair(10, 9);
            _p2.Hand = GetPair(10, 8);

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        [TestMethod]
        public void PairBeatsHighCard()
        {
            // Arrange
            _p1.Hand = GetPair();
            _p2.Hand = GetHighCard();

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        #endregion

        #region High Card Tests

        [TestMethod]
        public void HighCardPushSameHand()
        {
            // Arrange
            _p1.Hand = GetHighCard();
            _p2.Hand = GetHighCard();

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, "Push. Hands are tied");
        }

        [TestMethod]
        public void HighCardBeatsLowerHighCardHand()
        {
            // Arrange
            _p1.Hand = GetHighCard();
            _p2.Hand = GetHighCard(5);

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        [TestMethod]
        public void HighCardBeatsLowerLastCard()
        {
            // Arrange
            _p1.Hand = new List<Card>
            {
                new Card{Suit = GetSingleSuit(), Type = CardSet.SetList.First(x => x.Value == 10)},
                new Card{Suit = GetSingleSuit(2), Type = CardSet.SetList.First(x => x.Value == 9)},
                new Card{Suit = GetSingleSuit(3), Type = CardSet.SetList.First(x => x.Value == 8)},
                new Card{Suit = GetSingleSuit(4), Type = CardSet.SetList.First(x => x.Value == 6)},
                new Card{Suit = GetSingleSuit(), Type = CardSet.SetList.First(x => x.Value == 4)},
            };
            _p2.Hand = new List<Card>
            {
                new Card{Suit = GetSingleSuit(), Type = CardSet.SetList.First(x => x.Value == 10)},
                new Card{Suit = GetSingleSuit(2), Type = CardSet.SetList.First(x => x.Value == 9)},
                new Card{Suit = GetSingleSuit(3), Type = CardSet.SetList.First(x => x.Value == 8)},
                new Card{Suit = GetSingleSuit(4), Type = CardSet.SetList.First(x => x.Value == 6)},
                new Card{Suit = GetSingleSuit(), Type = CardSet.SetList.First(x => x.Value == 3)},
            };

            // Act
            var result = _comparerService.GetWinner(_p1, _p2);

            // Assert
            Assert.AreEqual(result.UserName, _p1.Name);
        }

        #endregion

        #region Hand Helpers
        /// <summary>
        /// Gets the straight flush.
        /// </summary>
        /// <param name="highestCard">The highest card.</param>
        /// <returns>List&lt;Card&gt;.</returns>
        private List<Card> GetStraightFlush(int highestCard = 6)
        {
            var tempCards = GetStraightDictionary(highestCard);
            return tempCards.Select(card => new Card
            {
                Suit = GetSingleSuit(),
                Type = card
            }).ToList();
        }

        /// <summary>
        /// Gets four of a kind.
        /// </summary>
        /// <param name="fourCardValue">The four card value.</param>
        /// <param name="offCardValue">The off card value.</param>
        /// <returns>List&lt;Card&gt;.</returns>
        /// <exception cref="System.Exception">Cannot have 5 of a kind</exception>
        private static List<Card> GetFourOfAKind(int fourCardValue = 14, int offCardValue = 2)
        {
            if (fourCardValue == offCardValue) throw new Exception("Cannot have 5 of a kind");

            
            var offCard = CardSet.SetList.First(x => x.Value == offCardValue);

            // get four cards
            var list = GetCardsOfAKind(4, fourCardValue);
            
            // get off card
            list.Add(new Card
            {
                Suit = GetSingleSuit(),
                Type = offCard
            });

            return list;
        }


        /// <summary>
        /// Gets the full house.
        /// </summary>
        /// <param name="threeCardValue">The three card value.</param>
        /// <param name="pairCardValue">The pair card value.</param>
        /// <returns>List&lt;Card&gt;.</returns>
        /// <exception cref="System.Exception">Cannot have 5 of a kind</exception>
        private static List<Card> GetFullHouse(int threeCardValue = 14, int pairCardValue = 2)
        {
            if (threeCardValue == pairCardValue) throw new Exception("Cannot have 5 of a kind");

            // get top set cards
            var list = GetCardsOfAKind(3, threeCardValue);

            // get off card
            list.AddRange(GetCardsOfAKind(2, pairCardValue));

            return list;
        }

        /// <summary>
        /// Gets the flush.
        /// </summary>
        /// <param name="topCardValue">The top card value.</param>
        /// <returns>List&lt;Card&gt;.</returns>
        private static List<Card> GetFlush(int topCardValue = 14)
        {
            // single suit
            var suit = GetSingleSuit();

            // make flush hand
            return GetFlushDictionary(topCardValue).Select(card => new Card
            {
                Suit = suit, 
                Type = card
            }).ToList();
        }

        /// <summary>
        /// Gets the straight.
        /// </summary>
        /// <param name="topCardValue">The top card value.</param>
        /// <returns>List&lt;Card&gt;.</returns>
        private static List<Card> GetStraight(int topCardValue = 14)
        {
            // get straight cards
            return GetStraightDictionary(topCardValue).ToList().Select((t, i) => new Card
            {
                Suit = GetSingleSuit((i + 1) <= 4 ? (i + 1) : 4),
                Type = t
            }).ToList();
        }

        /// <summary>
        /// Gets three of a kind.
        /// </summary>
        /// <param name="threeCardValue">The three card value.</param>
        /// <param name="offCardHighValue">The off card high value.</param>
        /// <returns>List&lt;Card&gt;.</returns>
        /// <exception cref="System.Exception">Cannot have more than 3 of the same cards for 3 of a kind</exception>
        private static List<Card> GetThreeOfAKind(int threeCardValue = 14, int offCardHighValue = 3)
        {
            if (threeCardValue == offCardHighValue) throw new Exception("Cannot have more than 3 of the same cards for 3 of a kind");

            // get mult of a kind
            var list = GetCardsOfAKind(3, threeCardValue);

            // get off cards
            list.AddRange(GetStraightDictionary(offCardHighValue, 2).ToList().Select((t,i) => new Card
            {
                Suit = GetSingleSuit(i + 1),
                Type = t
            }));

            return list;
        }

        /// <summary>
        /// Gets two pair.
        /// </summary>
        /// <param name="topPairValue">The top pair value.</param>
        /// <param name="lowPairValue">The low pair value.</param>
        /// <param name="offCardValue">The off card value.</param>
        /// <returns>List&lt;Card&gt;.</returns>
        /// <exception cref="System.Exception">Cannot have more than 2 of the same cards for two pair</exception>
        private static List<Card> GetTwoPair(int topPairValue = 14, int lowPairValue = 10, int offCardValue = 3)
        {
            if (topPairValue == lowPairValue) throw new Exception("Cannot have more than 2 of the same cards for two pair");

            // get top pair
            var list = GetCardsOfAKind(2, topPairValue);

            // get bottom pair
            list.AddRange(GetCardsOfAKind(2, lowPairValue));

            // get off card
            list.Add( new Card
            {
                Suit = GetSingleSuit(),
                Type = CardSet.SetList.First(x => x.Value == offCardValue)
            });

            return list;
        }

        /// <summary>
        /// Gets the pair.
        /// </summary>
        /// <param name="pairValue">The pair value.</param>
        /// <param name="offCardHighValue">The off card high value.</param>
        /// <returns>List&lt;Card&gt;.</returns>
        /// <exception cref="System.Exception">Cannot have more than 2 of the same cards for a pair</exception>
        private static List<Card> GetPair(int pairValue = 14, int offCardHighValue = 12)
        {
            if (pairValue == offCardHighValue) throw new Exception("Cannot have more than 2 of the same cards for a pair");

            // get top pair
            var list = GetCardsOfAKind(2, pairValue);

            // get off cards
            list.AddRange(GetStraightDictionary(offCardHighValue, 3).ToList().Select((t, i) => new Card
            {
                Suit = GetSingleSuit(i + 1),
                Type = t
            }));

            return list;
        }

        /// <summary>
        /// Gets the high card.
        /// </summary>
        /// <param name="topCardValue">The top card.</param>
        /// <returns>List&lt;Card&gt;.</returns>
        /// <exception cref="System.Exception">Cannot have more than 2 of the same cards for a pair</exception>
        private static List<Card> GetHighCard(int topCardValue = 14)
        {
            // get high card
            return GetFlushDictionary(topCardValue).ToList().Select((t, i) => new Card
            {
                Suit = GetSingleSuit((i + 1) <= 4 ? (i + 1) : 4),
                Type = t
            }).ToList();
        }

        #endregion


        #region Card List Helpers

        /// <summary>
        /// Gets the straight dictionary.
        /// </summary>
        /// <param name="highCardValue">The highest card in the straight.</param>
        /// <param name="numOfCards">The number of cards.</param>
        /// <returns>Dictionary&lt;System.String, System.Int32&gt;.</returns>
        private static Dictionary<string, int> GetStraightDictionary(int highCardValue = 6, int numOfCards = 5)
        {
            return CardSet.SetList.OrderByDescending(x => x.Value).SkipWhile(x => x.Value > (highCardValue > 5 ? highCardValue : 6)).Take(numOfCards).ToDictionary(x => x.Key, x => x.Value);
        }

        /// <summary>
        /// Gets the flush dictionary.
        /// </summary>
        /// <param name="highCardValue">The high card value.</param>
        /// <returns>Dictionary&lt;System.String, System.Int32&gt;.</returns>
        private static Dictionary<string, int> GetFlushDictionary(int highCardValue = 14)
        {
            var dict =
                CardSet.SetList.OrderByDescending(x => x.Value)
                    .SkipWhile(x => x.Value > (highCardValue > 6 ? highCardValue : 7))
                    .Take(6).ToList();

            // remove one to make it not a straight
            dict.RemoveAt(3);
            return dict.ToDictionary(x => x.Key, x => x.Value);
        }

        /// <summary>
        /// Gets multiple of the kind of the cards of the passed in parameters.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="kindValue">The kind value.</param>
        /// <returns>List&lt;Card&gt;.</returns>
        private static List<Card> GetCardsOfAKind(int number, int kindValue = 14 )
        {
            if (number > 4) throw new Exception("Cannot have 5 of a kind");

            // get card value
            var multCard = CardSet.SetList.First(x => x.Value == kindValue);

            // get multiple cards
            return Suits.SuitList.Take(number).Select(x => new Card
            {
                Suit = x,
                Type = multCard
            }).ToList();
        }



        #endregion



        #region Suit Helpers
        /// <summary>
        /// Gets a single suit except the passed in value.
        /// </summary>
        /// <param name="exceptSuit">The except suit.</param>
        /// <returns>KeyValuePair&lt;System.Int32, System.String&gt;.</returns>
        private static KeyValuePair<int, string> GetSingleSuitExceptOne(int exceptSuit = 1)
        {
            return Suits.SuitList.First(x => x.Key != exceptSuit);
        }

        /// <summary>
        /// Gets the single suit.
        /// </summary>
        /// <param name="suitType">Type of the suit.</param>
        /// <returns>KeyValuePair&lt;System.Int32, System.String&gt;.</returns>
        private static KeyValuePair<int, string> GetSingleSuit(int suitType = 1)
        {
            return Suits.SuitList.ToList().First(x => x.Key == suitType);
        }

        /// <summary>
        /// Gets all four suits and an extra.
        /// </summary>
        /// <returns>Dictionary&lt;System.Int32, System.String&gt;.</returns>
        private static Dictionary<int, string> GetFourSuitsAndExtra()
        {
            var suits = Suits.SuitList;
            var single = GetSingleSuit();
            suits.Add(single.Key, single.Value);
            return suits;
        }

        #endregion

    }
}
