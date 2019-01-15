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
    public class CategoryScoresController : ApiController
    {
        private InnermetrixDBEntities db = new InnermetrixDBEntities();

        // GET: api/CategoryScores
        public IQueryable<CategoryScoreVM> GetCategoryScores()
        {
            var res = (from s in db.CategoryScores
                       select new CategoryScoreVM
                       {
                           ID = s.ID,
                           GettingResults = s.GettingResults,
                           InterpersonalSkills = s.InterpersonalSkills,
                           MakingDecisions = s.MakingDecisions,
                           WorkEthic = s.WorkEthic,
                           TokenID = s.TokenID
                       });
            return res;
        }

        // GET: api/CategoryScores/5
        [ResponseType(typeof(CategoryScore))]
        public IHttpActionResult GetCategoryScore(long id)
        {
            var categoryScore = GetCategoryScores().Where(w => w.ID == id);
            return categoryScore == null ? NotFound() : (IHttpActionResult)Ok(categoryScore);
        }

        // PUT: api/CategoryScores/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutCategoryScore(long id, CategoryScore categoryScore)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != categoryScore.ID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(categoryScore).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CategoryScoreExists(id))
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

        // POST: api/CategoryScores
        //[ResponseType(typeof(CategoryScore))]
        //public IHttpActionResult PostCategoryScore(CategoryScore categoryScore)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.CategoryScores.Add(categoryScore);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = categoryScore.ID }, categoryScore);
        //}

        // DELETE: api/CategoryScores/5
        //[ResponseType(typeof(CategoryScore))]
        //public IHttpActionResult DeleteCategoryScore(long id)
        //{
        //    CategoryScore categoryScore = db.CategoryScores.Find(id);
        //    if (categoryScore == null)
        //    {
        //        return NotFound();
        //    }

        //    db.CategoryScores.Remove(categoryScore);
        //    db.SaveChanges();

        //    return Ok(categoryScore);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryScoreExists(long id)
        {
            return db.CategoryScores.Count(e => e.ID == id) > 0;
        }
    }
}