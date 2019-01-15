using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InnerMetrixWeb.Areas.Admin.Models;
using Innermetrix.Services;
using InnerMetrixWeb.Models;
using InnerMetrixWeb.ViewModels;

namespace InnerMetrixWeb.Areas.Admin.Models
{
    public class BatchToken
    {
        public IEnumerable<Token> Token { get; set; }
        
    }
}