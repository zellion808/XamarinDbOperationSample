
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
using xamarinDbOperationSample.Models;

namespace xamarinDbOperationSample.Controllers
{
    public class ParticipatingSessionsController : ApiController
    {
        private SampleDataAccess db = new SampleDataAccess();

        // GET: api/ParticipatingSessions
        public IQueryable<ParticipatingSession> GetParticipatingSession()
        {
            try
            {
                return db.ParticipatingSession;
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        // GET: api/ParticipatingSessions/5
        [ResponseType(typeof(ParticipatingSession))]
        public IQueryable GetParticipatingSession(int id)
        {
            var sessionInfo = from a in db.ParticipatingSession
                              where a.RegistersId == id
                              select new ParticipatingSessionInfo
                              {
                                  RegistersId = a.RegistersId,
                                  SessionId = a.SessionId,
                                  HallId = a.HallId
                              };

            return sessionInfo;
        }

        // PUT: api/ParticipatingSessions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutParticipatingSession(int id, ParticipatingSession participatingSession)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != participatingSession.RegistersId)
            {
                return BadRequest();
            }

            db.Entry(participatingSession).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipatingSessionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ParticipatingSessions
        [ResponseType(typeof(ParticipatingSession))]
        public IHttpActionResult PostParticipatingSession(ParticipatingSession participatingSession)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ParticipatingSession.Add(participatingSession);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = participatingSession.RegistersId }, participatingSession);
        }

        // DELETE: api/ParticipatingSessions/5
        [ResponseType(typeof(ParticipatingSession))]
        public IHttpActionResult DeleteParticipatingSession(int id, int id2)
        {
            ParticipatingSession participatingSession = db.ParticipatingSession.Find(id, id2);
            if (participatingSession == null)
            {
                return NotFound();
            }

            db.ParticipatingSession.Remove(participatingSession);
            db.SaveChanges();

            return Ok(participatingSession);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ParticipatingSessionExists(int id)
        {
            return db.ParticipatingSession.Count(e => e.RegistersId == id) > 0;
        }
    }
}