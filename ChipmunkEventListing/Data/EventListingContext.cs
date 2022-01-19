using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ChipmunkEventListing.Models;

namespace ChipmunkEventListing.Data
{
    public class EventListingContext : DbContext
    {
        public EventListingContext (DbContextOptions<EventListingContext> options)
            : base(options)
        {
        }

        public DbSet<ChipmunkEventListing.Models.Event> Event { get; set; }
    }
}
