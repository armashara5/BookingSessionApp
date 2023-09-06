using DomainLayer.ValueObjects;
using DayOfWeek = DomainLayer.ValueObjects.DayOfWeek;

namespace DomainLayer.Entities
{
    public class Availability
    {
        public DayOfWeek? DayOfWeek { get; set; }
        //StartTime.Hours and EndTime.Hours are in 24-hour format
        public TimeOfDay? StartTime { get; set; }
        public TimeOfDay? EndTime { get; set; }
    }

}
