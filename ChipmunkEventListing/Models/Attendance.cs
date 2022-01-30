using System.ComponentModel.DataAnnotations;
namespace ChipmunkEventListing.Models
{
    public class Attendance
    {

        public int? AttendanceID { get; set; }
        [Required]
        public int? EventID { get; set; }
        public string Username { get; set; }


        //navigation properties

        //  public Event Event { get; set; }
    }


}