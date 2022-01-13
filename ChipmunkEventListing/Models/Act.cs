namespace ChipmunkEventListing.Models
{
    public class Act
    {
        public int ActID { get; set; }
        public string ActName { get; set; }
        public int UserID { get; set; }
        public int GenreID { get; set; }
        public string GenreName { get; set; }   


        //navigation properties
        public User User { get; set; }
        public Genre Genre { get; set; }    

    }
}
