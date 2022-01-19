﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChipmunkEventListing.Models
{
    

    public enum Venue
    {
        Venue1, Venue2
    }
    public class Event
    {
        //public string[] Bands = {"Kings of Leon", "Imagine Dragons", "Enter Shikari"};
        public int EventID { get; set; }
        public string EventTitle { get; set; }
        public string EventDescription { get; set; }
        public string ImageLocation { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public string Band { get; set; }
      
        public Venue? Venue { get; set; }


        //navigation properties

        public User User { get; set; }

        public Attendance Attendances { get; set; }

    }
}