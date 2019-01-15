using CommonLibraries.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InnerMetrixWeb.Areas.Admin.Controllers
{
    public class DebugController : Controller
    {
        // GET: Admin/Debug
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string emailSubject, string emailBody)
        {
            try
            {
                Emailer emailService = new Emailer();

                Email email = new Email();

                email.MailServer = "mailrelay.alorica.com";
                email.From = "no-reply@alorica.com";
                email.TO = "edsel.aguirre@alorica.com;robertryan.mallare@alorica.com";
                
                email.Send(emailSubject, emailBody);
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex.Message;
            }

            return View();
        }
    }
}