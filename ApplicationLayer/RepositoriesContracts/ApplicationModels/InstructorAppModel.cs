using DomainLayer.Entities;

namespace ApplicationLayer.RepositoriesContracts.ApplicationModels
{
    public class InstructorAppModel
    {
        public string Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }

        public IList<AvailabilityAppModel>? Availabilities { get; set; }
        public IList<SessionAppModel>? Sessions { get; set; }
    }


}
