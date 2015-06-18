using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PokerHand.Models
{
    public class IndexModel
    {
        [Display(Name = "Enter Name for User 1")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string UserName1 { get; set; }
        [Display(Name = "Enter Name for User 2")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string UserName2 { get; set; }
    }
}