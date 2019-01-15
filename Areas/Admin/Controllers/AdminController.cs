using InnerMetrixWeb.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InnerMetrixWeb.Services;
using System.Web.Security;
using System.DirectoryServices.AccountManagement;
using System.IO;

namespace InnerMetrixWeb.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        [AllowAnonymous]
        public ActionResult AdminLogIn()
        {
            return View();
        }

        public ActionResult UploadTokens()
        {
            return View();
        }


        [HttpPost]
        public ActionResult UploadTokens(HttpPostedFileBase file)
        {
            try
            {
                if(ModelState.IsValid)
                {

                    TokenService tokenService = new TokenService();
                    tokenService.UploadTokens2(file);

                }
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult AdminLogIn(AdminScoresModel adminScoresModel)
        {
            try
            {
                DomainService domainService = new DomainService(adminScoresModel.Username, adminScoresModel.Password);
                if (domainService.IsAuthenticated)
                {
                    FormsAuthentication.SetAuthCookie(adminScoresModel.Username, false);
                    return RedirectToAction("Index", "GuestInfoScore", new { Area = "Admin" });
                }
                else
                {
                    ModelState.AddModelError("", "Invalid User NT Login / Password!");
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
            return RedirectToAction("AdminLogIn");
        }
    }
}