namespace PresentationSecureApi.Models
{
    public class AvailabilityVM
    {
        public int DayOfWeek { get; set; }
        public int StartTimeMinutes { get; set; }
        public int StartTimeHours { get; set; }
        public int EndTimeMinutes { get; set; }
        public int EndTimeHours { get; set; }
    }

}
