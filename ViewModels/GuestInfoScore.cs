using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InnerMetrixWeb.Models;

namespace InnerMetrixWeb.ViewModels
{
    public class GuestInfoScore
    {
        public IEnumerable<GetGuestAttributeScore> guestAttributeScore { get; set; }
        public IEnumerable<GetGuestValuationScore> guestValuationScore { get; set; }
        public IEnumerable<GetGuestDimensionalBalanceScore> guestDimensionalBalanceScore { get; set; }
    }
}