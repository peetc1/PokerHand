using System;
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
        


        [TestMethod]
        public void StraightFlushBeatsOtherHandTypes()
        {
            


        }
    }
}
