using InnerMetrixWeb.Models;
using InnerMetrixWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InnerMetrixWeb.Controllers.API
{
    public class GetGuestInfoScoreByOracleIdController : ApiController
    {
        public IEnumerable<GetGuestInfoScore_Result> Get(string OracleId)
        {
            AdminService adminService = new AdminService();
            var res = adminService.GetGuestInfoScore(OracleId);
            return res;
        }
    }
}
