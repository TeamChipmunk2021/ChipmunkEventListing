using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ChipmunkEventListing.Models

{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public int ActId { get; set; }

        [DataType(DataType.Date)]
        public DateTime UserCreated { get; set; }  

        //navigation properties
        public ICollection<Event> Events { get; set; }
        public ICollection<Act> Acts { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
    }
}
