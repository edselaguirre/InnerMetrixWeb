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
    public class DimensionalBalanceScoresController : ApiController
    {
        private InnermetrixDBEntities db = new InnermetrixDBEntities();

        // GET: api/DimensionalBalanceScores
        public IEnumerable<DimensionalBalanceScoresVM> GetDimensionalBalanceScores()
        {
            var res = (from s in db.DimensionalBalanceScores
                       select new DimensionalBalanceScoresVM
                       {
                           ID = s.ID,
                           Name = s.Name,
                           Score = s.Score,
                           Sign = s.Sign,
                           TokenID = s.TokenID
                       });
            return res;
        }

        // GET: api/DimensionalBalanceScores/5
        [ResponseType(typeof(DimensionalBalanceScoresVM))]
        public IHttpActionResult GetDimensionalBalanceScore(long id)
        {
            var dimensionalBalanceScore = GetDimensionalBalanceScores().Where(w => w.ID == id);
            return dimensionalBalanceScore == null ? NotFound() : (IHttpActionResult)Ok(dimensionalBalanceScore);
        }

        // PUT: api/DimensionalBalanceScores/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutDimensionalBalanceScore(long id, DimensionalBalanceScore dimensionalBalanceScore)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != dimensionalBalanceScore.ID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(dimensionalBalanceScore).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DimensionalBalanceScoreExists(id))
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

        // POST: api/DimensionalBalanceScores
        //[ResponseType(typeof(DimensionalBalanceScore))]
        //public IHttpActionResult PostDimensionalBalanceScore(DimensionalBalanceScore dimensionalBalanceScore)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.DimensionalBalanceScores.Add(dimensionalBalanceScore);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = dimensionalBalanceScore.ID }, dimensionalBalanceScore);
        //}

        // DELETE: api/DimensionalBalanceScores/5
        //[ResponseType(typeof(DimensionalBalanceScore))]
        //public IHttpActionResult DeleteDimensionalBalanceScore(long id)
        //{
        //    DimensionalBalanceScore dimensionalBalanceScore = db.DimensionalBalanceScores.Find(id);
        //    if (dimensionalBalanceScore == null)
        //    {
        //        return NotFound();
        //    }

        //    db.DimensionalBalanceScores.Remove(dimensionalBalanceScore);
        //    db.SaveChanges();

        //    return Ok(dimensionalBalanceScore);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DimensionalBalanceScoreExists(long id)
        {
            return db.DimensionalBalanceScores.Count(e => e.ID == id) > 0;
        }
    }
}