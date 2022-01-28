using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ChipmunkEventListing.Models

{
    public class User : IdentityUser
    {
        public ICollection<Attendance> Attendances { get; set; }
        public ICollection<Event> Events { get; set; }


    }
}