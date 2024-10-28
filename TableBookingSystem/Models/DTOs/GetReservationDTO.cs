using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TableBookingSystem.Models.DTOs
{
    public class GetReservationDTO
    {
        public int ReservationId { get; set; }
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int TimeSlotId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int TableId { get; set; }
        public int NrOfSeats { get; set; }
        [JsonIgnore]
        public DateTime ReservationDate { get; set; }
        public string FormattedReservationDate => ReservationDate.ToString("yyyy-MM-dd");

        
    }
}
