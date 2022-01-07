using System;
using System.ComponentModel.DataAnnotations;

namespace ChipmunkEventListing.Models
{
    public class Venue
    {
        public int ID { get; set; }
        public string Venue_Name { get; set; }
        public string Venue_Location { get; set; }
        public string Venue_Website { get; set; }
        public string Contact_Info { get; set; }
        public string Age_Restrictions { get; set; }
        public string Accessibility_Info { get; set; } 


    
    
    }
}