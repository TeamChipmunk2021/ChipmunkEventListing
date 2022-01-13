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

            //Users
            var user1 = new User
            {
                Username = "Username 1",
                Password = "Password 1",
                Email = "emailaddress.com",
                UserCreated = DateTime.Parse("2022-08-01")
            };

            var user2 = new User
            {
                Username = "Username 2",
                Password = "Password 2",
                Email = "emailaddress.com2",
                UserCreated = DateTime.Parse("2022-08-02")
            };
            //Genres

            var genre1 = new Genre
            {
                GenreName = "ROCK"
            };

            var genre2 = new Genre
            {
                GenreName = "POP"
            };

            //Acts

            var act1 = new Act
            {
                ActName = "Band 1",
                GenreName = genre1.GenreName
            };

            var act2 = new Act
            {
                ActName = "Band 2",
                GenreName = genre2.GenreName
            };


            //Venues

            var venue1 = new Venue 
            { 
                Venue_Name = "Venue 1",
                Venue_Location = "location 1",
                Venue_Website = "Website 1",
                Accessibility_Info = "Wheelchair Access",
                Age_Restrictions = "18+",
                Contact_Info = "0800800800"
            
            };

            var lineups = new LineUp[]
            {
                new LineUp
                {
                    ActName = act1.ActName,

                },
                new LineUp
                {
                  ActName = act2.ActName,
                
                }
            };
            context.LineUps.AddRange(lineups);




            var events = new Event[]
            {
                new Event{
                    EventTitle="Title 1",
                    EventDescription = "Description 1",
                    StartDate = DateTime.Parse("2022-08-01"),
                    EndDate = DateTime.Parse("2022-08-02"),
                    ImageLocation = "image location 1",
                    LineUp = lineups[0],
                    User = user1,
                    VenueID = venue1.VenueID,
                },
                    new Event{
                    EventTitle="Title 2",
                    EventDescription = "Description 2",
                    StartDate = DateTime.Parse("2022-08-01"),
                    EndDate = DateTime.Parse("2022-08-02"),
                    ImageLocation = "image location",
                    LineUp = lineups[1],
                    User = user2,
                    VenueID = venue1.VenueID,

                }


            };

            context.Events.AddRange(events);
            context.SaveChanges();

            var attendances = new Attendance[]
            {
                new Attendance{
                EventID = events[0].EventID,
                UserID = user1.UserID
                },
                new Attendance{
                EventID = events[0].EventID,
                UserID = user2.UserID
                }
            };

            context.Attendances.AddRange(attendances);
            context.SaveChanges();
        }
    }
}

