using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace ChipmunkEventListing.Models
{
    public class Attendance
    {

        public int? AttendanceID { get; set; }
        public int? EventID { get; set; }
        public string Username { get; set; }


        //navigation properties

        //  public Event Event { get; set; }
    }


}