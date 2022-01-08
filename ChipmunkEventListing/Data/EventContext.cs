using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ChipmunkEventListing.Models;

namespace ChipmunkEventListing.Data
{
    public class EventContext : DbContext
    {
        public EventContext (DbContextOptions<EventContext> options)
            : base(options)
        {
        }

        public DbSet<Act> Acts { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<LineUp> LineUps { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Venue> Venues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Act>().ToTable("Acts");
            modelBuilder.Entity<Attendance>().ToTable("Attendances");
            modelBuilder.Entity<Event>().ToTable("Events");
            modelBuilder.Entity<Genre>().ToTable("Genres");
            modelBuilder.Entity<LineUp>().ToTable("LineUps");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Venue>().ToTable("Venues");
        }
    }
}
