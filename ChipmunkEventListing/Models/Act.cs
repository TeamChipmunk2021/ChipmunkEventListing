using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ChipmunkEventListing.Models
{
    public class Act
    {
        
        public int ActId { get; set; }
        public string ActName { get; set; }
        public int UserId { get; set; }
        public int GenreId { get; set; }

        public int LineUpId { get; set; }


        // navigation properties
        public User User { get; set; }
        public Genre Genre { get; set; }
        public ICollection<LineUp> LineUp { get; set; }
    }
}
