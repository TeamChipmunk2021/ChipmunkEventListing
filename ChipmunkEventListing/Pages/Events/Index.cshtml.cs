using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ChipmunkEventListing.Data;
using ChipmunkEventListing.Models;

namespace ChipmunkEventListing.Pages.Events
{
    public class IndexModel : PageModel
    {
        private readonly ChipmunkEventListing.Data.EventListingContext _context;

        public IndexModel(ChipmunkEventListing.Data.EventListingContext context)
        {
            _context = context;
        }

        public IList<Event> Event { get;set; }

        public async Task OnGetAsync()
        {
            Event = await _context.Event.ToListAsync();
        }
    }
}
