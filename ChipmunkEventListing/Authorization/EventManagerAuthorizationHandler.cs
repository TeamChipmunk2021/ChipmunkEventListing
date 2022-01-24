using System.Threading.Tasks;
using ChipmunkEventListing.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace ChipmunkEventListing.Authorization
{
    public class EventManagerAuthorizationHandler :
        AuthorizationHandler<OperationAuthorizationRequirement, Event>
    {
        protected override Task
            HandleRequirementAsync(AuthorizationHandlerContext context,
                                   OperationAuthorizationRequirement requirement,
                                   Event resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }
    }
}