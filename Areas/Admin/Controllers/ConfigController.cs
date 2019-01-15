using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InnerMetrixWeb.Models;

namespace InnerMetrixWeb.Areas.Admin.Controllers
{
    [Authorize]
    public class ConfigController : Controller
    {
        private InnermetrixDBEntities db = new InnermetrixDBEntities();
        // GET: Admin/Config
        public ActionResult Index()
        {
            Config config = db.Configs.Find(1);
            return View(config);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Config config)
        {
            if (ModelState.IsValid)
            {
                config.Recepients = config.Recepients.Trim();
                db.Entry(config).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(config);
        }
    }
}