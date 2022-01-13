using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChipmunkEventListing.Models
{
    public class Event
    {
        public int EventID { get; set; }
        public string EventTitle { get; set; }
        public string EventDescription { get; set; }
        public string ImageLocation { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        
        public int VenueID { get; set; }
        public int? UserID { get; set; }
        public int LineupID { get; set; }


        //navigation properties

        public User User { get; set; }

        public Attendance Attendances { get; set; }  
        public ICollection<Venue> Venues { get; set; } 
        
        public LineUp LineUp { get; set; } 
    }
}