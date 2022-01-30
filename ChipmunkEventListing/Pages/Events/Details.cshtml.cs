﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ChipmunkEventListing.Data;
using ChipmunkEventListing.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ChipmunkEventListing.Authorization;

namespace ChipmunkEventListing.Pages.Events
{
    [AllowAnonymous]
    public class DetailsModel : DI_BasePageModel
    {

        private readonly ChipmunkEventListing.Data.EventContext _context;
        public DetailsModel(
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
         //   Attendance = await _context.Attendances.FirstOrDefault(m => m.AttendanceID = id);
        

            if (Event == null)
            {
                return NotFound();
            }
            return Page();
        }


    
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

            var newAttendance = new Attendance()
            {
                EventID = Event.EventID,
                Username = User.Identity.Name

            };

            Context.Attendances.Add(newAttendance);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }


    }





}

