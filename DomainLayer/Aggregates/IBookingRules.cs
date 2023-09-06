using DomainLayer.Entities;
using DomainLayer.ValueObjects;

namespace DomainLayer.Aggregates
{
    public interface IBookingRules
    {
        bool IsInstructorAvailable(Instructor instructor, ValueObjects.DayOfWeek date, TimeOfDay time);
        bool IsInstructorBooked(Instructor instructor, DateTime startTime, TimeOfDay Length);
    }
}