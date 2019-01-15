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
    public class ReliabilityScoresController : ApiController
    {
        private InnermetrixDBEntities db = new InnermetrixDBEntities();

        // GET: api/ReliabilityScores
        public IQueryable<ReliabilityScoresVM> GetReliabilityScores()
        {
            var res = (from s in db.ReliabilityScores
                       select new ReliabilityScoresVM
                       {
                           ID = s.ID,
                           Score = s.Score,
                           TokenID = s.TokenID
                       });
            return res;
        }

        // GET: api/ReliabilityScores/5
        [ResponseType(typeof(ReliabilityScoresVM))]
        public IHttpActionResult GetReliabilityScores(long id)
        {
            var reliabilityScore = GetReliabilityScores().Where(w => w.ID == id);
            return reliabilityScore == null ? NotFound() : (IHttpActionResult)Ok(reliabilityScore);
        }

        // PUT: api/ReliabilityScores/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutReliabilityScore(long id, ReliabilityScore reliabilityScore)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != reliabilityScore.ID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(reliabilityScore).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ReliabilityScoreExists(id))
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

        // POST: api/ReliabilityScores
        //[ResponseType(typeof(ReliabilityScore))]
        //public IHttpActionResult PostReliabilityScore(ReliabilityScore reliabilityScore)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.ReliabilityScores.Add(reliabilityScore);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = reliabilityScore.ID }, reliabilityScore);
        //}

        // DELETE: api/ReliabilityScores/5
        //[ResponseType(typeof(ReliabilityScore))]
        //public IHttpActionResult DeleteReliabilityScore(long id)
        //{
        //    ReliabilityScore reliabilityScore = db.ReliabilityScores.Find(id);
        //    if (reliabilityScore == null)
        //    {
        //        return NotFound();
        //    }

        //    db.ReliabilityScores.Remove(reliabilityScore);
        //    db.SaveChanges();

        //    return Ok(reliabilityScore);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReliabilityScoreExists(long id)
        {
            return db.ReliabilityScores.Count(e => e.ID == id) > 0;
        }
    }
}