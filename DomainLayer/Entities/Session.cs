using DomainLayer.ValueObjects;

namespace DomainLayer.Entities
{
    public class Session
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public required TimeOfDay Length { get; set; }

        //as abstraction of instructor-student relation we can remove both entities 
        //public required Student Student { get; set; }
        //public required Instructor Instructor { get; set; }
    }

    
    }
