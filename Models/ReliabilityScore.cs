//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InnerMetrixWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ReliabilityScore
    {
        public long ID { get; set; }
        public double Score { get; set; }
        public long TokenID { get; set; }
    
        public virtual Token Token { get; set; }
    }
}
