using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PokerHand.Business.Objects;

namespace PokerHand.Models
{
    public class GameModel
    {
        public GameModel()
        {
            Player1 = new Player();
            Player2 = new Player();
        }

        public GameModel(string playerName1, string playerName2)
        {
            Player1 = new Player(playerName1);
            Player2 = new Player(playerName2);
        }
        
        [Display(Name = "Player 1:")]
        public Player Player1 { get; set; }

        [Display(Name = "Player 2:")]
        public Player Player2 { get; set; }

        public Winner GameWinner { get; set; }
    }
}