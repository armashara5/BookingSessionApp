using DomainLayer.Entities;
using DomainLayer.Exceptions;
using DomainLayer.ValueObjects;
using DayOfWeek = DomainLayer.ValueObjects.DayOfWeek;

namespace DomainLayer.Aggregates
{
    // Business rules
    public class BookingRules : IBookingRules
    {
        public bool IsInstructorAvailable(Instructor instructor, DayOfWeek date, TimeOfDay time)
        {
            if (instructor.Availabilities == null)
            {
                return false;
            }

            foreach (var availability in instructor.Availabilities)
            {
                if (availability.DayOfWeek == null || availability.StartTime == null || availability.EndTime == null)
                {
                    continue;
                }

                // Check if the day of week matches
                if (availability.DayOfWeek.Value != date.Value)
                {
                    continue;
                }

                // Check if the given time is within the instructor's available time slot
                if ((time.Hours > availability.StartTime.Hours ||
                    (time.Hours == availability.StartTime.Hours && time.Minutes >= availability.StartTime.Minutes)) &&
                    (time.Hours < availability.EndTime.Hours ||
                    (time.Hours == availability.EndTime.Hours && time.Minutes <= availability.EndTime.Minutes)))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsInstructorBooked(Instructor instructor, DateTime startTime, TimeOfDay Length)
        {
            if (instructor.Sessions == null)
            {
                return false;
            }

            // you need the sessions not the instructor
            foreach (var bookedSession in instructor.Sessions)
            {

                // Check if the day of week matches
                if (bookedSession.StartDate.DayOfWeek != startTime.DayOfWeek)
                {
                    continue;
                }

                // Check if the given time overlaps with the booking's time
                if ((startTime <= bookedSession.StartDate) &&
                    (startTime.AddMinutes(Length.Minutes + (Length.Hours * 60)) >= bookedSession.StartDate.AddMinutes(bookedSession.Length.Minutes + (bookedSession.Length.Hours * 60))))
                {
                    return true;
                }
            }

            return false;
        }


    }
}
