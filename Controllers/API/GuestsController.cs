using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using InnerMetrixWeb.Models;
using InnerMetrixWeb.ViewModels;

namespace InnerMetrixWeb.Controllers.API
{
    [AllowAnonymous]
    public class GuestsController : ApiController
    {
        private InnermetrixDBEntities db = new InnermetrixDBEntities();

        // GET: api/Guests
        public IEnumerable<GuestsVM> GetGuests()
        {
            var res = (from s in db.Guests
                       select new GuestsVM
                       {
                           ID = s.ID,
                           FirstName = s.FirstName,
                           LastName = s.LastName,
                           OracleId = s.OracleId,
                           DateAdded = s.DateAdded,
                           DateModified = s.DateModified,
                           CreatedBy = s.CreatedBy,
                           ModifiedBy = s.ModifiedBy,
                           EmailAddress = s.EmailAddress
                       });
            return res;
        }

        // GET: api/Guests/5
        [ResponseType(typeof(GuestsVM))]
        public IHttpActionResult GetGuest(string id)
        {
            var guest = GetGuests().Where(w => w.OracleId == id);
            return guest == null ? NotFound() : (IHttpActionResult)Ok(guest);
        }

        // PUT: api/Guests/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutGuest(long id, Guest guest)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != guest.ID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(guest).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!GuestExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/Guests
        //[ResponseType(typeof(Guest))]
        //public IHttpActionResult PostGuest(Guest guest)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Guests.Add(guest);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = guest.ID }, guest);
        //}

        // DELETE: api/Guests/5
        //[ResponseType(typeof(Guest))]
        //public IHttpActionResult DeleteGuest(long id)
        //{
        //    Guest guest = db.Guests.Find(id);
        //    if (guest == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Guests.Remove(guest);
        //    db.SaveChanges();

        //    return Ok(guest);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GuestExists(long id)
        {
            return db.Guests.Count(e => e.ID == id) > 0;
        }
    }
}