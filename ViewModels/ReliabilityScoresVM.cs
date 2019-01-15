using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InnerMetrixWeb.ViewModels
{
    public class ReliabilityScoresVM
    {
        public long ID { get; set; }
        public double Score { get; set; }
        public long TokenID { get; set; }
    }
}