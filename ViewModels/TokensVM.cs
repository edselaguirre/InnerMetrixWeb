using InnerMetrixWeb.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InnerMetrixWeb.ViewModels
{
    public class TokensVM
    {
        public long ID { get; set; }
        public Nullable<long> GuestId { get; set; }
        public string Token1 { get; set; }
        public Nullable<bool> IsUsed { get; set; }
        public Nullable<int> TokenStatus { get; set; }
        public Nullable<System.DateTime> DateLocked { get; set; }
        public Nullable<System.DateTime> DateUsed { get; set; }
        public Nullable<bool> IsLocked { get; set; }
        public string ScoresUrl { get; set; }
        
    }
}