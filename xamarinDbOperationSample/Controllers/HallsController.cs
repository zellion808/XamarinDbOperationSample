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
    public class HallsController : ApiController
    {
        private SampleDataAccess db = new SampleDataAccess();

        // GET: api/Halls
        public IQueryable<Hall> GetHall()
        {
            return db.Hall;
        }

        // GET: api/Halls/5
        [ResponseType(typeof(Hall))]
        public IHttpActionResult GetHallById(int id)
        {
            Hall hall = db.Hall.Find(id);
            if (hall == null)
            {
                return NotFound();
            }

            return Ok(hall);
        }

        // PUT: api/Halls/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHall(int id, Hall hall)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hall.HallId)
            {
                return BadRequest();
            }

            db.Entry(hall).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HallExists(id))
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

        // POST: api/Halls
        [ResponseType(typeof(Hall))]
        public IHttpActionResult PostHall(Hall hall)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Hall.Add(hall);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hall.HallId }, hall);
        }

        // DELETE: api/Halls/5
        [ResponseType(typeof(Hall))]
        public IHttpActionResult DeleteHall(int id)
        {
            Hall hall = db.Hall.Find(id);
            if (hall == null)
            {
                return NotFound();
            }

            db.Hall.Remove(hall);
            db.SaveChanges();

            return Ok(hall);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HallExists(int id)
        {
            return db.Hall.Count(e => e.HallId == id) > 0;
        }
    }
}