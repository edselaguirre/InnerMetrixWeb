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
    public class ValuationScoresController : ApiController
    {
        private InnermetrixDBEntities db = new InnermetrixDBEntities();

        // GET: api/ValuationScores
        public IQueryable<ValuationScoresVM> GetValuationScores()
        {
            var res = (from s in db.ValuationScores
                       select new ValuationScoresVM
                       {
                           ID = s.ID,
                           Name = s.Name,
                           over = s.over,
                           under = s.under,
                           TokenID = s.TokenID
                       });
            return res;
        }

        // GET: api/ValuationScores/5
        [ResponseType(typeof(ValuationScore))]
        public IHttpActionResult GetValuationScore(long id)
        {
            var valuationScore = GetValuationScores().Where(w => w.ID == id);
            return valuationScore == null ? NotFound() : (IHttpActionResult)Ok(valuationScore);
        }

        // PUT: api/ValuationScores/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutValuationScore(long id, ValuationScore valuationScore)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != valuationScore.ID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(valuationScore).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ValuationScoreExists(id))
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

        // POST: api/ValuationScores
        //[ResponseType(typeof(ValuationScore))]
        //public IHttpActionResult PostValuationScore(ValuationScore valuationScore)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.ValuationScores.Add(valuationScore);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = valuationScore.ID }, valuationScore);
        //}

        // DELETE: api/ValuationScores/5
        //[ResponseType(typeof(ValuationScore))]
        //public IHttpActionResult DeleteValuationScore(long id)
        //{
        //    ValuationScore valuationScore = db.ValuationScores.Find(id);
        //    if (valuationScore == null)
        //    {
        //        return NotFound();
        //    }

        //    db.ValuationScores.Remove(valuationScore);
        //    db.SaveChanges();

        //    return Ok(valuationScore);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ValuationScoreExists(long id)
        {
            return db.ValuationScores.Count(e => e.ID == id) > 0;
        }
    }
}