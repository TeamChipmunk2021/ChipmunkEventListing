using System;
using System.ComponentModel.DataAnnotations;

namespace ChipmunkEventListing.Models
{
    public class Event
    {
        public int ID { get; set; }
        public string eventTitle { get; set; }
        public string eventDescription { get; set; }
        public string image_location { get; set; }


        [DataType(DataType.Date)]
        public DateTime start_date { get; set; }

        [DataType(DataType.Date)]
        public DateTime end_date { get; set; }

    }
}