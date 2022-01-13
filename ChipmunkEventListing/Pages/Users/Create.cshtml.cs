using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ChipmunkEventListing.Data;
using ChipmunkEventListing.Models;

namespace ChipmunkEventListing.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly ChipmunkEventListing.Data.EventContext _context;

        public CreateModel(ChipmunkEventListing.Data.EventContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User User { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyUser = new User();

            if (await TryUpdateModelAsync<User>(
                emptyUser,
                "user",   // Prefix for form value.
                s => s.Username, s => s.Password, s => s.Email))
            {
                _context.Users.Add(emptyUser);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            return Page();

        }
    }
}
