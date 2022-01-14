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

namespace ChipmunkEventListing.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly EventContext _context;

        private readonly IConfiguration Configuration;
        public IndexModel(EventContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string UsernameSort { get; set; }
        public string DateCreatedSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }


        public PaginatedList<User> Users { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            UsernameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateCreatedSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            // using System;
            UsernameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateCreatedSort = sortOrder == "Date" ? "date_desc" : "Date";

            CurrentFilter = searchString;

            IQueryable<User> usersIQ = from s in _context.Users
                                       select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                usersIQ = usersIQ.Where(s => s.Username.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    usersIQ = usersIQ.OrderByDescending(s => s.Username);
                    break;
                case "Date":
                    usersIQ = usersIQ.OrderBy(s => s.UserCreated);
                    break;
                case "date_desc":
                    usersIQ = usersIQ.OrderByDescending(s => s.UserCreated);
                    break;
                default:
                    usersIQ = usersIQ.OrderBy(s => s.Username);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 4);
            Users = await PaginatedList<User>.CreateAsync(
                usersIQ.AsNoTracking(), pageIndex ?? 1, pageSize);

            // Users = await usersIQ.AsNoTracking().ToListAsync();
        }
    }
}