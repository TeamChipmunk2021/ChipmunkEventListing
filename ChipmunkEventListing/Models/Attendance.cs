using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

namespace ChipmunkEventListing.Models
{
    public class Attendance
    {
        public int AttendanceId { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }



        // navigation properties
        public ICollection<User> User { get; set; }
        public ICollection<Event> Event { get; set; }


    }
}
