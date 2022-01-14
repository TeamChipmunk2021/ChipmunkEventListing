using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChipmunkEventListing.Models

{
    public class User
    {
        public int? UserID { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }


        [DataType(DataType.Date)]
        public DateTime UserCreated { get; set; }

        //navigation properties
        public ICollection<Attendance> Attendances { get; set; }
        public ICollection<Event> Events { get; set; }


    }
}