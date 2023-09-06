namespace PresentationSecureApi.Models
{
    public class SessionVM
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public string InstructorId { get; set; }
        public DateTime StartDate { get; set; }
        public int LengthInMinutes { get; set; }
    }

}
