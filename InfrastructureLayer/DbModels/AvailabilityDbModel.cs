using DomainLayer.Entities;
using DomainLayer.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace InfrastructureLayer.DbModels
{
    public class AvailabilityDbModel
    {
        [Key]
        public int Id { get; set; }
        public int DayOfWeek { get; set; }
        public int StartTimeMinutes { get; set; }
        public int StartTimeHours { get; set; }
        public int EndTimeMinutes { get; set; }
        public int EndTimeHours { get; set; }
        public string InstructorId { get; set; }
        public virtual InstructorDbModel Instructor { get; set; }
    }


}
