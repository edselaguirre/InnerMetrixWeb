using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using InnerMetrixWeb.Services;

namespace InnerMetrixWeb.Areas.Admin.Controllers
{
    [Authorize]
    public class GuestInfoScoreController : Controller
    {
        // GET: Admin/GuestInfoScore
        public ActionResult Index()
        {
            int remainingTokens = 0, totalTokens = 0;
            double remainingTokensPerc = 0.00;

            TokenService tokenService = new TokenService();

            totalTokens = tokenService.GetTotalTokens();
            remainingTokens = tokenService.GetRemainingTokens();
            remainingTokensPerc = (Convert.ToDouble(remainingTokens) / Convert.ToDouble(totalTokens)) * 100;

            ViewBag.RemainingTokens = remainingTokens;
            ViewBag.RemainingTokensPercentage = remainingTokensPerc;

            string cookieName = FormsAuthentication.FormsCookieName;
            HttpCookie authCookie = HttpContext.Request.Cookies[cookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                ViewBag.UserName = ticket.Name;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "Admin" });
            }

        }
        [HttpPost]
        public ActionResult Index(string OracleId)
        {
            if (OracleId != null)
            {
                AdminService adminService = new AdminService();
                var res = adminService.GetGuestInfoScore(OracleId);
                return View(res);
            }
            return View();
        }
        public ActionResult View(string token)
        {
            AdminService adminService = new AdminService();
            var data = adminService.GetConsolidatedScores("WH_AI3128399a02c9fb174aa4");
            return View(data);
        }
        [HttpGet]
        public ActionResult GetAssessmentList()
        {
            TokenService tokenService = new TokenService();
            var returnData = tokenService.GetAssessmentList();
            return Json(new { data = returnData }, JsonRequestBehavior.AllowGet);
        }
    }
}