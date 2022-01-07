using System;
using System.ComponentModel.DataAnnotations;

namespace ChipmunkEventListing.Models
{
    public class Event
    {
        public int ID { get; set; }
        public string EventTitle { get; set; }
        public string EventDescription { get; set; }
        public string ImageLocation { get; set; }
        public int LineupId { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public int VenueId { get; set; }

        public int UserId { get; set; }

    }
}