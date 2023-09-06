namespace PresentationSecureApi.Models
{
    public class InstructorVM
    {
        public string Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }

        public IList<AvailabilityVM>? Availabilities { get; set; }
        public IList<SessionVM>? Sessions { get; set; }
    }

}
