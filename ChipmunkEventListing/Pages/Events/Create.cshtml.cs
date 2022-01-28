using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ChipmunkEventListing.Data;
using ChipmunkEventListing.Models;
using ChipmunkEventListing.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace ChipmunkEventListing.Pages.Events
{
    public class CreateModel : DI_BasePageModel
    {
        public CreateModel(
            EventContext context,
            IAuthorizationService authorisationService,
            UserManager<User> userManager)
            : base(context, authorisationService, userManager)
        {

        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Event Event { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Event.OwnerID = UserManager.GetUserId(User);

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                        User, Event,
                                                        EventOperations.Create);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            Context.Events.Add(Event);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
