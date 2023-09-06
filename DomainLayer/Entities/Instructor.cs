namespace DomainLayer.Entities
{

    public class Instructor
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }

        public IList<Availability>? Availabilities { get; set; }
        public IList<Session>? Sessions { get; set; }
    }

}
