using ChipmunkEventListing.Authorization;
using ChipmunkEventListing.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace ChipmunkEventListing.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(IServiceProvider serviceProvider, string testUserPw)
        {
            using (var context = new EventContext(
                serviceProvider.GetRequiredService<DbContextOptions<EventContext>>()))
            {
                // For sample purposes seed both with the same password.
                // Password is set with the following:
                // dotnet user-secrets set SeedUserPW <pw>
                // The admin user can do anything

                var adminID = await EnsureUser(serviceProvider, testUserPw, "admin@chipmunkseventlisting.com");
                await EnsureRole(serviceProvider, adminID, Constants.EventAdministratorsRole);

                // allowed user can create and edit contacts that they create
                var managerID = await EnsureUser(serviceProvider, testUserPw, "manager@chipmunkseventlisting.com");
                await EnsureRole(serviceProvider, managerID, Constants.EventManagersRole);

                SeedDB(context, adminID);
            }
        }

        private static async Task<string> EnsureUser(IServiceProvider serviceProvider,
                                                   string testUserPw, string UserName)
        {
            var userManager = serviceProvider.GetService<UserManager<User>>();

            var user = await userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                user = new User
                {
                    UserName = UserName,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, testUserPw);
            }

            if (user == null)
            {
                throw new Exception("The password is probably not strong enough!");
            }

            return user.Id;
        }

        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider,
                                                                      string uid, string role)
        {
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if (roleManager == null)
            {
                throw new Exception("roleManager null");
            }

            IdentityResult IR;
            if (!await roleManager.RoleExistsAsync(role))
            {
                IR = await roleManager.CreateAsync(new IdentityRole(role));
            }

            var userManager = serviceProvider.GetService<UserManager<User>>();

            //if (userManager == null)
            //{
            //    throw new Exception("userManager is null");
            //}

            var user = await userManager.FindByIdAsync(uid);

            if (user == null)
            {
                throw new Exception("The testUserPw password was probably not strong enough!");
            }

            IR = await userManager.AddToRoleAsync(user, role);

            return IR;
        }



        public static void SeedDB(EventContext context, string adminID)
        {
            context.Database.EnsureCreated();

            // Look for any users.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            //var users = new User[]
            //{
            //    new User{ Username="Username1", Email="Email", Password="password", UserCreated=DateTime.Now},
            //    new User{ Username="Username2", Email="Email2", Password="password2", UserCreated=DateTime.Now},
            //};

            // User user = new User { Email = "ab@mailinator.com", Password = "password", Attendances = new Attendance("1", "020", "723d6690-8271-407b-be09-581ca93f0a5a") };
            // context.Users.AddRange(users);
            context.SaveChanges();


            //var events = new Event[]
            //{
            //    new Event{
            //        EventTitle="Event1 Title",
            //        EventDescription="Event Description 1",
            //        StartDate=DateTime.Parse("2022-2-2"),
            //        EndDate=DateTime.Parse("2022-2-2"),
            //        ImageLocation="img loc",

            //        Venue= "The Apollo",
            //        Band= "Kings of Imagine Dragons",
            //        OwnerID = adminID
            //    },
            //    new Event{
            //        EventTitle="Event 2 Title",
            //        EventDescription="Event Description 2",
            //        StartDate=DateTime.Parse("2022-2-2"),
            //        EndDate=DateTime.Parse("2022-2-2"),
            //        ImageLocation="img loc",
            //        // Add User
            //        Venue= "The Local Tavern",
            //        Band= "BONO and U2 Coverband: U4",
            //        OwnerID = adminID
            //    }

            //};
            var attendance = new Attendance { AttendanceID = 1, EventID = 1, UserID = 1 };


            // context.Events.AddRange(events);
            context.SaveChanges();

            //var attendances = new Attendance[]
            //{
            //    new Attendance{ Event=events[0] } //add userId
            //};

            //context.Attendances.AddRange(attendances);
            context.SaveChanges();
        }
    }
}