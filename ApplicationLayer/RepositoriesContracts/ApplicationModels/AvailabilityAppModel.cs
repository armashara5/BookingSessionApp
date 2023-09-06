using DomainLayer.ValueObjects;

namespace ApplicationLayer.RepositoriesContracts.ApplicationModels
{
    public class AvailabilityAppModel
    {
        public int DayOfWeek { get; set; }
        public int StartTimeMinutes { get; set; }
        public int StartTimeHours { get; set; }
        public int EndTimeMinutes { get; set; }
        public int EndTimeHours { get; set; }
    }


}
