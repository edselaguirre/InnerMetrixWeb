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
    public class TokensController : ApiController
    {
        private InnermetrixDBEntities db = new InnermetrixDBEntities();

        // GET: api/Tokens
        public IEnumerable<TokensVM> GetTokens()
        {
            var res = (from s in db.Tokens
                       select new TokensVM
                       {
                           ID = s.ID,
                           GuestId = s.GuestId,
                           Token1 = s.Token1,
                           IsUsed = s.IsUsed,
                           TokenStatus = s.TokenStatus,
                           DateLocked = s.DateLocked,
                           DateUsed = s.DateUsed,
                           IsLocked = s.IsLocked,
                           ScoresUrl = s.ScoresUrl
                       });
            return res;
        }

        // GET: api/Tokens/5
        [ResponseType(typeof(TokensVM))]
        public IHttpActionResult GetToken(long id)
        {
            var token = GetTokens().Where(w => w.ID == id);
            return token == null ? NotFound() : (IHttpActionResult)Ok(token);
        }

        // PUT: api/Tokens/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutToken(long id, Token token)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != token.ID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(token).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TokenExists(id))
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

        // POST: api/Tokens
        //[ResponseType(typeof(Token))]
        //public IHttpActionResult PostToken(Token token)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Tokens.Add(token);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (TokenExists(token.ID))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = token.ID }, token);
        //}

        // DELETE: api/Tokens/5
        //[ResponseType(typeof(Token))]
        //public IHttpActionResult DeleteToken(long id)
        //{
        //    Token token = db.Tokens.Find(id);
        //    if (token == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Tokens.Remove(token);
        //    db.SaveChanges();

        //    return Ok(token);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TokenExists(long id)
        {
            return db.Tokens.Count(e => e.ID == id) > 0;
        }
    }
}