using System.Collections.Generic;
namespace ChipmunkEventListing.Models
{
    public class LineUp
    {
        public int LineUpID { get; set; }
        public int ActID { get; set; }
        
        public string ActName { get; set; }

        //navigation properties

        public Event Event { get; set; }  
        public ICollection<Act> Acts { get; set; }  

    }
}
