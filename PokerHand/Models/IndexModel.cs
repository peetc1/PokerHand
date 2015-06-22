using System.ComponentModel.DataAnnotations;

namespace PokerHand.Models
{
    public class IndexModel
    {
        public IndexModel()
        {
            PlayerName1 = "";
            PlayerName2 = "";
        }

        public IndexModel(string username1, string username2)
        {
            PlayerName1 = username1;
            PlayerName2 = username2;
        }

        [Display(Name = "Enter Player 1 Name:")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "The Player 1 Name must be a string with a minimum length of 2 and a maximum length of 60.")]
        [Required(ErrorMessage = "Player 1 Name is required")]
        public string PlayerName1 { get; set; }

        [Display(Name = "Enter Player 2 Name:")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "The Player 2 Name must be a string with a minimum length of 2 and a maximum length of 60.")]
        [Required(ErrorMessage = "Player 2 Name is required")]
        public string PlayerName2 { get; set; }
    }
}