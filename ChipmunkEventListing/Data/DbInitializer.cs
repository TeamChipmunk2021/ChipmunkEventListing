using ChipmunkEventListing.Models;
using System;
using System.Linq;

namespace ChipmunkEventListing.Data
{
    public static class DbInitializer
    {
        public static void Initialize(EventContext context)
        {
            // Look for any events.
            if (context.Events.Any())
            {
                return;   // DB has been seeded
            }

            //var acts = new Act[]
            //{
            //    new Act{ActId=1, ActName="Band number 1"},
            //    new Act{ActId=2, ActName="Band number 2"},
            //};

            //context.Acts.AddRange(acts);
            //context.SaveChanges();



            //var attendances = new Attendance[]
            //{
            //    new Attendance{ AttendanceId=1, EventId=1, UserId=1 },
            //    new Attendance{ AttendanceId=2, EventId=1, UserId=2 }

            //};

            //context.Attendances.AddRange(attendances);
            //context.SaveChanges();

            var events = new Event[]
            {
                new Event{EventId=1, EventTitle="EVENT TITLE 1", EventDescription="This is a description of Event 1", ImageLocation="a URL", StartDate=DateTime.Parse("2022-08-01"),EndDate=DateTime.Parse("2022-08-01"), VenueId=1, },
                new Event{EventId=2, EventTitle="EVENT TITLE 2", EventDescription="This is a description of Event 2", ImageLocation="a URL", StartDate=DateTime.Parse("2022-09-01"),EndDate=DateTime.Parse("2022-09-01"), VenueId=2, },
                new Event{EventId=3, EventTitle="title", }
            };

            context.Events.AddRange(events);
            context.SaveChanges();


//            var genres = new Genre[]
//            {
//                new Genre{GenreId=1,GenreName="Rock"},
//                new Genre{GenreId=2,GenreName="Pop"},
//                new Genre{GenreId=3,GenreName="Jazz"},
//            };

//            context.Genres.AddRange(genres);
//            context.SaveChanges();

//            var lineups = new LineUp[]
//            {
//                new LineUp{LineUpId=1, ActId=1},
//                new LineUp{LineUpId=2, ActId=2}
//            };

//            context.LineUps.AddRange(lineups);
//            context.SaveChanges();

//            var users = new User[]
//            {
//                new User {UserId=1, Username="User 1", Password="PASSWORD", Email="email@mail.com", UserCreated=DateTime.Parse("2022-08-01")}

//            };

//            context.Users.AddRange(users);
//            context.SaveChanges();

//            var venues = new Venue[]
//{
//                new Venue { VenueId=1, Venue_Name="Venue 1", Venue_Website="venue 1 URL", Contact_Info="Contact Info", Venue_Location="location info", Age_Restrictions="18+", Accessibility_Info="Wheelchair access is available"},
//                new Venue { VenueId=2, Venue_Name="Venue 2", Venue_Website="venue 2 URL", Contact_Info="Contact Info", Venue_Location="location info", Age_Restrictions="18+", Accessibility_Info="Wheelchair access is NOT available"}

//};

//            context.Venues.AddRange(venues);
//            context.SaveChanges();
      }
    }
}