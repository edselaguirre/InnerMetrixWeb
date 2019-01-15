using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InnerMetrixWeb.Services;
using InnerMetrixWeb.Models;
using InnerMetrixWeb.ViewModels;
using System.Configuration;
using System.Threading.Tasks;
using InnerMetrixWeb.Helpers;

namespace InnerMetrixWeb.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseController
    {
        public ActionResult Internal()
        {
            if (TempData["error"] != null) ModelState.AddModelError(string.Empty, TempData["error"].ToString());
            if (TempData["guest"] != null)
            {
                Guest guest = (Guest)TempData["guest"];
                return View(guest);
            }

            return View();
        }
        [HttpPost]
        public ActionResult Internal(InternalVM internalVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    GuestService guestService = new GuestService();
                    Guest guest = new Guest();
                    guest.OracleId = internalVM.OracleId;
                    guest.uid = internalVM.UserName;
                    guest.password = internalVM.Password;
                    guest.FirstName = internalVM.FirstName;
                    guest.LastName = internalVM.LastName;
                    guest.EmailAddress = internalVM.EmailAddress;
                    guest = guestService.GetUserInfo(guest);

                    if (guest != null)
                    {
                        var res = guestService.InnerMetrixURLBuilder(guest, "Internal");
                        return RedirectPermanent(res);
                    }
                }
                return View(internalVM);
            }
            catch (Exception)
            {
                //ModelState.AddModelError("", ex.InnerException + " " + ex.Message);
                ModelState.AddModelError("", "Error upon submitting form, Please retry again.");
                return View(internalVM);
                //throw ex;
            }
        }
        public ActionResult Candidates()
        {
            TempData["Culture"] = CultureHelper.GetCurrentCulture();

            if (TempData["error"] != null) ModelState.AddModelError(string.Empty, TempData["error"].ToString());
            if (TempData["guest"] != null)
            {
                Guest guest = (Guest)TempData["guest"];
                return View(guest);
            }

            return View();
        }
        public ActionResult SetCulture(string culture = "en")
        {

            TempData["Culture"] = culture;
            // Validate input
            culture = CultureHelper.GetImplementedCulture(culture);
            // Save culture in a cookie
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
                cookie.Value = culture;   // update cookie value
            else
            {
                cookie = new HttpCookie("_culture");
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);

            return RedirectToAction("Candidates", "Home");
        }
        [HttpPost]
        public ActionResult Candidates(CandidateViewModel candidateViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    GuestService guestService = new GuestService();
                    Guest guest = new Guest();
                    guest.FirstName = candidateViewModel.FirstName;
                    guest.LastName = candidateViewModel.LastName;
                    guest.EmailAddress = candidateViewModel.EmailAddress;
                    guest = guestService.GetUserInfo(guest);

                    if (guest != null)
                    {
                        var res = guestService.InnerMetrixURLBuilder(guest, "Candidates", candidateViewModel.Language ?? TempData["Culture"].ToString());
                        return RedirectPermanent(res);
                    }
                }
                return View(candidateViewModel);
            }
            catch (Exception ex)
            {
                //ModelState.AddModelError("", ex.InnerException + " " + ex.Message);
                ModelState.AddModelError("", "Error upon submitting form, Please retry again.");
                throw ex;
            }
        }
        public ActionResult Index(Guest guest)
        {
            return RedirectToAction("Internal", "Home");
        }
        public ActionResult ErrorPage() {
            return View();
        }
        public ActionResult SuccessPage(string code)
        {
            //data manipulation


            return View();
        }
        public ActionResult StartAssess()
        {
            return View();
        }
        public ActionResult ProcessAssessment(string id, string code, string previouslycompleted)
        {
            ViewBag.ReturnUrl = id;

            AssessmentService assessmentService = new AssessmentService(ConfigurationManager.AppSettings["BaseUrl"]);
            assessmentService.SaveRawScores(code);//code tempo only

            TokenService tokenService = new TokenService();
            tokenService.SetTokenAsUsed(code);

            return View("AssessmentSuccessful");
        }
        public ActionResult AssessmentSuccessful()
        {
            return View();
        }
        [HttpPost]
        public ActionResult StartAssess(Guest guest)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    if (string.IsNullOrWhiteSpace(guest.FirstName))
                    {
                        TempData["error"] = "Invalid Data. Please ensure all fields are filled up before starting the assessment.";
                        TempData["guest"] = guest;
                        return guest.OracleId != null ? RedirectToAction("Internal", "Home") : RedirectToAction("Candidates", "Home");
                    }

                    if (string.IsNullOrWhiteSpace(guest.LastName))
                    {
                        TempData["error"] = "Invalid Data. Please ensure all fields are filled up before starting the assessment.";
                        TempData["guest"] = guest;
                        return guest.OracleId != null ? RedirectToAction("Internal", "Home") : RedirectToAction("Candidates", "Home");
                    }

                    if (string.IsNullOrWhiteSpace(guest.EmailAddress))
                    {
                        TempData["error"] = "Invalid Data. Please ensure all fields are filled up before starting the assessment.";
                        TempData["guest"] = guest;
                        return guest.OracleId != null ? RedirectToAction("Internal", "Home") : RedirectToAction("Candidates", "Home");
                    }

                    GuestService guestService = new GuestService();
                    guest = guestService.GetUserInfo(guest);

                    if (guest != null)
                    {
                        TokenService tokenService = new TokenService();
                        var res = guestService.InnerMetrixURLBuilder(guest, "Candidates");
                        return RedirectPermanent(res);
                    }
                    else
                    {
                        TempData["error"] = "User is Invalid, Please check your Oracle OD.";
                        TempData["guest"] = guest;
                        return guest.OracleId != null ? RedirectToAction("Internal", "Home") : RedirectToAction("Candidates", "Home");
                    }
                }
                else
                {
                    var errormsg = ModelState.Values.SelectMany(m => m.Errors).Select(s => s.ErrorMessage).ToList();
                    TempData["error"] = errormsg[0];
                }
                TempData["guest"] = guest;
                return guest.OracleId != null ? RedirectToAction("Internal", "Home") : RedirectToAction("Candidates", "Home");
            }
            catch (Exception ex)
            {
                TempData["guest"] = guest;
                TempData["error"] = ex.InnerException + " " + ex.Message;
                return guest.OracleId != null ? RedirectToAction("Internal", "Home") : RedirectToAction("Candidates", "Home");
            }
        }
        public ActionResult AssessmentPage()
        {
            return Content(ViewBag.HtmlStringResult);
        }
        public ActionResult GetGuestInfo(string OracleId)
        {
            GuestService guestService = new GuestService();
            return Json(guestService.GetGuestInfo(OracleId), JsonRequestBehavior.AllowGet);
        }
    }

}