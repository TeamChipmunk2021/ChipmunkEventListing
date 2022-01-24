using ChipmunkEventListing.Authorization;
using ChipmunkEventListing.Data;
using ChipmunkEventListing.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace ChipmunkEventListing.Pages.Events
{
    public class DeleteModel : DI_BasePageModel
    {
        private readonly ChipmunkEventListing.Data.EventContext _context;

        public DeleteModel(
            EventContext context,
            IAuthorizationService authorisationService,
            UserManager<IdentityUser> userManager)
            : base(context, authorisationService, userManager)
        {
            _context = context;
        }

        [BindProperty]
        public Event Event { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event = await _context.Events.FirstOrDefaultAsync(m => m.EventID == id);

            if (Event == null)
            {
                return NotFound();
            }


            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                      User, Event,
                                                      EventOperations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Fetch Event from DB to get OwnerID.
            var contact = await Context
                .Events.AsNoTracking()
                .FirstOrDefaultAsync(m => m.EventID == id);

            if (contact == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                   User, contact,
                                                   EventOperations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }


            Event.OwnerID = Event.OwnerID;

            Context.Attach(Event).State = EntityState.Modified;

            if (Event.Status == EventStatus.Approved)
            {

                var canApprove = await AuthorizationService.AuthorizeAsync(User,
                                        Event,
                                        EventOperations.Delete);

                if (!canApprove.Succeeded)
                {
                    Event.Status = EventStatus.Approved;

                    if (Event != null)
                    {
                        _context.Events.Remove(Event);
                        await _context.SaveChangesAsync();
                    }
                }
            }

            return RedirectToPage("./Index");
        }
    }
}


