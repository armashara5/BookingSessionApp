using DomainLayer.Entities;
using DomainLayer.ValueObjects;

namespace ApplicationLayer.RepositoriesContracts.ApplicationModels
{
    public class SessionAppModel
    {
        public int Id { get; set; }
        public  string StudentId { get; set; }
        public string InstructorId { get; set; }
        public DateTime StartDate { get; set; }
        public  int LengthInMinutes { get; set; }
    }


}
