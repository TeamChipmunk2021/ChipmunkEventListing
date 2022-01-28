using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ChipmunkEventListing.Data;
using ChipmunkEventListing.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ChipmunkEventListing.Authorization;

namespace ChipmunkEventListing.Pages.Events
{
   [AllowAnonymous]
    public class IndexModel : DI_BasePageModel
    {
        private readonly EventContext _context;

        private readonly IConfiguration Configuration;
        public IndexModel(
            EventContext context, 
            IConfiguration configuration, 
            IAuthorizationService authorizationService, 
            UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)
        {
            _context = context;
            Configuration = configuration;
        }

        public string EventNameSort { get; set; }
        public string StartDateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }


        public PaginatedList<Event> Events { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            EventNameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            StartDateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            // using System;
            EventNameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            StartDateSort = sortOrder == "Date" ? "date_desc" : "Date";

            CurrentFilter = searchString;

            IQueryable<Event> eventsIQ = from s in _context.Events
                                       select s;


            var isAuthorized = User.IsInRole(Constants.EventManagersRole) ||
                           User.IsInRole(Constants.EventAdministratorsRole);

            var currentUserId = UserManager.GetUserId(User);



            if (!isAuthorized)
            {
                eventsIQ = eventsIQ.Where(c => c.Status == EventStatus.Approved
                                            || c.OwnerID == currentUserId);
            }




            if (!String.IsNullOrEmpty(searchString))
            {
                eventsIQ = eventsIQ.Where(s => s.EventTitle.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    eventsIQ = eventsIQ.OrderByDescending(s => s.EventTitle);
                    break;
                case "StartDate":
                    eventsIQ = eventsIQ.OrderBy(s => s.StartDate);
                    break;
                case "date_desc":
                    eventsIQ = eventsIQ.OrderByDescending(s => s.StartDate);
                    break;
                default:
                    eventsIQ = eventsIQ.OrderBy(s => s.EventTitle);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 4);
            Events = await PaginatedList<Event>.CreateAsync(
                eventsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);

            // Users = await usersIQ.AsNoTracking().ToListAsync();
        }
    }
}