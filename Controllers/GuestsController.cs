using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InnerMetrixWeb.Models;
using CommonLibraries.Core;

namespace InnerMetrixWeb.Controllers
{
    public class GuestsController : Controller
    {
        private InnermetrixDBEntities db = new InnermetrixDBEntities();

        public ActionResult TestEmail()
        {
            Email email = new Email();
            email.TO = "edsel.aguirre@alorica.com;robertryan.mallare@alorica.com;Barry.Orozco@alorica.com";
            email.Send("Mail Subject", "Mail Body");

            //Emailer mailmsg = new Emailer();
            //mailmsg.SendEmail("Default", "This is test", "Test");

            return RedirectToAction("Internal", "Home");
        }
        // GET: Guests
        public ActionResult Index()
        {
            return View(db.Guests.ToList());
        }

        //// GET: Guests/Details/5
        //public ActionResult Details(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Guest guest = db.Guests.Find(id);
        //    if (guest == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(guest);
        //}

        //// GET: Guests/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Guests/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,FirstName,LastName,OracleId,DateAdded,DateModified,CreatedBy,ModifiedBy,EmailAddress")] Guest guest)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Guests.Add(guest);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(guest);
        //}

        //// GET: Guests/Edit/5
        //public ActionResult Edit(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Guest guest = db.Guests.Find(id);
        //    if (guest == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(guest);
        //}

        //// POST: Guests/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,OracleId,DateAdded,DateModified,CreatedBy,ModifiedBy,EmailAddress")] Guest guest)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(guest).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(guest);
        //}

        //// GET: Guests/Delete/5
        //public ActionResult Delete(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Guest guest = db.Guests.Find(id);
        //    if (guest == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(guest);
        //}

        //// POST: Guests/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(long id)
        //{
        //    Guest guest = db.Guests.Find(id);
        //    db.Guests.Remove(guest);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
