using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InnerMetrixWeb.ViewModels
{
    public class ScoresVM
    {
        public long ID { get; set; }
        public decimal Score1 { get; set; }
        public long Attribute { get; set; }
        public long Token { get; set; }
    }
}