namespace TableBookingSystem.Models.DTOs
{
    public class GetTimeSlotDTO
    {
        public int TimeSlotId { get; set; }
        public int TimeSlotNr { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
