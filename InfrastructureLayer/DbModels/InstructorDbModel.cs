using DomainLayer.Entities;
using System.ComponentModel.DataAnnotations;

namespace InfrastructureLayer.DbModels
{
    public class InstructorDbModel
    {
        [Key]
        public string Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }

        public IList<AvailabilityDbModel>? Availabilities { get; set; }
        public IList<SessionDbModel>? Sessions { get; set; }
    }


}
