using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TableBookingSystem.Models.DTOs
{
    public class GetReservationDTO
    {
        public int ReservationId { get; set; }
        public GetCustomerDTO Customer { get; set; }
        public GetTimeSlotDTO TimeSlot { get; set; }
        public ICollection<TableReservation> TableReservations { get; set; }
        public int NrOfSeats { get; set; }
        [JsonIgnore]
        public DateTime ReservationDate { get; set; }
        public string FormattedReservationDate => ReservationDate.ToString("yyyy-MM-dd");
    }
}
