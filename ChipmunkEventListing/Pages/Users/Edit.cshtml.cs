using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChipmunkEventListing.Data;
using ChipmunkEventListing.Models;

namespace ChipmunkEventListing.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly ChipmunkEventListing.Data.EventContext _context;

        public EditModel(ChipmunkEventListing.Data.EventContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = await _context.Users.FindAsync(id);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var usertoUpdate = await _context.Users.FindAsync(id);

            if (usertoUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<User>(
                usertoUpdate,
                "user",
                  s => s.Username, s => s.Password, s => s.Email, s => s.UserCreated))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool UserExists(int? id)
        {
            return _context.Users.Any(e => e.UserID == id);
        }
    }
}
