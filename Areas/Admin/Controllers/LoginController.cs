using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using InnerMetrixWeb.Services;
using InnerMetrixWeb.Areas.Admin.Models;

namespace InnerMetrixWeb.Areas.Admin.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(AdminScoresModel adminScoresModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DomainService domainService = new DomainService(adminScoresModel.Username, adminScoresModel.Password);
                    if (domainService.IsAuthenticated)
                    {
                        FormsAuthentication.SetAuthCookie(adminScoresModel.Username, false);
                        return RedirectToAction("Index", "GuestInfoScore", new { Area = "Admin" });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid User NT Login/Password!");
                        return View(adminScoresModel);
                    }
                }
                else
                {
                    return View(adminScoresModel);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.InnerException + " " + ex.Message);
                throw;
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}