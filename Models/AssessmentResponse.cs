using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InnerMetrixWeb.Services
{

    public class AssessmentResponse : IResponse
    {
        public int ResponseCode { get ; set; }
        public string Message { get; set; }
        public string Url { get; set; }
    }


}