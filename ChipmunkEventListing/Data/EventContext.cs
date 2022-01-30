using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ChipmunkEventListing.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ChipmunkEventListing.Data
{
    public class EventContext : IdentityDbContext
    {
        public EventContext (DbContextOptions<EventContext> options)
            : base(options)
        {
        }
        public DbSet<Event> Events { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Event>().ToTable("Event");
            modelBuilder.Entity<Attendance>().ToTable("Attendance");
        }
    }
}
