using DomainLayer.Entities;
using DomainLayer.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace InfrastructureLayer.DbModels
{
    public class SessionDbModel
    {
        [Key]
        public int Id { get; set; }
        public virtual StudentDbModel Student { get; set; }
        public string StudentId { get; set; }
        public virtual InstructorDbModel Instructor { get; set; }
        public  string InstructorId { get; set; }
        public DateTime StartDate { get; set; }
        public  int LengthInMinutes { get; set; }
    }


}
