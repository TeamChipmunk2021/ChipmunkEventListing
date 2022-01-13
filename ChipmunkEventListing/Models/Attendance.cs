using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace ChipmunkEventListing.Models
{
    public class Attendance
    {
        public int AttendanceID { get; set; }
        public int EventID { get; set; }
        [ForeignKey("UserID")]
        public int UserID { get; set; }

        //navigation properties
       public ICollection<User> Users { get; set; }   

       public Event Event { get; set; }
    }
}
