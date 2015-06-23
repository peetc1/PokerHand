using System.Collections.Generic;
using System.Linq;
using PokerHand.Business.Interfaces;
using PokerHand.Models;

namespace PokerHand.Business.Objects
{
    public class HandComparerService : IHandComparerService
    {
        public HandComparerService() { }

        #region Private Variables
        private static readonly List<HandTypeEnum> SinglePairList = new List<HandTypeEnum>
        {
            HandTypeEnum.FullHouse,
            HandTypeEnum.FourOfAKind,
            HandTypeEnum.ThreeOfAKind,
            HandTypeEnum.Pair
        };

        private static readonly Dictionary<HandTypeEnum,string> HandTypeNames = new Dictionary<HandTypeEnum, string>
        {
            {HandTypeEnum.Flush, "Flush"},
            {HandTypeEnum.FourOfAKind, "Four of a Kind"},
            {HandTypeEnum.FullHouse, "Full House"},
            {HandTypeEnum.HighCard, "High Card"},
            {HandTypeEnum.Pair, "Pair"},
            {HandTypeEnum.Straight, "Straight"},
            {HandTypeEnum.StraightFlush, "Straight Flush"},
            {HandTypeEnum.ThreeOfAKind, "Three of a Kind"},
            {HandTypeEnum.TwoPair, "Two Pair"}

        }; 
        #endregion

        #region Public Methods
        public Winner GetWinner(Player player1, Player player2)
        {
            var u1Type = GetHandType(player1.Hand.ToList());
            var u2Type = GetHandType(player2.Hand.ToList());

            // clear winner
            if ((int)u1Type.Type != (int)u2Type.Type)
            {
                return (int)u1Type.Type > (int)u2Type.Type ?
                    // winner player 1
                    new Winner
                    {
                        HandType = HandTypeNames[u1Type.Type],
                        UserName = player1.Name
                    } :
                    // winner player 2
                    new Winner
                    {
                        HandType = HandTypeNames[u2Type.Type],
                        UserName = player2.Name
                    };
            }

            // tie on type determine winner or push
            // full house, four of a kind, three of a kind (not possible to have 2 sets of 4/3 of a kind), two pair, or single pair
            if (SinglePairList.Contains(u1Type.Type))
            {
                // top pair check
                if (u1Type.HighPairValue != u2Type.HighPairValue)
                {
                    // return better high pairing
                    return new Winner
                    {
                        UserName = u1Type.HighPairValue > u2Type.HighPairValue ? player1.Name : player2.Name,
                        HandType = HandTypeNames[u1Type.Type]
                    };
                }

                // drop down to low pair check (for two pair), high card check, or push below
            }

            // lower pair check (for two pair)
            if (u1Type.LowPairValue != u2Type.LowPairValue)
            {
                // return better low pairing
                return new Winner
                {
                    UserName = u1Type.LowPairValue > u2Type.LowPairValue ? player1.Name : player2.Name,
                    HandType = HandTypeNames[u1Type.Type]
                };

                // drop down to high card check or push below
            }

            // straight, flush, or straight flush (winner is based on high card or it's a push)

            // high card check
            if (u1Type.HighCardValues.Max(x => x) != u2Type.HighCardValues.Max(x => x))
            {
                // return high card winner
                return new Winner
                {
                    UserName = u1Type.HighCardValues.Max(x => x) > u2Type.HighCardValues.Max(x => x) ? player1.Name : player2.Name,
                    HandType = HandTypeNames[u1Type.Type]
                };
            }
            
            for (var i = 1; i < u1Type.HighCardValues.Count; i++)
            {
                if (u1Type.HighCardValues[i] != u2Type.HighCardValues[i])
                {
                    // return high card winner
                    return new Winner
                    {
                        UserName = u1Type.HighCardValues[i] > u2Type.HighCardValues[i] ? player1.Name : player2.Name,
                        HandType = HandTypeNames[u1Type.Type]
                    };
                }
            }

            // tied high card (push)
            return new Winner
            {
                UserName = "Push. Hands are tied",
                HandType = HandTypeNames[u1Type.Type]
            };
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Gets the type of the hand.
        /// </summary>
        /// <param name="cards">The cards.</param>
        /// <returns>HandType.</returns>
        private static HandType GetHandType(IList<Card> cards)
        {
            // hand type attributes
            var attribs = new List<HandTypeEnum>();

            // determine flush
            if (cards.GroupBy(c => c.Suit.Key).Count() == 1)
            {
                attribs.Add(HandTypeEnum.Flush);
            }

            // get temp card values
            var tempCards = cards.Select(c => c.Type.Value).OrderBy(x => x).ToList();
            // replace ace value if needed
            if (tempCards.Max(t1 => t1) == CardSet.SetList.Max(c1 => c1.Value) &&
                tempCards.Min(t2 => t2) == CardSet.SetList.Min(c2 => c2.Value))
            {
                tempCards.Remove(tempCards.Max());
                tempCards.Add(1);
                // re-order temp list
                tempCards = tempCards.OrderBy(x => x).ToList();
            }

            // determine straight
            if (tempCards.Where((t, i) => (i + 1) < tempCards.Count && t + 1 == tempCards[i + 1]).Count() == (cards.Count-1))
            {
                attribs.Add(HandTypeEnum.Straight);
            }

            // determine straight flush
            if (attribs.Contains(HandTypeEnum.Straight) && attribs.Contains(HandTypeEnum.Flush))
            {
                // hand type determined
                return new HandType
                {
                    HighCardValues = cards.Select(x => x.Type.Value).OrderByDescending(y => y).ToList(),
                    Type = HandTypeEnum.StraightFlush
                };
            }

            // return straight or flush only
            if (attribs.Contains(HandTypeEnum.Straight) || attribs.Contains(HandTypeEnum.Flush))
            {
                // hand type determined
                return new HandType
                {
                    HighCardValues = cards.Select(x => x.Type.Value).OrderByDescending(y => y).ToList(),
                    Type = attribs.First()
                };
            }

            // determine pairs
            var typeList = cards.GroupBy(x => x.Type.Value).Select(g => new
            {
                Value = g.Key,
                Count = g.Count()
            }).ToList();
            foreach (var count in typeList)
            {
                switch (count.Count)
                {
                    case 2:
                        attribs.Add(HandTypeEnum.Pair);
                        break;
                    case 3:
                        attribs.Add(HandTypeEnum.ThreeOfAKind);
                        break;
                    case 4:
                        return new HandType
                        {
                            HighCardValues = typeList.Where(x => x.Count != 4).Select(x => x.Count).ToList(),
                            HighPairValue = typeList.First(x => x.Count == 4).Value,
                            Type = HandTypeEnum.FourOfAKind
                        };
                }
            }

            // determine full house
            if (attribs.Contains(HandTypeEnum.ThreeOfAKind) && attribs.Contains(HandTypeEnum.Pair))
            {
                return new HandType
                {
                    HighPairValue = typeList.First(x => x.Count == 3).Value,
                    LowPairValue = typeList.First(x => x.Count == 2).Value,
                    Type = HandTypeEnum.FullHouse
                };

            }

            // determine two pairs
            if (attribs.Where(a => a == HandTypeEnum.Pair).Select(s => new { value = (int)s }).Count() > 1)
            {
                return new HandType
                {
                    HighCardValues = typeList.Where(x => x.Count != 2).Select(y => y.Value).OrderByDescending(z => z).ToList(),
                    HighPairValue = typeList.Where(x => x.Count == 2).Max(y => y.Value),
                    LowPairValue = typeList.Where(x => x.Count == 2).Min(y => y.Value),
                    Type = HandTypeEnum.TwoPair
                };
            }

            // determine single pairing
            if (attribs.Contains(HandTypeEnum.ThreeOfAKind) || attribs.Contains(HandTypeEnum.Pair))
            {
                return new HandType
                {
                    HighCardValues = typeList.Where(x => x.Count < 2).Select(y => y.Value).OrderByDescending(z => z).ToList(),
                    HighPairValue = typeList.First(x => x.Count >= 2).Value,
                    Type = attribs.First()
                };

            }

            // High Card only
            return new HandType
            {
                HighCardValues = cards.Select(x => x.Type.Value).OrderByDescending(z => z).ToList(),
                Type = HandTypeEnum.HighCard
            };
        }
        #endregion
    }
}
