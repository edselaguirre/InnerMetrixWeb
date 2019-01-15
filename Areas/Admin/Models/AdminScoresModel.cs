using InnerMetrixWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InnerMetrixWeb.Areas.Admin.Models
{
    public class AdminScoresModel
    {
        public string token { get; set; }
        public List<GetGuestDimensionalBalanceScore> dimensionalBalanceScores { get; set; }
        public List<GetGuestValuationScore> valuationScores { get; set; }
        public List<GetGuestAttributeScore> attributeScores { get; set; }


        [Required(ErrorMessage = "Username is required.")]
        [Display(Name = "User NT Login")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool valid { get; set; }
        public bool RememberMe { get; set; }

    }
}