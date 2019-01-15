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
    public class ScoresController : ApiController
    {
        private InnermetrixDBEntities db = new InnermetrixDBEntities();

        // GET: api/Scores
        public IEnumerable<ScoresVM> GetScores()
        {
            var res = (from s in db.Scores
                       select new ScoresVM
                       {
                           ID = s.ID,
                           Score1 = s.Score1,
                           Attribute = s.Attribute,
                           Token = s.Token
                       });
            return res;
        }

        // GET: api/Scores/5
        [ResponseType(typeof(ScoresVM))]
        public IHttpActionResult GetScore(long id)
        {
            var score = GetScores().Where(w => w.ID == id);
            return score == null ? NotFound() : (IHttpActionResult)Ok(score);
        }

        // PUT: api/Scores/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutScore(long id, Score score)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != score.ID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(score).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ScoreExists(id))
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

        // POST: api/Scores
        //[ResponseType(typeof(Score))]
        //public IHttpActionResult PostScore(Score score)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Scores.Add(score);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = score.ID }, score);
        //}

        // DELETE: api/Scores/5
        //[ResponseType(typeof(Score))]
        //public IHttpActionResult DeleteScore(long id)
        //{
        //    Score score = db.Scores.Find(id);
        //    if (score == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Scores.Remove(score);
        //    db.SaveChanges();

        //    return Ok(score);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ScoreExists(long id)
        {
            return db.Scores.Count(e => e.ID == id) > 0;
        }
    }
}