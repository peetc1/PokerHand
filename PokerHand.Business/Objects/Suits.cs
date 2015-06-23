using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHand.Business.Objects
{
    public class Suits
    {
        public static readonly Dictionary<int, string> SuitList = new Dictionary<int, string>
        {
            {1, "D"},
            {2, "C"},
            {3, "H"},
            {4, "S"}
        };
    }
}
