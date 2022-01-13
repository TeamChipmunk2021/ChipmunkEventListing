using ChipmunkEventListing.Models;
using System;
using System.Linq;



namespace ChipmunkEventListing.Data
{
    public class DbInitializer
    {

        public static void Initialize(EventContext context)
        {
            // Look for any Users.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
                new User{Username="Username 1", Password="Password 1", Email="emailaddress.com", UserCreated=DateTime.Parse("2022-08-01")},
                new User{Username="Username 2", Password="Password 2", Email="emailaddress.com", UserCreated=DateTime.Parse("2022-08-01")}
            };

            context.Users.AddRange(users);
            context.SaveChanges();

            var events = new Event[]
            {
                new Event{UserID=1, EventTitle="Event Title", EventDescription="Description", StartDate=DateTime.Parse("2022-08-01"), EndDate=DateTime.Parse("2022-08-01"), ImageLocation="location", LineupID=1, User=users[0]}
   
            };

            context.Events.AddRange(events);
            context.SaveChanges();

            var attendances = new Attendance[]
            {
                new Attendance{EventId=events[0].EventID, UserId=users[0].UserID}

            };

            context.Attendances.AddRange(attendances);
            context.SaveChanges();
        }
    }
}

