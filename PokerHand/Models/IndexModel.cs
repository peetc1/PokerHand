using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PokerHand.Models
{
    public class IndexModel
    {
        [Display(Name = "Enter Player 1 Name:")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "The Player 1 Name must be a string with a minimum length of 2 and a maximum length of 60.")]
        [Required(ErrorMessage = "Player 1 Name is required")]
        public string UserName1 { get; set; }

        [Display(Name = "Enter Player 2 Name:")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "The Player 2 Name must be a string with a minimum length of 2 and a maximum length of 60.")]
        [Required(ErrorMessage = "Player 2 Name is required")]
        public string UserName2 { get; set; }
    }
}