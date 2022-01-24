using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChipmunkEventListing.Models
{
    public class Event
    {

        // user ID from AspNetUser table.
        public string OwnerID { get; set; }


        public int EventID { get; set; }
        public string EventTitle { get; set; }
        public string EventDescription { get; set; }
        public string ImageLocation { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public string Band { get; set; }
        public string Venue { get; set; }

        public EventStatus Status { get; set; }



        //navigation properties
        public User User { get; set; }
        public Attendance Attendances { get; set; }

    }

    public enum EventStatus 
    {
      Approved
    }


}