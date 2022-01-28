using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ChipmunkEventListing.Data;
using ChipmunkEventListing.Models;

namespace ChipmunkEventListing.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly ChipmunkEventListing.Data.EventContext _context;

        public DetailsModel(ChipmunkEventListing.Data.EventContext context)
        {
            _context = context;
        }

        public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = await _context.Users
           .Include(s => s.Events)
           .ThenInclude(e => e.Attendances)
           .AsNoTracking()
           .FirstOrDefaultAsync(m => m.UserID == id);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
