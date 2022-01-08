using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChipmunkEventListing.Models
{
    public class Event
    {
       [Key]
       public int EventId { get; set; }
       public string EventTitle { get; set; }
       public string EventDescription { get; set; }
       public string ImageLocation { get; set; }

       [DataType(DataType.Date)]
       public DateTime StartDate { get; set; }

       [DataType(DataType.Date)]
       public DateTime EndDate { get; set; }




    // related entities
       public int VenueId { get; set; }






        // navigation properties
       public User User{ get; set; }
       public LineUp LineUp { get; set; }
   //  public Venue Venue { get; set; }
       public ICollection<Attendance> Attendences { get; set; }

    }
}