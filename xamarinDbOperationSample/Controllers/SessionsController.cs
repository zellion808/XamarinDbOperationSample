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
    public class SessionsController : ApiController
    {
        private SampleDataAccess db = new SampleDataAccess();

        // GET: api/Sessions
        public IQueryable GetSession()
        {
            //var sinfo3 = from a in db.Session
            //                  join c in db.Hall on a.HallId equals c.HallId
            //                  select new
            //                  {
            //                      Session = a.SessionName,
            //                      Hall = c.HallName
            //                  };

            var sessionInfo = from a in db.Session
                         join c in db.Hall on a.HallId equals c.HallId
                         select new SessionInfo
                         {
                             SessionId = a.SessionId,
                             SessionName = a.SessionName,
                             RoomId = a.HallId,
                             RoomName = c.HallName,
                             Speakers = from e in db.Speaker
                                        join f in db.SessionSpeaker on e.SpeakerId equals f.SpeakerId
                                        join g in db.Session on f.SessionId equals g.SessionId
                                        where g.SessionId == a.SessionId
                                        select new SpeakerInfo
                                        {
                                            SpeakerId = e.SpeakerId,
                                            SpeakerName = e.SpeakerName,
                                        }
                         };

            return sessionInfo;
        }

        // GET: api/Sessions/5
        [ResponseType(typeof(Session))]
        public IHttpActionResult GetSessionById(int id)
        {
            Session session = db.Session.Find(id);
            if (session == null)
            {
                return NotFound();
            }

            return Ok(session);
        }

        // PUT: api/Sessions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSession(int id, Session session)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != session.SessionId)
            {
                return BadRequest();
            }

            db.Entry(session).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SessionExists(id))
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

        // POST: api/Sessions
        [ResponseType(typeof(Session))]
        public IHttpActionResult PostSession(Session session)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Session.Add(session);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = session.SessionId }, session);
        }

        // DELETE: api/Sessions/5
        [ResponseType(typeof(Session))]
        public IHttpActionResult DeleteSession(int id)
        {
            Session session = db.Session.Find(id);
            if (session == null)
            {
                return NotFound();
            }

            db.Session.Remove(session);
            db.SaveChanges();

            return Ok(session);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SessionExists(int id)
        {
            return db.Session.Count(e => e.SessionId == id) > 0;
        }
    }
}