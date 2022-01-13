using System.Collections.Generic;

namespace ChipmunkEventListing.Models
{
    public class Genre
    {
        public int GenreID { get; set; }
        public string GenreName { get; set; }


        //navigation properties
        ICollection<Act> Acts { get; set; } 
    }
}
