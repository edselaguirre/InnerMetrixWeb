using InnerMetrixWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InnerMetrixWeb.Areas.Admin.Models
{
    public class UploadTokens
    {
        public string File { get; set; }
        public bool isValid { get; set; }
        public int Count { get; set; }
        public UploadTokens(string file, bool isvalid, int count)
        {
            this.File = file;
            this.isValid = isvalid;
            this.Count = count;
        }

    }
}