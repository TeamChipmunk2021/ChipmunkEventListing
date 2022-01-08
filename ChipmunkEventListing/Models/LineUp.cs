using System.Collections.Generic;
namespace ChipmunkEventListing.Models
{
    public class LineUp
    {
        public int LineUpId { get; set; }
        public int ActId { get; set; }

        public int EventId { get; set; }



        public ICollection<Act> Act { get; set; }

        public Event Event { get; set; }
    }
}
