using ChipmunkEventListing.Data;
using ChipmunkEventListing.Models;
using System;
using System.Linq;

namespace ChipmunkEventListing.Data
{
    public static class DbInitializer
    {
        public static void Initialize(EventContext context)
        {
            context.Database.EnsureCreated();

            // Look for any users.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
                new User{ Username="Username1", Email="Email", Password="password", UserCreated=DateTime.Now},
                new User{ Username="Username2", Email="Email2", Password="password2", UserCreated=DateTime.Now},
            };

            context.Users.AddRange(users);
            context.SaveChanges();


            var events  = new Event[]
            {
                new Event{
                    EventTitle="Event1 Title",
                    EventDescription="Event Description 1",
                    StartDate=DateTime.Parse("2022-2-2"),
                    EndDate=DateTime.Parse("2022-2-2"),
                    ImageLocation="img loc",
                    User=users[0],
                    Venue= "The Apollo",
                    Band= "Kings of Imagine Dragons"
                }

            };

            context.Events.AddRange(events);
            context.SaveChanges();

            var attendances = new Attendance[]
            {
                new Attendance{ Event=events[0], UserID = (int)users[0].UserID}
            };

            context.Attendances.AddRange(attendances);
            context.SaveChanges();
        }
    }
}