using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHand.Business.Objects
{
    public class HandType
    {
        public HandTypeEnum Type { get; set; }
        public List<int> HighCardValues { get; set; }
        public int HighPairValue { get; set; }
        public int LowPairValue { get; set; }
    }
}
