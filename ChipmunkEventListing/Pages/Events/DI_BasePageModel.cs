using ChipmunkEventListing.Data;
using ChipmunkEventListing.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChipmunkEventListing.Pages.Events
{
    public class DI_BasePageModel : PageModel
    {
        protected EventContext Context { get; }
        protected IAuthorizationService AuthorizationService { get; }
        protected UserManager<User> UserManager { get; }
        public IAuthorizationService AuthorisationService { get; }
        

        public DI_BasePageModel(
            EventContext context,
            IAuthorizationService authorizationService,
            UserManager<User> userManager) : base()
        {
            Context = context;
            UserManager = userManager;
            AuthorizationService = authorizationService;
        }

        public DI_BasePageModel(EventContext context, IAuthorizationService authorisationService)
        {
            Context = context;
            AuthorisationService = authorisationService;
        }
    }
}