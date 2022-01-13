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
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Act> Acts { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<LineUp> LineUps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().ToTable(nameof(User))
                .HasMany(r => r.Attendances);
            modelBuilder.Entity<User>().ToTable(nameof(User))
                .HasMany(e => e.Events);
            modelBuilder.Entity<User>().ToTable(nameof(User))
                .HasMany(c => c.Acts);

            modelBuilder.Entity<Event>().ToTable(nameof(Event))
                   .HasMany(c => c.Venues);    

            modelBuilder.Entity<Attendance>().ToTable(nameof(Attendance))
                .HasMany(u => u.Users);
            modelBuilder.Entity<Act>().ToTable("Act");
            modelBuilder.Entity<Genre>().ToTable("Genre");
            modelBuilder.Entity<Venue>().ToTable("Venue");
            modelBuilder.Entity<LineUp>().ToTable(nameof(LineUp))
                .HasMany(i => i.Acts);

        }
    }
}
