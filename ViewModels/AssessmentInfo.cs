using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InnerMetrixWeb.ViewModels
{
    public class AssessmentInfo
    {

        public AssessmentInfo(string fname, string lname, string emailaddress, string oracleid, string token, string scoresurl, string assessmentDate)
        {
            FirstName = fname;
            LastName = lname;
            EmailAddress = emailaddress;
            OracleId = oracleid;
            Token = token;
            ScoresUrl = scoresurl;
            AssessmentDate = assessmentDate;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string EmailAddress { get; }
        public string OracleId { get; }
        public string Token { get; }
        public string ScoresUrl { get; }
        public string AssessmentDate { get; set; }
    }
}