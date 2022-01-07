using System;
using System.ComponentModel.DataAnnotations;
namespace ChipmunkEventListing.Models

{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        [DataType(DataType.Date)]
        public DateTime UserCreated { get; set; }  
    }
}
