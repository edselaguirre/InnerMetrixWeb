using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InnerMetrixWeb.ViewModels
{
    public class ValuationScoresVM
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public double over { get; set; }
        public double under { get; set; }
        public long TokenID { get; set; }
    }
}