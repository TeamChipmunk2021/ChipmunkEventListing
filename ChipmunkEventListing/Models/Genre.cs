using System.Collections.Generic;
namespace ChipmunkEventListing.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }


        // navigation properties
        
        public ICollection<Act> Act { get; set; }
    }
}
