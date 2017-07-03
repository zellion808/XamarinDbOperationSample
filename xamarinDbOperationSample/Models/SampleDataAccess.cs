using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace xamarinDbOperationSample.Models
{
    public class SampleDataAccess : DbContext
    {
        public DbSet<Session>Session { get; set; }
        public DbSet<Hall>Hall { get; set; }
        public DbSet<Speaker>Speaker { get; set; }
        public DbSet<SessionSpeaker>SessionSpeaker { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}