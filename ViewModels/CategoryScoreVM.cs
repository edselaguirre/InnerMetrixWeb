using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InnerMetrixWeb.ViewModels
{
    public class CategoryScoreVM
    {
        public long ID { get; set; }
        public double GettingResults { get; set; }
        public double InterpersonalSkills { get; set; }
        public double MakingDecisions { get; set; }
        public double WorkEthic { get; set; }
        public long TokenID { get; set; }
    }
}