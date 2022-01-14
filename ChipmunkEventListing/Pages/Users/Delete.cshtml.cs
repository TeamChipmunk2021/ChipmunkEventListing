using ChipmunkEventListing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ChipmunkEventListing.Pages.Users
{
    public class DeleteModel : PageModel
    {
        private readonly ChipmunkEventListing.Data.EventContext _context;

        public DeleteModel(ChipmunkEventListing.Data.EventContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.UserID == id);

            if (User == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Delete failed. Try again";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            try
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction("./Delete",
                                     new { id, saveChangesError = true });
            }
        }
    }
}