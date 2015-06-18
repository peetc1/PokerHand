using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokerHand.Models
{
    public class User
    {
        public string Name { get; set; }
        public IEnumerable<Card> Hand { get; set; }
    }
}