namespace back_end.Models
{
    public class Users
    {
        public int UserId { get; set; }
        public string MyEmail { get; set; }
        public string MyPass { get; set; }
        
        public string City { get; set; }
        public string Apod { get; set; }
        public string Timer { get; set; }
        public int ArtistId { get; set; }
        public string DeezerToken { get; set; }
    }
}