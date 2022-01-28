using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ChipmunkEventListing.Models;

namespace ChipmunkEventListing.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Attendances);
            //.HasMaxLength(250);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Events);
               // .Property(e => e.Events)
                //.HasMaxLength(250);

        }

    }
}
