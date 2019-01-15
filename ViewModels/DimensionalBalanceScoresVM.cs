using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InnerMetrixWeb.ViewModels
{
    public class DimensionalBalanceScoresVM
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public double Score { get; set; }
        public string Sign { get; set; }
        public long TokenID { get; set; }
    }
}