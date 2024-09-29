namespace TableBookingSystem.Models.DTOs
{
    public class GetTimeSlotDTO
    {
        public int TimeSlotId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
